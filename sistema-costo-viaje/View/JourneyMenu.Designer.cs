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
            DateTimePickerViajes = new DateTimePicker();
            DateTimePickerViaje = new DateTimePicker();
            BtnGuardarViaje = new Button();
            label9 = new Label();
            label8 = new Label();
            DgvDesglosePrecioSoloDelCombustible = new DataGridView();
            DgvDesglosePrecioTotal = new DataGridView();
            textBox1 = new TextBox();
            CheckListViaticoViaje = new CheckedListBox();
            ComboBoxCombustibleViaje = new ComboBox();
            ComboBoxDestinoViaje = new ComboBox();
            label7 = new Label();
            ComboBoxVehículoViaje = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            BtnEliminarViaje = new Button();
            BtnEditarViaje = new Button();
            BtnExportarRegistro = new Button();
            label12 = new Label();
            label11 = new Label();
            DgvDesglosePrecioSoloDelCombustibleGuardado = new DataGridView();
            DgvDesglosePrecioTotalGuardados = new DataGridView();
            CheckListBoxViaje = new CheckedListBox();
            label10 = new Label();
            label6 = new Label();
            ComboBoxTecnicosDeViaje = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioSoloDelCombustible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioTotal).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioSoloDelCombustibleGuardado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioTotalGuardados).BeginInit();
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
            tabPage1.Controls.Add(ComboBoxTecnicosDeViaje);
            tabPage1.Controls.Add(DateTimePickerViajes);
            tabPage1.Controls.Add(DateTimePickerViaje);
            tabPage1.Controls.Add(BtnGuardarViaje);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(DgvDesglosePrecioSoloDelCombustible);
            tabPage1.Controls.Add(DgvDesglosePrecioTotal);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(CheckListViaticoViaje);
            tabPage1.Controls.Add(ComboBoxCombustibleViaje);
            tabPage1.Controls.Add(ComboBoxDestinoViaje);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(ComboBoxVehículoViaje);
            tabPage1.Controls.Add(label6);
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
            // DateTimePickerViajes
            // 
            DateTimePickerViajes.Format = DateTimePickerFormat.Short;
            DateTimePickerViajes.Location = new Point(58, 14);
            DateTimePickerViajes.Name = "DateTimePickerViajes";
            DateTimePickerViajes.Size = new Size(185, 23);
            DateTimePickerViajes.TabIndex = 10;
            // 
            // DateTimePickerViaje
            // 
            DateTimePickerViaje.Format = DateTimePickerFormat.Short;
            DateTimePickerViaje.Location = new Point(58, -115);
            DateTimePickerViaje.Name = "DateTimePickerViaje";
            DateTimePickerViaje.Size = new Size(95, 23);
            DateTimePickerViaje.TabIndex = 9;
            // 
            // BtnGuardarViaje
            // 
            BtnGuardarViaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarViaje.Location = new Point(933, 494);
            BtnGuardarViaje.Name = "BtnGuardarViaje";
            BtnGuardarViaje.Size = new Size(195, 35);
            BtnGuardarViaje.TabIndex = 8;
            BtnGuardarViaje.Text = "Guardar viaje";
            BtnGuardarViaje.UseVisualStyleBackColor = false;
            BtnGuardarViaje.Click += BtnGuardarViaje_Click;
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
            // DgvDesglosePrecioSoloDelCombustible
            // 
            DgvDesglosePrecioSoloDelCombustible.BackgroundColor = SystemColors.ButtonHighlight;
            DgvDesglosePrecioSoloDelCombustible.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDesglosePrecioSoloDelCombustible.Location = new Point(586, 32);
            DgvDesglosePrecioSoloDelCombustible.Name = "DgvDesglosePrecioSoloDelCombustible";
            DgvDesglosePrecioSoloDelCombustible.Size = new Size(540, 210);
            DgvDesglosePrecioSoloDelCombustible.TabIndex = 5;
            // 
            // DgvDesglosePrecioTotal
            // 
            DgvDesglosePrecioTotal.BackgroundColor = SystemColors.ButtonHighlight;
            DgvDesglosePrecioTotal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDesglosePrecioTotal.Location = new Point(586, 263);
            DgvDesglosePrecioTotal.Name = "DgvDesglosePrecioTotal";
            DgvDesglosePrecioTotal.Size = new Size(540, 210);
            DgvDesglosePrecioTotal.TabIndex = 5;
            DgvDesglosePrecioTotal.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 328);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox2_TextChanged;
            // 
            // CheckListViaticoViaje
            // 
            CheckListViaticoViaje.FormattingEnabled = true;
            CheckListViaticoViaje.Items.AddRange(new object[] { "Vático1" });
            CheckListViaticoViaje.Location = new Point(72, 170);
            CheckListViaticoViaje.Name = "CheckListViaticoViaje";
            CheckListViaticoViaje.Size = new Size(171, 94);
            CheckListViaticoViaje.TabIndex = 3;
            CheckListViaticoViaje.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
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
            ComboBoxDestinoViaje.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 328);
            label7.Name = "label7";
            label7.Size = new Size(126, 15);
            label7.TabIndex = 1;
            label7.Text = "Ferri (Ingrese el costo):";
            label7.Click += label1_Click;
            // 
            // ComboBoxVehículoViaje
            // 
            ComboBoxVehículoViaje.FormattingEnabled = true;
            ComboBoxVehículoViaje.Location = new Point(72, 81);
            ComboBoxVehículoViaje.Name = "ComboBoxVehículoViaje";
            ComboBoxVehículoViaje.Size = new Size(171, 23);
            ComboBoxVehículoViaje.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 170);
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
            tabPage2.Controls.Add(BtnEliminarViaje);
            tabPage2.Controls.Add(BtnEditarViaje);
            tabPage2.Controls.Add(BtnExportarRegistro);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(DgvDesglosePrecioSoloDelCombustibleGuardado);
            tabPage2.Controls.Add(DgvDesglosePrecioTotalGuardados);
            tabPage2.Controls.Add(CheckListBoxViaje);
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
            // BtnEliminarViaje
            // 
            BtnEliminarViaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnEliminarViaje.Location = new Point(991, 500);
            BtnEliminarViaje.Name = "BtnEliminarViaje";
            BtnEliminarViaje.Size = new Size(150, 35);
            BtnEliminarViaje.TabIndex = 3;
            BtnEliminarViaje.Text = "Editar Viaje";
            BtnEliminarViaje.UseVisualStyleBackColor = false;
            BtnEliminarViaje.Click += BtnEliminarViaje_Click;
            // 
            // BtnEditarViaje
            // 
            BtnEditarViaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarViaje.Location = new Point(835, 500);
            BtnEditarViaje.Name = "BtnEditarViaje";
            BtnEditarViaje.Size = new Size(150, 35);
            BtnEditarViaje.TabIndex = 3;
            BtnEditarViaje.Text = "Editar Viaje";
            BtnEditarViaje.UseVisualStyleBackColor = false;
            BtnEditarViaje.Click += BtnEditarViaje_Click;
            // 
            // BtnExportarRegistro
            // 
            BtnExportarRegistro.BackColor = Color.FromArgb(97, 97, 96);
            BtnExportarRegistro.Location = new Point(679, 500);
            BtnExportarRegistro.Name = "BtnExportarRegistro";
            BtnExportarRegistro.Size = new Size(150, 35);
            BtnExportarRegistro.TabIndex = 3;
            BtnExportarRegistro.Text = "Exportar Registro";
            BtnExportarRegistro.UseVisualStyleBackColor = false;
            BtnExportarRegistro.Click += BtnExportarRegistro_Click;
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
            // DgvDesglosePrecioSoloDelCombustibleGuardado
            // 
            DgvDesglosePrecioSoloDelCombustibleGuardado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDesglosePrecioSoloDelCombustibleGuardado.Location = new Point(601, 35);
            DgvDesglosePrecioSoloDelCombustibleGuardado.Name = "DgvDesglosePrecioSoloDelCombustibleGuardado";
            DgvDesglosePrecioSoloDelCombustibleGuardado.Size = new Size(540, 210);
            DgvDesglosePrecioSoloDelCombustibleGuardado.TabIndex = 1;
            // 
            // DgvDesglosePrecioTotalGuardados
            // 
            DgvDesglosePrecioTotalGuardados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDesglosePrecioTotalGuardados.Location = new Point(601, 284);
            DgvDesglosePrecioTotalGuardados.Name = "DgvDesglosePrecioTotalGuardados";
            DgvDesglosePrecioTotalGuardados.Size = new Size(540, 210);
            DgvDesglosePrecioTotalGuardados.TabIndex = 1;
            // 
            // CheckListBoxViaje
            // 
            CheckListBoxViaje.BackColor = SystemColors.AppWorkspace;
            CheckListBoxViaje.FormattingEnabled = true;
            CheckListBoxViaje.Items.AddRange(new object[] { "Viaje1" });
            CheckListBoxViaje.Location = new Point(6, 21);
            CheckListBoxViaje.Name = "CheckListBoxViaje";
            CheckListBoxViaje.Size = new Size(302, 508);
            CheckListBoxViaje.TabIndex = 1;
            CheckListBoxViaje.SelectedIndexChanged += checkedListBox3_SelectedIndexChanged;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 279);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 1;
            label6.Text = "Técnico:";
            label6.Click += label1_Click;
            // 
            // ComboBoxTecnicosDeViaje
            // 
            ComboBoxTecnicosDeViaje.FormattingEnabled = true;
            ComboBoxTecnicosDeViaje.Location = new Point(72, 276);
            ComboBoxTecnicosDeViaje.Name = "ComboBoxTecnicosDeViaje";
            ComboBoxTecnicosDeViaje.Size = new Size(171, 23);
            ComboBoxTecnicosDeViaje.TabIndex = 11;
            // 
            // JourneyMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 566);
            Controls.Add(tabControl1);
            Name = "JourneyMenu";
            Text = "Gestión de Viajes";
            Load += JourneyMenu_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioSoloDelCombustible).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioTotal).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioSoloDelCombustibleGuardado).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvDesglosePrecioTotalGuardados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DateTimePicker DateTimePickerViaje;
        private Label label1;
        private Label label2;
        private ComboBox ComboBoxVehículoViaje;
        private Label label3;
        private Label label4;
        private ComboBox ComboBoxCombustibleViaje;
        private Label label5;
        private CheckedListBox CheckListViaticoViaje;
        private DataGridView DgvDesglosePrecioSoloDelCombustible;
        private DataGridView DgvDesglosePrecioTotal;
        private Label label8;
        private Label label9;
        private Button BtnGuardarViaje;
        private Label label10;
        private CheckedListBox CheckListBoxViaje;
        private DataGridView dataGridView3;
        private DataGridView DgvDesglosePrecioTotalGuardados;
        private Label label11;
        private Label label12;
        private Button BtnExportarRegistro;
        private Button button5;
        private ComboBox ComboBoxDestinoViaje;
        private DataGridView DgvDesglosePrecioSoloDelCombustibleGuardado;
        private Button BtnEditarViaje;
        private Button BtnEliminarViaje;
        private TextBox textBox1;
        private Label label7;
        private DateTimePicker DateTimePickerViajes;
        private ComboBox ComboBoxTecnicosDeViaje;
        private Label label6;
    }
}