using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace L3_CAN_Statistics
{
    public partial class Form1 : Form
    {
        DataTable dataTable;
        DataTable CANdataTable;
        List<CANDumpData> frames;
        public Form1()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Табличные данные (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    byte[] bytes = new byte[fs.Length];
                    int bytesRead = 0;
                    while ((bytesRead = fs.Read(bytes, 0, bytes.Length)) > 0)
                    {
                    }

                    byte[] frame = new byte[19];
                    frames = new List<CANDumpData>();
                    int I = 0;
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        if (bytes[i] == 255 && bytes[i + 1] == 255)
                        {
                            I = 0;
                            i++;
                            BitConverter.ToInt32(bytes, 0);
                            UInt32 time = (UInt32)(frame[3] * 256 * 256 + 256 + frame[2] * 256 * 256 + frame[1] * 256 + frame[0]);
                            frames.Add(new CANDumpData(time,
                                frame[4],
                                frame[5],
                                frame[6],
                                frame[7],
                                frame[8],
                                frame[9],
                                frame[10],
                                frame[11],
                                frame[12],
                                frame[13],
                                frame[14],
                                frame[15],
                                frame[16]));
                        }
                        else
                        {
                            frame[I] = bytes[i];
                            I++;

                        }
                    }


                }
            }
            pictureBox1.Image = Draw.Сonnection(frames);
        }
        private void CANtodataGrid(List<CANDumpData> frames)
        {
            CANdataTable = Data.TableFromCAN(frames);
            //dataTable = new DataTable();
            if (!dataTable.Columns.Contains("TickStamp"))
                dataTable.Columns.Add("TickStamp", typeof(UInt32));

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["TickStamp"] };
            // Получаем все уникальные значения столбца "TickStamp"
            var uniqueNames = CANdataTable.AsEnumerable().Select(row => row.Field<UInt32>("TickStamp")).Distinct();

            foreach (DataGridViewRow row_Ewent in dataGridView_Event.Rows)
            {
                DataGridViewCell cell = row_Ewent.Cells[5];
                cell.Style.BackColor = Color.White;
            }
            foreach (UInt32 time in uniqueNames)
            {
                DataRow[] rows = CANdataTable.Select($"TickStamp = '{time}'");

                // Проверяем наличие строк в dataTable
                DataRow existingRow = dataTable.Rows.Find(time);
                DataRow newRow;
                if (existingRow == null)
                {
                    newRow = dataTable.NewRow();
                    newRow["TickStamp"] = time;
                    dataTable.Rows.Add(newRow);
                }
                else
                {
                    newRow = existingRow;
                }


                foreach (DataRow row in rows)
                {
                    foreach (DataGridViewRow row_Filter in dataGridView_Filter.Rows)
                    {
                        // Проверяем значение чекбокса в текущей строке
                        DataGridViewCheckBoxCell checkBoxCell = row_Filter.Cells[0] as DataGridViewCheckBoxCell;
                        if (checkBoxCell != null && (bool)checkBoxCell.Value == true)
                        {
                            string Source = row_Filter.Cells[1].Value.ToString();
                            string Dest = row_Filter.Cells[2].Value.ToString();
                            if ((Source == "Все" || Source == row["Source"].ToString()) &&
                                (Dest == "Все" || Dest == row["Dest"].ToString()))
                            {
                                string name = row["Source"] + "=>" + row["Dest"];
                                if (!dataTable.Columns.Contains(name))
                                {
                                    dataTable.Columns.Add(name, typeof(byte));
                                }
                                newRow[name] = row["b1"];
                                foreach (DataGridViewRow row_Ewent in dataGridView_Event.Rows)
                                {
                                    DataGridViewCell cell = row_Ewent.Cells[5];
                                    string SourceE = row_Ewent.Cells[1].Value.ToString();
                                    string DestE = row_Ewent.Cells[2].Value.ToString();
                                    if ((SourceE == "Все" || SourceE == row["Source"].ToString()) &&
                                        (DestE == "Все" || DestE == row["Dest"].ToString()))
                                    {
                                        int value = (int)(byte)row["b1"];
                                        string minString = Convert.ToString(row_Ewent.Cells[3].Value.ToString());
                                        string maxString = Convert.ToString(row_Ewent.Cells[4].Value.ToString());
                                        int.TryParse(minString, out int min);
                                        int.TryParse(maxString, out int max);
                                        if (value < min || value > max)
                                        {
                                            DateTime currentTime = DateTime.Now;
                                            cell.Style.BackColor = Color.Red;
                                            listBox1.Items.Insert(0, currentTime.ToString("HH:mm:ss") + $": В потоке {name} значение {value} за диапазоном [{minString};{maxString}].");
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            dataGridView.DataSource = dataTable;
            dataGridView.Columns["TickStamp"].Width = 80;
            if (dataGridView.Columns.Contains("2=>0"))
                dataGridView.Columns["2=>0"].Width = 40;

            if (dataGridView.Columns.Contains("1=>31"))
                dataGridView.Columns["1=>31"].Width = 40;

            if (dataGridView.Columns.Contains("31=>1"))
                dataGridView.Columns["31=>1"].Width = 40;

            if (dataGridView.Columns.Contains("57=>1"))
                dataGridView.Columns["57=>1"].Width = 40;

            if (dataGridView.Columns.Contains("25=>1"))
                dataGridView.Columns["25=>1"].Width = 40;
            dataGridView.RowHeadersWidth = 30;
            DrawChart();
        }

        private void DrawChart()
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisY.IsInterlaced = true;
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                DataColumn column = dataTable.Columns[i];
                string columnName = column.ColumnName;
                Series series = new Series(columnName);
                series = chart.Series.Add(columnName);
                series.ChartType = SeriesChartType.Spline;
                series.BorderWidth = 3;
                series.Points.DataBind(dataTable.AsEnumerable(), "TickStamp", columnName, "");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Draw.Сonnection(frames);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Next();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Next();
        }
        private void Next()
        {
            if (frames != null)
            {
                int start = (int)numericUpDown_start.Value;
                int delta = (int)numericUpDown_delta.Value;
                if (start + delta < frames.Count)
                {
                    numericUpDown_start.Value = start + delta;
                    List<CANDumpData> data = frames.Skip(start).Take(delta).ToList();
                    pictureBox1.Image = Draw.Сonnection(data);
                    CANtodataGrid(data);
                }
                else
                {
                    delta = frames.Count - start;
                    if (delta > 0)
                    {
                        numericUpDown_start.Value = start + delta;
                        List<CANDumpData> data = frames.Skip(start).Take(delta).ToList();
                        pictureBox1.Image = Draw.Сonnection(data);
                        CANtodataGrid(data);
                    }
                }

            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button_start.Text = "Старт";
            }
            else
            {
                timer1.Enabled = true;
                button_start.Text = "Стоп";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(numericUpDown1.Value * 1000);
        }

        private void chart_Click(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            NewFilter();
        }
        private void NewFilter()
        {
            var Row = new DataGridViewRow();
            var InCell = new DataGridViewComboBoxCell();
            InCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            InCell.Items.Add("Все");
            string[] STREAMS = new string[] { "0", "1", "2", "25", "31", "57" };
            foreach (var s in STREAMS)
                InCell.Items.Add(s);
            InCell.Value = InCell.Items[0];

            var OutCell = new DataGridViewComboBoxCell();
            OutCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            OutCell.Items.Add("Все");
            foreach (var s in STREAMS)
                OutCell.Items.Add(s);
            OutCell.Value = OutCell.Items[0];

            var CheckCell = new DataGridViewCheckBoxCell();
            CheckCell.Value = true;
            Row.Cells.AddRange(CheckCell, InCell, OutCell, new DataGridViewButtonCell() { Value = "Удалить" });

            dataGridView_Filter.Rows.Add(Row);
        }

        private void NewEvent()
        {
            var Row = new DataGridViewRow();
            var InCell = new DataGridViewComboBoxCell();
            InCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            InCell.Items.Add("Все");
            string[] STREAMS = new string[] { "0", "1", "2", "25", "31", "57" };
            foreach (var s in STREAMS)
                InCell.Items.Add(s);
            InCell.Value = InCell.Items[0];

            var OutCell = new DataGridViewComboBoxCell();
            OutCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            OutCell.Items.Add("Все");
            foreach (var s in STREAMS)
                OutCell.Items.Add(s);
            OutCell.Value = OutCell.Items[0];


            var MinCell = new DataGridViewTextBoxCell();
            MinCell.Value = 0;
            var MaxCell = new DataGridViewTextBoxCell();
            MaxCell.Value = 255;
            var infoColumn = new DataGridViewTextBoxCell();


            var CheckCell = new DataGridViewCheckBoxCell();
            CheckCell.Value = true;
            Row.Cells.AddRange(CheckCell, InCell, OutCell, MinCell, MaxCell, infoColumn, new DataGridViewButtonCell() { Value = "Удалить" });
            infoColumn.ReadOnly = true;
            dataGridView_Event.Rows.Add(Row);
        }
        private void CreateRuleDataGrid()
        {
            dataGridView_Filter.Rows.Clear();
            dataGridView_Filter.Columns.Clear();
            string[] HeaderNames = { "Активно", "Источник", "Приемник", "" };

            foreach (var name in HeaderNames)
            {
                DataGridViewColumn Column = new DataGridViewColumn
                {
                    CellTemplate = new DataGridViewTextBoxCell(),
                    HeaderText = name
                };

                dataGridView_Filter.Columns.Add(Column);
            }

            for (int i = 0; i < dataGridView_Filter.Columns.Count; i++)
            {
                dataGridView_Filter.Columns[i].Width = 60;
            }
        }

        private void CreateEventDataGrid()
        {
            dataGridView_Event.Rows.Clear();
            dataGridView_Event.Columns.Clear();
            string[] HeaderNames = { "Активно", "Источник", "Приемник", "Минимум", "Максимум", "Лампа", "" };

            foreach (var name in HeaderNames)
            {
                DataGridViewColumn Column = new DataGridViewColumn
                {
                    CellTemplate = new DataGridViewTextBoxCell(),
                    HeaderText = name
                };

                dataGridView_Event.Columns.Add(Column);
            }

            for (int i = 0; i < dataGridView_Event.Columns.Count; i++)
            {
                dataGridView_Event.Columns[i].Width = 60;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateRuleDataGrid();
            CreateEventDataGrid();
            NewFilter();
        }

        private void dataGridView_Filter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Filter.Columns.Count - 1 && e.RowIndex >= 0)
            {
                dataGridView_Filter.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void buttonEvent_Click(object sender, EventArgs e)
        {
            NewEvent();
        }

        private void dataGridView_Event_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Event.Columns.Count - 1 && e.RowIndex >= 0)
            {
                dataGridView_Event.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView_Event_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int value))
                {
                    e.Cancel = true;
                    dataGridView_Event.Rows[e.RowIndex].ErrorText = "Введите целое число.";
                }
                else
                {
                    if (value >= 0 && value <= 255)
                    {
                        dataGridView_Event.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    else
                    {
                        e.Cancel = true;
                        dataGridView_Event.Rows[e.RowIndex].ErrorText = "Введите число от 0 до 255.";
                    }

                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataGridView.DataSource = dataTable;

        }

        private void numericUpDown_start_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button_IP_lidar_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            byte Dest = byte.Parse(TextBoxDest.Text);
            byte SourceAddress = byte.Parse(TextBoxSource.Text);
            byte Value = byte.Parse(TextBoxValue.Text);
            byte[] bytes = BuildCANDumpRawPacket((UInt32)currentTime.Ticks, Dest, SourceAddress, Value);

            int port = int.Parse(textBox_Port.Text);
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Send(bytes, bytes.Length, textBox_IP.Text, port);
                string text = "";
                foreach (byte b in bytes)
                {
                    text += b.ToString();
                }
                string hexValue = BitConverter.ToString(bytes);
                listBox2.Items.Insert(0, hexValue);
            }
            catch (Exception ex)
            {
                listBox2.Items.Insert(0, "Ошибка отправки.");
            }
            finally
            {
                udpClient.Close();
            }

        }

        private byte[] BuildCANDumpRawPacket(UInt32 TickStamp, byte Dest, byte SourceAddress, byte b1)
        {
            byte[] rawdata = new byte[19];  // time (4) + prefix (1) + format + dest + source + DLC + body (8) + delim (2) = 19 bytes length

            CANDumpData CANPacket = new CANDumpData();
            CANPacket.TickStamp = TickStamp;
            CANPacket.Dest = Dest;
            CANPacket.Source = SourceAddress;
            CANPacket.b1 = b1;

            byte[] bytes = BitConverter.GetBytes(CANPacket.TickStamp);

            rawdata[0] = bytes[0];
            rawdata[1] = bytes[1];
            rawdata[2] = bytes[2];
            rawdata[3] = bytes[3];
            rawdata[4] = CANPacket.Prefix;
            rawdata[5] = CANPacket.Format;
            rawdata[6] = CANPacket.Dest;
            rawdata[7] = CANPacket.Source;
            rawdata[8] = CANPacket.DLC;
            rawdata[9] = CANPacket.b1;
            rawdata[10] = CANPacket.b2;
            rawdata[11] = CANPacket.b3;
            rawdata[12] = CANPacket.b4;
            rawdata[13] = CANPacket.b5;
            rawdata[14] = CANPacket.b6;
            rawdata[15] = CANPacket.b7;
            rawdata[16] = CANPacket.b8;
            rawdata[17] = 255;
            rawdata[18] = 255;

            return rawdata;
        }

        private void TextBoxSource_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int value;

            if (!int.TryParse(textBox.Text, out value) || value < 0 || value > 255)
            {
                MessageBox.Show("Введите число от 0 до 255.");
                e.Cancel = true;
            }
        }

        private void TextBoxValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int value;

            if (!int.TryParse(textBox.Text, out value))
            {
                MessageBox.Show("Введите число.");
                e.Cancel = true;
            }
        }
    }
}
