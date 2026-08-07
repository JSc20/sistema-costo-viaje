namespace sistema_costo_viaje.View
{
    partial class Menú_Vehículos
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
            tabPage1 = new TabPage();
            BtnEliminarVehiculo = new Button();
            BtnEditarVehiculo = new Button();
            BtnGuardarVehículo = new Button();
            DgvListaDeListaVehiculos = new DataGridView();
            label4 = new Label();
            TextBoxKmActualVehiculo = new TextBox();
            TextBoxModeloVehiculo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Vehiculos = new TabControl();
            groupBox1 = new GroupBox();
            TextBoxKmXLitroRendimientoVehiculo = new TextBox();
            TextBoxTipoEntornoRendimientoVehiculo = new TextBox();
            TextBoxCostoXKmRendimientoVehiculo = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            BtnEliminarRendimientoVehiculo = new Button();
            BtnEditarRendimientoVehiculo = new Button();
            BtnGuardarRendimientoVehiculo = new Button();
            DgvListaRendimientoVehiculo = new DataGridView();
            groupBox2 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            TextBoxCostoRealXKmMantenimientoVehiculo = new TextBox();
            TextBoxIntervaloXKmMantenimientoVehiculo = new TextBox();
            TextBoxCostoTotalMantenimientoVehiculo = new TextBox();
            TextBoxDescripcionMantenimientoVehiculo = new TextBox();
            label9 = new Label();
            label8 = new Label();
            BtnEliminarMantenimientoVehiculo = new Button();
            BtnEditarMantenimientoVehiculo = new Button();
            BtnGuardarMantenimientoVehiculo = new Button();
            DgvListaMantenimientoVehiculo = new DataGridView();
            CheckListBoxRendimientoVehiculo = new CheckedListBox();
            CheckListBoxMantenimientoVehiculo = new CheckedListBox();
            label12 = new Label();
            label13 = new Label();
            ComboBoxVehiculoRendimiento = new ComboBox();
            ComboBoxVehiculoMantenimiento = new ComboBox();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaDeListaVehiculos).BeginInit();
            Vehiculos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaRendimientoVehiculo).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaMantenimientoVehiculo).BeginInit();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(CheckListBoxMantenimientoVehiculo);
            tabPage1.Controls.Add(CheckListBoxRendimientoVehiculo);
            tabPage1.Controls.Add(BtnEliminarVehiculo);
            tabPage1.Controls.Add(BtnEditarVehiculo);
            tabPage1.Controls.Add(BtnGuardarVehículo);
            tabPage1.Controls.Add(DgvListaDeListaVehiculos);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(TextBoxKmActualVehiculo);
            tabPage1.Controls.Add(TextBoxModeloVehiculo);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(653, 305);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Vehículo";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // BtnEliminarVehiculo
            // 
            BtnEliminarVehiculo.Location = new Point(522, 245);
            BtnEliminarVehiculo.Name = "BtnEliminarVehiculo";
            BtnEliminarVehiculo.Size = new Size(120, 35);
            BtnEliminarVehiculo.TabIndex = 9;
            BtnEliminarVehiculo.Text = "Eliminar";
            BtnEliminarVehiculo.UseVisualStyleBackColor = true;
            BtnEliminarVehiculo.Click += BtnEliminarVehiculo_Click;
            // 
            // BtnEditarVehiculo
            // 
            BtnEditarVehiculo.Location = new Point(522, 204);
            BtnEditarVehiculo.Name = "BtnEditarVehiculo";
            BtnEditarVehiculo.Size = new Size(120, 35);
            BtnEditarVehiculo.TabIndex = 9;
            BtnEditarVehiculo.Text = "Editar";
            BtnEditarVehiculo.UseVisualStyleBackColor = true;
            BtnEditarVehiculo.Click += BtnEditarVehiculo_Click;
            // 
            // BtnGuardarVehículo
            // 
            BtnGuardarVehículo.Location = new Point(522, 163);
            BtnGuardarVehículo.Name = "BtnGuardarVehículo";
            BtnGuardarVehículo.Size = new Size(120, 35);
            BtnGuardarVehículo.TabIndex = 9;
            BtnGuardarVehículo.Text = "Guardar";
            BtnGuardarVehículo.UseVisualStyleBackColor = true;
            BtnGuardarVehículo.Click += BtnGuardarVehiculo_Click;
            // 
            // DgvListaDeListaVehiculos
            // 
            DgvListaDeListaVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaDeListaVehiculos.Location = new Point(8, 163);
            DgvListaDeListaVehiculos.Name = "DgvListaDeListaVehiculos";
            DgvListaDeListaVehiculos.Size = new Size(494, 136);
            DgvListaDeListaVehiculos.TabIndex = 8;
            DgvListaDeListaVehiculos.CellClick += DgvListaDeListaVehiculos_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 87);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 7;
            label4.Text = "Mantenimiento:";
            label4.Click += label4_Click;
            // 
            // TextBoxKmActualVehiculo
            // 
            TextBoxKmActualVehiculo.Location = new Point(116, 59);
            TextBoxKmActualVehiculo.Name = "TextBoxKmActualVehiculo";
            TextBoxKmActualVehiculo.Size = new Size(119, 23);
            TextBoxKmActualVehiculo.TabIndex = 3;
            TextBoxKmActualVehiculo.TextChanged += textBox1_TextChanged;
            // 
            // TextBoxModeloVehiculo
            // 
            TextBoxModeloVehiculo.Location = new Point(65, 21);
            TextBoxModeloVehiculo.Name = "TextBoxModeloVehiculo";
            TextBoxModeloVehiculo.Size = new Size(170, 23);
            TextBoxModeloVehiculo.TabIndex = 3;
            TextBoxModeloVehiculo.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 21);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 2;
            label3.Text = "Rendimiento:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 59);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 4;
            label2.Text = "Kilometraje actual:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 2;
            label1.Text = "Modelo:";
            label1.Click += label1_Click;
            // 
            // Vehiculos
            // 
            Vehiculos.Controls.Add(tabPage1);
            Vehiculos.Location = new Point(4, 272);
            Vehiculos.Name = "Vehiculos";
            Vehiculos.SelectedIndex = 0;
            Vehiculos.Size = new Size(661, 333);
            Vehiculos.TabIndex = 1;
            Vehiculos.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ComboBoxVehiculoRendimiento);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(TextBoxKmXLitroRendimientoVehiculo);
            groupBox1.Controls.Add(TextBoxTipoEntornoRendimientoVehiculo);
            groupBox1.Controls.Add(TextBoxCostoXKmRendimientoVehiculo);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(BtnEliminarRendimientoVehiculo);
            groupBox1.Controls.Add(BtnEditarRendimientoVehiculo);
            groupBox1.Controls.Add(BtnGuardarRendimientoVehiculo);
            groupBox1.Controls.Add(DgvListaRendimientoVehiculo);
            groupBox1.Location = new Point(4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 249);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rendimiento";
            groupBox1.Visible = true;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 23);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 11;
            label12.Text = "Vehículo:";
            // 
            // ComboBoxVehiculoRendimiento
            // 
            ComboBoxVehiculoRendimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxVehiculoRendimiento.FormattingEnabled = true;
            ComboBoxVehiculoRendimiento.Location = new Point(64, 20);
            ComboBoxVehiculoRendimiento.Name = "ComboBoxVehiculoRendimiento";
            ComboBoxVehiculoRendimiento.Size = new Size(171, 23);
            ComboBoxVehiculoRendimiento.TabIndex = 13;
            // 
            // TextBoxKmXLitroRendimientoVehiculo
            // 
            TextBoxKmXLitroRendimientoVehiculo.Location = new Point(74, 123);
            TextBoxKmXLitroRendimientoVehiculo.Name = "TextBoxKmXLitroRendimientoVehiculo";
            TextBoxKmXLitroRendimientoVehiculo.Size = new Size(142, 23);
            TextBoxKmXLitroRendimientoVehiculo.TabIndex = 10;
            // 
            // TextBoxTipoEntornoRendimientoVehiculo
            // 
            TextBoxTipoEntornoRendimientoVehiculo.Location = new Point(93, 52);
            TextBoxTipoEntornoRendimientoVehiculo.Name = "TextBoxTipoEntornoRendimientoVehiculo";
            TextBoxTipoEntornoRendimientoVehiculo.Size = new Size(123, 23);
            TextBoxTipoEntornoRendimientoVehiculo.TabIndex = 10;
            // 
            // TextBoxCostoXKmRendimientoVehiculo
            // 
            TextBoxCostoXKmRendimientoVehiculo.Location = new Point(116, 86);
            TextBoxCostoXKmRendimientoVehiculo.Name = "TextBoxCostoXKmRendimientoVehiculo";
            TextBoxCostoXKmRendimientoVehiculo.Size = new Size(100, 23);
            TextBoxCostoXKmRendimientoVehiculo.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 86);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 11;
            label7.Text = "Costo x kilometro:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 123);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 11;
            label6.Text = "Km x litro:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 52);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 11;
            label5.Text = "Tipo entorno:";
            // 
            // BtnEliminarRendimientoVehiculo
            // 
            BtnEliminarRendimientoVehiculo.Location = new Point(170, 195);
            BtnEliminarRendimientoVehiculo.Name = "BtnEliminarRendimientoVehiculo";
            BtnEliminarRendimientoVehiculo.Size = new Size(75, 23);
            BtnEliminarRendimientoVehiculo.TabIndex = 11;
            BtnEliminarRendimientoVehiculo.Text = "Eliminar";
            BtnEliminarRendimientoVehiculo.UseVisualStyleBackColor = true;
            BtnEliminarRendimientoVehiculo.Click += BtnEliminarRendimientoVehiculo_Click;
            // 
            // BtnEditarRendimientoVehiculo
            // 
            BtnEditarRendimientoVehiculo.Location = new Point(89, 195);
            BtnEditarRendimientoVehiculo.Name = "BtnEditarRendimientoVehiculo";
            BtnEditarRendimientoVehiculo.Size = new Size(75, 23);
            BtnEditarRendimientoVehiculo.TabIndex = 11;
            BtnEditarRendimientoVehiculo.Text = "Editar";
            BtnEditarRendimientoVehiculo.UseVisualStyleBackColor = true;
            BtnEditarRendimientoVehiculo.Click += BtnEditarRendimientoVehiculo_Click;
            // 
            // BtnGuardarRendimientoVehiculo
            // 
            BtnGuardarRendimientoVehiculo.Location = new Point(8, 195);
            BtnGuardarRendimientoVehiculo.Name = "BtnGuardarRendimientoVehiculo";
            BtnGuardarRendimientoVehiculo.Size = new Size(75, 23);
            BtnGuardarRendimientoVehiculo.TabIndex = 11;
            BtnGuardarRendimientoVehiculo.Text = "Guardar";
            BtnGuardarRendimientoVehiculo.UseVisualStyleBackColor = true;
            BtnGuardarRendimientoVehiculo.Click += BtnGuardarRendimientoVehiculo_Click;
            // 
            // DgvListaRendimientoVehiculo
            // 
            DgvListaRendimientoVehiculo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaRendimientoVehiculo.Location = new Point(241, 22);
            DgvListaRendimientoVehiculo.Name = "DgvListaRendimientoVehiculo";
            DgvListaRendimientoVehiculo.Size = new Size(170, 150);
            DgvListaRendimientoVehiculo.TabIndex = 0;
            DgvListaRendimientoVehiculo.CellContentClick += dataGridView2_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ComboBoxVehiculoMantenimiento);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(TextBoxCostoRealXKmMantenimientoVehiculo);
            groupBox2.Controls.Add(TextBoxIntervaloXKmMantenimientoVehiculo);
            groupBox2.Controls.Add(TextBoxCostoTotalMantenimientoVehiculo);
            groupBox2.Controls.Add(TextBoxDescripcionMantenimientoVehiculo);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(BtnEliminarMantenimientoVehiculo);
            groupBox2.Controls.Add(BtnEditarMantenimientoVehiculo);
            groupBox2.Controls.Add(BtnGuardarMantenimientoVehiculo);
            groupBox2.Controls.Add(DgvListaMantenimientoVehiculo);
            groupBox2.Location = new Point(430, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(420, 249);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mantenimiento";
            groupBox2.Visible = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 23);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 12;
            label13.Text = "Vehículo:";
            // 
            // ComboBoxVehiculoMantenimiento
            // 
            ComboBoxVehiculoMantenimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxVehiculoMantenimiento.FormattingEnabled = true;
            ComboBoxVehiculoMantenimiento.Location = new Point(64, 20);
            ComboBoxVehiculoMantenimiento.Name = "ComboBoxVehiculoMantenimiento";
            ComboBoxVehiculoMantenimiento.Size = new Size(174, 23);
            ComboBoxVehiculoMantenimiento.TabIndex = 13;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 154);
            label11.Name = "label11";
            label11.Size = new Size(91, 15);
            label11.TabIndex = 12;
            label11.Text = "Costo real x km:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 123);
            label10.Name = "label10";
            label10.Size = new Size(84, 15);
            label10.TabIndex = 12;
            label10.Text = "Intervalo x km:";
            // 
            // TextBoxCostoRealXKmMantenimientoVehiculo
            // 
            TextBoxCostoRealXKmMantenimientoVehiculo.Location = new Point(97, 154);
            TextBoxCostoRealXKmMantenimientoVehiculo.Name = "TextBoxCostoRealXKmMantenimientoVehiculo";
            TextBoxCostoRealXKmMantenimientoVehiculo.Size = new Size(114, 23);
            TextBoxCostoRealXKmMantenimientoVehiculo.TabIndex = 10;
            // 
            // TextBoxIntervaloXKmMantenimientoVehiculo
            // 
            TextBoxIntervaloXKmMantenimientoVehiculo.Location = new Point(96, 123);
            TextBoxIntervaloXKmMantenimientoVehiculo.Name = "TextBoxIntervaloXKmMantenimientoVehiculo";
            TextBoxIntervaloXKmMantenimientoVehiculo.Size = new Size(115, 23);
            TextBoxIntervaloXKmMantenimientoVehiculo.TabIndex = 10;
            // 
            // TextBoxCostoTotalMantenimientoVehiculo
            // 
            TextBoxCostoTotalMantenimientoVehiculo.Location = new Point(84, 94);
            TextBoxCostoTotalMantenimientoVehiculo.Name = "TextBoxCostoTotalMantenimientoVehiculo";
            TextBoxCostoTotalMantenimientoVehiculo.Size = new Size(127, 23);
            TextBoxCostoTotalMantenimientoVehiculo.TabIndex = 10;
            // 
            // TextBoxDescripcionMantenimientoVehiculo
            // 
            TextBoxDescripcionMantenimientoVehiculo.Location = new Point(84, 60);
            TextBoxDescripcionMantenimientoVehiculo.Name = "TextBoxDescripcionMantenimientoVehiculo";
            TextBoxDescripcionMantenimientoVehiculo.Size = new Size(127, 23);
            TextBoxDescripcionMantenimientoVehiculo.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 94);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 12;
            label9.Text = "Costo total:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 60);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 12;
            label8.Text = "Descripción:";
            // 
            // BtnEliminarMantenimientoVehiculo
            // 
            BtnEliminarMantenimientoVehiculo.Location = new Point(168, 195);
            BtnEliminarMantenimientoVehiculo.Name = "BtnEliminarMantenimientoVehiculo";
            BtnEliminarMantenimientoVehiculo.Size = new Size(75, 23);
            BtnEliminarMantenimientoVehiculo.TabIndex = 11;
            BtnEliminarMantenimientoVehiculo.Text = "Eliminar";
            BtnEliminarMantenimientoVehiculo.UseVisualStyleBackColor = true;
            BtnEliminarMantenimientoVehiculo.Click += BtnEliminarMantenimientoVehiculo_Click;
            // 
            // BtnEditarMantenimientoVehiculo
            // 
            BtnEditarMantenimientoVehiculo.Location = new Point(87, 195);
            BtnEditarMantenimientoVehiculo.Name = "BtnEditarMantenimientoVehiculo";
            BtnEditarMantenimientoVehiculo.Size = new Size(75, 23);
            BtnEditarMantenimientoVehiculo.TabIndex = 11;
            BtnEditarMantenimientoVehiculo.Text = "Editar";
            BtnEditarMantenimientoVehiculo.UseVisualStyleBackColor = true;
            BtnEditarMantenimientoVehiculo.Click += BtnEditarMantenimientoVehiculo_Click;
            // 
            // BtnGuardarMantenimientoVehiculo
            // 
            BtnGuardarMantenimientoVehiculo.Location = new Point(6, 195);
            BtnGuardarMantenimientoVehiculo.Name = "BtnGuardarMantenimientoVehiculo";
            BtnGuardarMantenimientoVehiculo.Size = new Size(75, 23);
            BtnGuardarMantenimientoVehiculo.TabIndex = 11;
            BtnGuardarMantenimientoVehiculo.Text = "Guardar";
            BtnGuardarMantenimientoVehiculo.UseVisualStyleBackColor = true;
            BtnGuardarMantenimientoVehiculo.Click += BtnGuardarMantenimientoVehiculo_Click;
            // 
            // DgvListaMantenimientoVehiculo
            // 
            DgvListaMantenimientoVehiculo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaMantenimientoVehiculo.Location = new Point(244, 22);
            DgvListaMantenimientoVehiculo.Name = "DgvListaMantenimientoVehiculo";
            DgvListaMantenimientoVehiculo.Size = new Size(170, 150);
            DgvListaMantenimientoVehiculo.TabIndex = 0;
            DgvListaMantenimientoVehiculo.CellContentClick += dataGridView2_CellContentClick;
            // 
            // CheckListBoxRendimientoVehiculo
            // 
            CheckListBoxRendimientoVehiculo.FormattingEnabled = true;
            CheckListBoxRendimientoVehiculo.Items.AddRange(new object[] { "Rendimiento 1" });
            CheckListBoxRendimientoVehiculo.Location = new Point(453, 21);
            CheckListBoxRendimientoVehiculo.Name = "CheckListBoxRendimientoVehiculo";
            CheckListBoxRendimientoVehiculo.Size = new Size(120, 94);
            CheckListBoxRendimientoVehiculo.TabIndex = 10;
            CheckListBoxRendimientoVehiculo.SelectedIndexChanged += CheckListBoxRendimientoVehiculo_SelectedIndexChanged;
            // 
            // CheckListBoxMantenimientoVehiculo
            // 
            CheckListBoxMantenimientoVehiculo.FormattingEnabled = true;
            CheckListBoxMantenimientoVehiculo.Items.AddRange(new object[] { "Mantenimiento 1" });
            CheckListBoxMantenimientoVehiculo.Location = new Point(106, 88);
            CheckListBoxMantenimientoVehiculo.Name = "CheckListBoxMantenimientoVehiculo";
            CheckListBoxMantenimientoVehiculo.Size = new Size(129, 58);
            CheckListBoxMantenimientoVehiculo.TabIndex = 11;
            // 
            // Menú_Vehículos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 614);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Vehiculos);
            Name = "Menú_Vehículos";
            ShowInTaskbar = false;
            Text = "Gestión de Vehículos ";
            Load += Menú_Vehículos_Load;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaDeListaVehiculos).EndInit();
            Vehiculos.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaRendimientoVehiculo).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvListaMantenimientoVehiculo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage1;
        private Button BtnEditarVehiculo;
        private Button BtnGuardarVehículo;
        private DataGridView DgvListaDeListaVehiculos;
        private Label label4;
        private TextBox TextBoxKmActualVehiculo;
        private TextBox TextBoxModeloVehiculo;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl Vehiculos;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView DgvListaRendimientoVehiculo;
        private DataGridView DgvListaMantenimientoVehiculo;
        private Button BtnGuardarRendimientoVehiculo;
        private Button BtnEliminarRendimientoVehiculo;
        private Button BtnEditarRendimientoVehiculo;
        private Button BtnEliminarMantenimientoVehiculo;
        private Button BtnEditarMantenimientoVehiculo;
        private Button BtnGuardarMantenimientoVehiculo;
        private Label label5;
        private TextBox TextBoxKmXLitroRendimientoVehiculo;
        private TextBox TextBoxCostoXKmRendimientoVehiculo;
        private TextBox TextBoxDescripcionMantenimientoVehiculo;
        private Label label7;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label11;
        private Label label10;
        private TextBox TextBoxCostoTotalMantenimientoVehiculo;
        private TextBox TextBoxCostoRealXKmMantenimientoVehiculo;
        private TextBox TextBoxIntervaloXKmMantenimientoVehiculo;
        private Button BtnEliminarVehiculo;
        private TextBox TextBoxTipoEntornoRendimientoVehiculo;
        private CheckedListBox CheckListBoxMantenimientoVehiculo;
        private CheckedListBox CheckListBoxRendimientoVehiculo;
        private Label label12;
        private Label label13;
        private ComboBox ComboBoxVehiculoRendimiento;
        private ComboBox ComboBoxVehiculoMantenimiento;
    }
}