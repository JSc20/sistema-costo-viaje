namespace sistema_costo_viaje.View
{
    partial class JourneyMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button2 = new Button();
            label9 = new Label();
            label8 = new Label();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            TextBoxFerriViaje = new TextBox();
            CheckListViaticoViaje = new CheckedListBox();
            CheckListPeajeViaje = new CheckedListBox();
            ComboBoxCombustibleViaje = new ComboBox();
            ComboBoxDestinoViaje = new ComboBox();
            ComboBoxVehículoViaje = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            button5 = new Button();
            button1 = new Button();
            label12 = new Label();
            label11 = new Label();
            dataGridView4 = new DataGridView();
            dataGridView3 = new DataGridView();
            checkedListBox3 = new CheckedListBox();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1155, 570);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(168, 168, 168);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(dataGridView2);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(TextBoxFerriViaje);
            tabPage1.Controls.Add(CheckListViaticoViaje);
            tabPage1.Controls.Add(CheckListPeajeViaje);
            tabPage1.Controls.Add(ComboBoxCombustibleViaje);
            tabPage1.Controls.Add(ComboBoxDestinoViaje);
            tabPage1.Controls.Add(ComboBoxVehículoViaje);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1147, 542);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Crear Viaje";
            tabPage1.Click += tabPage1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(97, 97, 96);
            button2.Location = new Point(933, 494);
            button2.Name = "button2";
            button2.Size = new Size(195, 35);
            button2.TabIndex = 8;
            button2.Text = "Guardar viaje";
            button2.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(586, 245);
            label9.Name = "label9";
            label9.Size = new Size(136, 15);
            label9.TabIndex = 6;
            label9.Text = "Desglose de precio total:";
            label9.Click += label8_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(586, 14);
            label8.Name = "label8";
            label8.Size = new Size(238, 15);
            label8.TabIndex = 6;
            label8.Text = "Desglose de precio úniamente combustible:";
            label8.Click += label8_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(586, 32);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(540, 210);
            dataGridView2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(586, 263);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(540, 210);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // TextBoxFerriViaje
            // 
            TextBoxFerriViaje.Location = new Point(143, 417);
            TextBoxFerriViaje.Name = "TextBoxFerriViaje";
            TextBoxFerriViaje.Size = new Size(100, 23);
            TextBoxFerriViaje.TabIndex = 4;
            TextBoxFerriViaje.TextChanged += textBox2_TextChanged;
            // 
            // CheckListViaticoViaje
            // 
            CheckListViaticoViaje.FormattingEnabled = true;
            CheckListViaticoViaje.Items.AddRange(new object[] { "Vático1" });
            CheckListViaticoViaje.Location = new Point(72, 293);
            CheckListViaticoViaje.Name = "CheckListViaticoViaje";
            CheckListViaticoViaje.Size = new Size(171, 94);
            CheckListViaticoViaje.TabIndex = 3;
            CheckListViaticoViaje.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // CheckListPeajeViaje
            // 
            CheckListPeajeViaje.FormattingEnabled = true;
            CheckListPeajeViaje.Items.AddRange(new object[] { "Peaje1" });
            CheckListPeajeViaje.Location = new Point(72, 175);
            CheckListPeajeViaje.Name = "CheckListPeajeViaje";
            CheckListPeajeViaje.Size = new Size(171, 94);
            CheckListPeajeViaje.TabIndex = 3;
            CheckListPeajeViaje.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // ComboBoxCombustibleViaje
            // 
            ComboBoxCombustibleViaje.FormattingEnabled = true;
            ComboBoxCombustibleViaje.Location = new Point(95, 141);
            ComboBoxCombustibleViaje.Name = "ComboBoxCombustibleViaje";
            ComboBoxCombustibleViaje.Size = new Size(148, 23);
            ComboBoxCombustibleViaje.TabIndex = 2;
            ComboBoxCombustibleViaje.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // ComboBoxDestinoViaje
            // 
            ComboBoxDestinoViaje.FormattingEnabled = true;
            ComboBoxDestinoViaje.Location = new Point(72, 112);
            ComboBoxDestinoViaje.Name = "ComboBoxDestinoViaje";
            ComboBoxDestinoViaje.Size = new Size(171, 23);
            ComboBoxDestinoViaje.TabIndex = 2;
            // 
            // ComboBoxVehículoViaje
            // 
            ComboBoxVehículoViaje.FormattingEnabled = true;
            ComboBoxVehículoViaje.Location = new Point(72, 81);
            ComboBoxVehículoViaje.Name = "ComboBoxVehículoViaje";
            ComboBoxVehículoViaje.Size = new Size(171, 23);
            ComboBoxVehículoViaje.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 417);
            label6.Name = "label6";
            label6.Size = new Size(126, 15);
            label6.TabIndex = 1;
            label6.Text = "Ferri (Ingrese el costo):";
            label6.Click += label1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 175);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 1;
            label7.Text = "Peajes:";
            label7.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 293);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 1;
            label5.Text = "Viáticos:";
            label5.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 141);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 1;
            label4.Text = "Combustible:";
            label4.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 112);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 1;
            label3.Text = "Destino:";
            label3.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 81);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Vehículo:";
            label2.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 12);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "Fecha:";
            label1.Click += label1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(dataGridView4);
            tabPage2.Controls.Add(dataGridView3);
            tabPage2.Controls.Add(checkedListBox3);
            tabPage2.Controls.Add(label10);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1147, 542);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lista de Viajes";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(97, 97, 96);
            button5.Location = new Point(946, 500);
            button5.Name = "button5";
            button5.Size = new Size(195, 35);
            button5.TabIndex = 3;
            button5.Text = "Editar Viaje";
            button5.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(97, 97, 96);
            button1.Location = new Point(736, 500);
            button1.Name = "button1";
            button1.Size = new Size(195, 35);
            button1.TabIndex = 3;
            button1.Text = "Editar Viaje";
            button1.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(601, 266);
            label12.Name = "label12";
            label12.Size = new Size(136, 15);
            label12.TabIndex = 2;
            label12.Text = "Desglose de precio total:";
            label12.Click += label11_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(601, 17);
            label11.Name = "label11";
            label11.Size = new Size(260, 15);
            label11.TabIndex = 2;
            label11.Text = "Desglose de precio únicamente de combustible:";
            label11.Click += label11_Click;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(601, 284);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(540, 210);
            dataGridView4.TabIndex = 1;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(601, 35);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(540, 210);
            dataGridView3.TabIndex = 1;
            // 
            // checkedListBox3
            // 
            checkedListBox3.BackColor = SystemColors.AppWorkspace;
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Items.AddRange(new object[] { "Viaje1" });
            checkedListBox3.Location = new Point(6, 21);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(302, 508);
            checkedListBox3.TabIndex = 1;
            checkedListBox3.SelectedIndexChanged += checkedListBox3_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 3);
            label10.Name = "label10";
            label10.Size = new Size(101, 15);
            label10.TabIndex = 0;
            label10.Text = "Viajes registrados:";
            // 
            // JourneyMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 566);
            Controls.Add(tabControl1);
            Name = "JourneyMenu";
            Text = "Gestión de Viajes";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox ComboBoxVehículoViaje;
        private Label label3;
        private Label label4;
        private ComboBox ComboBoxCombustibleViaje;
        private Label label5;
        private CheckedListBox CheckListPeajeViaje;
        private Label label6;
        private CheckedListBox CheckListViaticoViaje;
        private Label label7;
        private TextBox TextBoxFerriViaje;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private Label label8;
        private Label label9;
        private Button button2;
        private Label label10;
        private CheckedListBox checkedListBox3;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private Label label11;
        private Label label12;
        private Button button1;
        private Button button5;
        private ComboBox ComboBoxDestinoViaje;
    }
}