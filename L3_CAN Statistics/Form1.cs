using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
                    //dataGridView1.DataSource = dataTable(frames);
                    CANdataTable = Data.TableFromCAN(frames);
                    dataTable = new DataTable();
                    dataTable.Columns.Add("TickStamp", typeof(UInt32));
                    // Получаем все уникальные значения столбца "Name"
                    var uniqueNames = CANdataTable.AsEnumerable().Select(row => row.Field<UInt32>("TickStamp")).Distinct();
                    foreach (UInt32 time in uniqueNames)
                    {
                        DataRow[] rows = CANdataTable.Select($"TickStamp = '" + time + "'");

                        DataRow newRow = dataTable.NewRow();
                        newRow["TickStamp"] = time;
                        foreach (DataRow row in rows)
                        {
                            string name = row["Source"] + "=>" + row["Dest"];
                            if (!dataTable.Columns.Contains(name))
                            {
                                dataTable.Columns.Add(name, typeof(byte));
                            }
                            newRow[name] = row["b1"];
                        }
                        dataTable.Rows.Add(newRow);
                    }
                    dataGridView.DataSource = dataTable;
                    dataGridView.Columns["TickStamp"].Width = 80;
                    dataGridView.Columns["2=>0"].Width = 40;
                    dataGridView.Columns["1=>31"].Width = 40;
                    dataGridView.Columns["31=>1"].Width = 40;
                    dataGridView.Columns["57=>1"].Width = 40;
                    dataGridView.Columns["25=>1"].Width = 40;
                    dataGridView.RowHeadersWidth = 30;
                    // DrawCAN(frames);

                }
            }
            pictureBox1.Image = Draw.Сonnection(frames);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image= Draw.Сonnection(frames);
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
            if (frames.Count != 0)
            {
                int start = (int)numericUpDown_start.Value;
                int delta = (int)numericUpDown_delta.Value;
                if (start + delta < frames.Count)
                {
                    numericUpDown_start.Value = start + delta;
                    pictureBox1.Image = Draw.Сonnection(frames.Skip(start).Take(delta).ToList());
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
    }
}
