namespace L3_CAN_Statistics
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_delta = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_start = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_start = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.dataGridView_Filter = new System.Windows.Forms.DataGridView();
            this.buttonEvent = new System.Windows.Forms.Button();
            this.dataGridView_Event = new System.Windows.Forms.DataGridView();
            this.buttonReset = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_IP_lidar = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TextBoxValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBoxDest = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxSource = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.comboBox_node = new System.Windows.Forms.ComboBox();
            this.label_in = new System.Windows.Forms.Label();
            this.label_out = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Event)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 519);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(131, 26);
            this.buttonLoad.TabIndex = 79;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(330, 498);
            this.dataGridView.TabIndex = 109;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(350, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 555);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 117;
            this.label8.Text = "Начальный пакет";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "Пакетов";
            // 
            // numericUpDown_delta
            // 
            this.numericUpDown_delta.Location = new System.Drawing.Point(68, 551);
            this.numericUpDown_delta.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDown_delta.Name = "numericUpDown_delta";
            this.numericUpDown_delta.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_delta.TabIndex = 115;
            // 
            // numericUpDown_start
            // 
            this.numericUpDown_start.Location = new System.Drawing.Point(232, 551);
            this.numericUpDown_start.Maximum = new decimal(new int[] {
            1783793664,
            116,
            0,
            0});
            this.numericUpDown_start.Name = "numericUpDown_start";
            this.numericUpDown_start.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_start.TabIndex = 114;
            this.numericUpDown_start.ValueChanged += new System.EventHandler(this.numericUpDown_start_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(510, 553);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 148;
            this.label20.Text = "Задержка";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(578, 549);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 147;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(389, 548);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(111, 23);
            this.button_start.TabIndex = 146;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(304, 548);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 145;
            this.button_next.Text = "Next";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(696, 238);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(759, 333);
            this.chart.TabIndex = 149;
            this.chart.Text = "chart";
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(556, 12);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(98, 26);
            this.buttonFilter.TabIndex = 150;
            this.buttonFilter.Text = "Новый фильтр";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // dataGridView_Filter
            // 
            this.dataGridView_Filter.AllowUserToAddRows = false;
            this.dataGridView_Filter.AllowUserToDeleteRows = false;
            this.dataGridView_Filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Filter.Location = new System.Drawing.Point(660, 12);
            this.dataGridView_Filter.Name = "dataGridView_Filter";
            this.dataGridView_Filter.Size = new System.Drawing.Size(305, 107);
            this.dataGridView_Filter.TabIndex = 151;
            this.dataGridView_Filter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Filter_CellContentClick);
            // 
            // buttonEvent
            // 
            this.buttonEvent.Location = new System.Drawing.Point(556, 44);
            this.buttonEvent.Name = "buttonEvent";
            this.buttonEvent.Size = new System.Drawing.Size(98, 26);
            this.buttonEvent.TabIndex = 152;
            this.buttonEvent.Text = "Новое событие";
            this.buttonEvent.UseVisualStyleBackColor = true;
            this.buttonEvent.Click += new System.EventHandler(this.buttonEvent_Click);
            // 
            // dataGridView_Event
            // 
            this.dataGridView_Event.AllowUserToAddRows = false;
            this.dataGridView_Event.AllowUserToDeleteRows = false;
            this.dataGridView_Event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Event.Location = new System.Drawing.Point(556, 125);
            this.dataGridView_Event.Name = "dataGridView_Event";
            this.dataGridView_Event.Size = new System.Drawing.Size(485, 107);
            this.dataGridView_Event.TabIndex = 153;
            this.dataGridView_Event.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Event_CellContentClick);
            this.dataGridView_Event.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_Event_CellValidating);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(149, 516);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(131, 26);
            this.buttonReset.TabIndex = 154;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(350, 233);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(340, 277);
            this.listBox1.TabIndex = 155;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 26);
            this.button1.TabIndex = 156;
            this.button1.Text = "Очистка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_IP_lidar
            // 
            this.button_IP_lidar.Location = new System.Drawing.Point(971, 44);
            this.button_IP_lidar.Name = "button_IP_lidar";
            this.button_IP_lidar.Size = new System.Drawing.Size(159, 54);
            this.button_IP_lidar.TabIndex = 159;
            this.button_IP_lidar.Text = "Отправить";
            this.button_IP_lidar.UseVisualStyleBackColor = true;
            this.button_IP_lidar.Click += new System.EventHandler(this.button_IP_lidar_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(1061, 18);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(69, 20);
            this.textBox_Port.TabIndex = 158;
            this.textBox_Port.Text = "2368";
            this.textBox_Port.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValue_Validating);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(986, 18);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(69, 20);
            this.textBox_IP.TabIndex = 157;
            this.textBox_IP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(971, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "ip";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1052, 183);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 166;
            this.label13.Text = "Значение";
            // 
            // TextBoxValue
            // 
            this.TextBoxValue.Location = new System.Drawing.Point(1054, 198);
            this.TextBoxValue.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(76, 20);
            this.TextBoxValue.TabIndex = 165;
            this.TextBoxValue.Text = "100";
            this.TextBoxValue.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxSource_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1052, 146);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 164;
            this.label12.Text = "Приемник";
            // 
            // TextBoxDest
            // 
            this.TextBoxDest.Location = new System.Drawing.Point(1054, 162);
            this.TextBoxDest.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxDest.Name = "TextBoxDest";
            this.TextBoxDest.Size = new System.Drawing.Size(76, 20);
            this.TextBoxDest.TabIndex = 163;
            this.TextBoxDest.Text = "2";
            this.TextBoxDest.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxSource_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1052, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 162;
            this.label11.Text = "Источник";
            // 
            // TextBoxSource
            // 
            this.TextBoxSource.Location = new System.Drawing.Point(1054, 125);
            this.TextBoxSource.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxSource.Name = "TextBoxSource";
            this.TextBoxSource.Size = new System.Drawing.Size(76, 20);
            this.TextBoxSource.TabIndex = 161;
            this.TextBoxSource.Text = "1";
            this.TextBoxSource.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxSource_Validating);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(1135, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(320, 212);
            this.listBox2.TabIndex = 167;
            // 
            // comboBox_node
            // 
            this.comboBox_node.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_node.FormattingEnabled = true;
            this.comboBox_node.Location = new System.Drawing.Point(559, 77);
            this.comboBox_node.Name = "comboBox_node";
            this.comboBox_node.Size = new System.Drawing.Size(95, 21);
            this.comboBox_node.TabIndex = 168;
            this.comboBox_node.SelectedValueChanged += new System.EventHandler(this.comboBox_node_SelectedValueChanged);
            // 
            // label_in
            // 
            this.label_in.AutoSize = true;
            this.label_in.Location = new System.Drawing.Point(556, 106);
            this.label_in.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_in.Name = "label_in";
            this.label_in.Size = new System.Drawing.Size(19, 13);
            this.label_in.TabIndex = 169;
            this.label_in.Text = "In:";
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(609, 106);
            this.label_out.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(27, 13);
            this.label_out.TabIndex = 170;
            this.label_out.Text = "Out:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 577);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.label_in);
            this.Controls.Add(this.comboBox_node);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TextBoxValue);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TextBoxDest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TextBoxSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_IP_lidar);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.dataGridView_Event);
            this.Controls.Add(this.buttonEvent);
            this.Controls.Add(this.dataGridView_Filter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_delta);
            this.Controls.Add(this.numericUpDown_start);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Event)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_delta;
        private System.Windows.Forms.NumericUpDown numericUpDown_start;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.DataGridView dataGridView_Filter;
        private System.Windows.Forms.Button buttonEvent;
        private System.Windows.Forms.DataGridView dataGridView_Event;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_IP_lidar;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TextBoxValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextBoxDest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxSource;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ComboBox comboBox_node;
        private System.Windows.Forms.Label label_in;
        private System.Windows.Forms.Label label_out;
    }
}

