namespace sistema_costo_viaje.View
{
    partial class ViaticumMenu
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
            label2 = new Label();
            label1 = new Label();
            TextBoxNombreViatico = new TextBox();
            TextBoxCostoDeViatico = new TextBox();
            dataGridView1 = new DataGridView();
            BtnEditarViatico = new Button();
            BtnEiminarViatico = new Button();
            BtnGuardarViatico = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Costo:";
            label1.Click += label2_Click;
            // 
            // TextBoxNombreViatico
            // 
            TextBoxNombreViatico.Location = new Point(72, 70);
            TextBoxNombreViatico.Name = "TextBoxNombreViatico";
            TextBoxNombreViatico.Size = new Size(201, 23);
            TextBoxNombreViatico.TabIndex = 1;
            // 
            // TextBoxCostoDeViatico
            // 
            TextBoxCostoDeViatico.Location = new Point(72, 121);
            TextBoxCostoDeViatico.Name = "TextBoxCostoDeViatico";
            TextBoxCostoDeViatico.Size = new Size(201, 23);
            TextBoxCostoDeViatico.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 328);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(460, 160);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // BtnEditarViatico
            // 
            BtnEditarViatico.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarViatico.Location = new Point(153, 203);
            BtnEditarViatico.Name = "BtnEditarViatico";
            BtnEditarViatico.Size = new Size(120, 35);
            BtnEditarViatico.TabIndex = 3;
            BtnEditarViatico.Text = "Editar Viático";
            BtnEditarViatico.UseVisualStyleBackColor = false;
            BtnEditarViatico.Click += BtnEditarViatico_Click;
            // 
            // BtnEiminarViatico
            // 
            BtnEiminarViatico.BackColor = Color.FromArgb(97, 97, 96);
            BtnEiminarViatico.Location = new Point(298, 203);
            BtnEiminarViatico.Name = "BtnEiminarViatico";
            BtnEiminarViatico.Size = new Size(120, 35);
            BtnEiminarViatico.TabIndex = 3;
            BtnEiminarViatico.Text = "Eliminar Viático";
            BtnEiminarViatico.UseVisualStyleBackColor = false;
            BtnEiminarViatico.Click += BtnEliminarViatico_Click;
            // 
            // BtnGuardarViatico
            // 
            BtnGuardarViatico.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarViatico.Location = new Point(12, 203);
            BtnGuardarViatico.Name = "BtnGuardarViatico";
            BtnGuardarViatico.Size = new Size(120, 35);
            BtnGuardarViatico.TabIndex = 3;
            BtnGuardarViatico.Text = "Guardar Viático";
            BtnGuardarViatico.UseVisualStyleBackColor = false;
            BtnGuardarViatico.Click += BtnGuardarViatico_Click;
            // 
            // ViaticumMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 501);
            Controls.Add(BtnEiminarViatico);
            Controls.Add(BtnGuardarViatico);
            Controls.Add(BtnEditarViatico);
            Controls.Add(dataGridView1);
            Controls.Add(TextBoxCostoDeViatico);
            Controls.Add(TextBoxNombreViatico);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "ViaticumMenu";
            Text = "Gestión de Viáticos";
            Load += ViaticumMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private TextBox TextBoxNombreViatico;
        private TextBox TextBoxCostoDeViatico;
        private DataGridView dataGridView1;
        private Button BtnGuardarViático;
        private Button BtnEditarViatico;
        private Button BtnEiminarViatico;
        private Button BtnGuardarViatico;
    }
}