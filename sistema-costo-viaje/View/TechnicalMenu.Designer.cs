namespace sistema_costo_viaje.View
{
    partial class TechnicalMenu
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
            DgvListaDeTenicos = new DataGridView();
            label1 = new Label();
            TextBoxNombreTecnico = new TextBox();
            label2 = new Label();
            TextBoxSalarioTecnico = new TextBox();
            label3 = new Label();
            TextBoxHrsDeTrabajoSemanalTecnico = new TextBox();
            label4 = new Label();
            label5 = new Label();
            TextBoxCostoDeHoraOrdinariaTecnico = new TextBox();
            label6 = new Label();
            TextBoxCostoDeHoraExtraTecnica = new TextBox();
            BtnGuardarTecnico = new Button();
            BtnEliminarTecnico = new Button();
            BtnEditarTecnico = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvListaDeTenicos).BeginInit();
            SuspendLayout();
            // 
            // DgvListaDeTenicos
            // 
            DgvListaDeTenicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaDeTenicos.Location = new Point(426, 27);
            DgvListaDeTenicos.Name = "DgvListaDeTenicos";
            DgvListaDeTenicos.Size = new Size(727, 538);
            DgvListaDeTenicos.TabIndex = 0;
            DgvListaDeTenicos.CellContentClick += dataGridView1_CellContentClick;
            DgvListaDeTenicos.CellClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 161);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            label1.Click += label1_Click;
            // 
            // TextBoxNombreTecnico
            // 
            TextBoxNombreTecnico.Location = new Point(70, 161);
            TextBoxNombreTecnico.Name = "TextBoxNombreTecnico";
            TextBoxNombreTecnico.Size = new Size(195, 23);
            TextBoxNombreTecnico.TabIndex = 2;
            TextBoxNombreTecnico.TextChanged += TextBoxNombreTecnico_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 205);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Salario mensual:";
            label2.Click += label1_Click;
            // 
            // TextBoxSalarioTecnico
            // 
            TextBoxSalarioTecnico.Location = new Point(109, 205);
            TextBoxSalarioTecnico.Name = "TextBoxSalarioTecnico";
            TextBoxSalarioTecnico.Size = new Size(156, 23);
            TextBoxSalarioTecnico.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 248);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 1;
            label3.Text = "Hrs Trabajo semanal:";
            label3.Click += label1_Click;
            // 
            // TextBoxHrsDeTrabajoSemanalTecnico
            // 
            TextBoxHrsDeTrabajoSemanalTecnico.Location = new Point(133, 248);
            TextBoxHrsDeTrabajoSemanalTecnico.Name = "TextBoxHrsDeTrabajoSemanalTecnico";
            TextBoxHrsDeTrabajoSemanalTecnico.Size = new Size(132, 23);
            TextBoxHrsDeTrabajoSemanalTecnico.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(426, 9);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 3;
            label4.Text = "Lista de Técnicos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 288);
            label5.Name = "label5";
            label5.Size = new Size(134, 15);
            label5.TabIndex = 1;
            label5.Text = "Costo de hora ordinaria:";
            label5.Click += label1_Click;
            // 
            // TextBoxCostoDeHoraOrdinariaTecnico
            // 
            TextBoxCostoDeHoraOrdinariaTecnico.Location = new Point(150, 288);
            TextBoxCostoDeHoraOrdinariaTecnico.Name = "TextBoxCostoDeHoraOrdinariaTecnico";
            TextBoxCostoDeHoraOrdinariaTecnico.Size = new Size(115, 23);
            TextBoxCostoDeHoraOrdinariaTecnico.TabIndex = 2;
            TextBoxCostoDeHoraOrdinariaTecnico.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 328);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 1;
            label6.Text = "Costo de hora extra:";
            label6.Click += label1_Click;
            // 
            // TextBoxCostoDeHoraExtraTecnica
            // 
            TextBoxCostoDeHoraExtraTecnica.Location = new Point(128, 328);
            TextBoxCostoDeHoraExtraTecnica.Name = "TextBoxCostoDeHoraExtraTecnica";
            TextBoxCostoDeHoraExtraTecnica.Size = new Size(137, 23);
            TextBoxCostoDeHoraExtraTecnica.TabIndex = 2;
            TextBoxCostoDeHoraExtraTecnica.TextChanged += textBox1_TextChanged;
            // 
            // BtnGuardarTecnico
            // 
            BtnGuardarTecnico.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarTecnico.Location = new Point(11, 519);
            BtnGuardarTecnico.Name = "BtnGuardarTecnico";
            BtnGuardarTecnico.Size = new Size(125, 35);
            BtnGuardarTecnico.TabIndex = 4;
            BtnGuardarTecnico.Text = "Guardar Técnico";
            BtnGuardarTecnico.UseVisualStyleBackColor = false;
            BtnGuardarTecnico.Click += BtnGuardarTecnico_Click;
            // 
            // BtnEliminarTecnico
            // 
            BtnEliminarTecnico.BackColor = Color.FromArgb(97, 97, 96);
            BtnEliminarTecnico.Location = new Point(271, 519);
            BtnEliminarTecnico.Name = "BtnEliminarTecnico";
            BtnEliminarTecnico.Size = new Size(125, 35);
            BtnEliminarTecnico.TabIndex = 4;
            BtnEliminarTecnico.Text = "Eliminar Técnico";
            BtnEliminarTecnico.UseVisualStyleBackColor = false;
            BtnEliminarTecnico.Click += BtnEliminarTecnico_Click;
            // 
            // BtnEditarTecnico
            // 
            BtnEditarTecnico.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarTecnico.Location = new Point(140, 519);
            BtnEditarTecnico.Name = "BtnEditarTecnico";
            BtnEditarTecnico.Size = new Size(125, 35);
            BtnEditarTecnico.TabIndex = 4;
            BtnEditarTecnico.Text = "Editar Técnico";
            BtnEditarTecnico.UseVisualStyleBackColor = false;
            BtnEditarTecnico.Click += BtnEditarTecnico_Click;
            // 
            // TechnicalMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 566);
            Controls.Add(BtnEliminarTecnico);
            Controls.Add(BtnEditarTecnico);
            Controls.Add(BtnGuardarTecnico);
            Controls.Add(label4);
            Controls.Add(TextBoxCostoDeHoraExtraTecnica);
            Controls.Add(TextBoxCostoDeHoraOrdinariaTecnico);
            Controls.Add(TextBoxHrsDeTrabajoSemanalTecnico);
            Controls.Add(TextBoxSalarioTecnico);
            Controls.Add(TextBoxNombreTecnico);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DgvListaDeTenicos);
            Name = "TechnicalMenu";
            Text = "Gestión de Técnicos";
            Load += TechnicalMenu_Load;
            ((System.ComponentModel.ISupportInitialize)DgvListaDeTenicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvListaDeTenicos;
        private Label label1;
        private TextBox TextBoxNombreTecnico;
        private Label label2;
        private TextBox TextBoxSalarioTecnico;
        private Label label3;
        private TextBox TextBoxHrsDeTrabajoSemanalTecnico;
        private Label label4;
        private Label label5;
        private TextBox TextBoxCostoDeHoraOrdinariaTecnico;
        private Label label6;
        private TextBox TextBoxCostoDeHoraExtraTecnica;
        private Button BtnGuardarTecnico;
        private Button BtnEliminarTecnico;
        private Button BtnEditarTecnico;
    }
}