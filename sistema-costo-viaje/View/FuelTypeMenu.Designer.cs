namespace sistema_costo_viaje.View
{
    partial class FuelTypeMenu
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
            label1 = new Label();
            label2 = new Label();
            TextBoxCostoCombustible = new TextBox();
            TextBoxNombreCombustible = new TextBox();
            BtnGuardarCombustible = new Button();
            BtnEditarCombustible = new Button();
            BtnEliminarCombustible = new Button();
            DgvListaDeCombustible = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvListaDeCombustible).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 121);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Costo:";
            // 
            // TextBoxCostoCombustible
            // 
            TextBoxCostoCombustible.Location = new Point(72, 121);
            TextBoxCostoCombustible.Name = "TextBoxCostoCombustible";
            TextBoxCostoCombustible.Size = new Size(201, 23);
            TextBoxCostoCombustible.TabIndex = 2;
            // 
            // TextBoxNombreCombustible
            // 
            TextBoxNombreCombustible.Location = new Point(72, 70);
            TextBoxNombreCombustible.Name = "TextBoxNombreCombustible";
            TextBoxNombreCombustible.Size = new Size(201, 23);
            TextBoxNombreCombustible.TabIndex = 3;
            // 
            // BtnGuardarCombustible
            // 
            BtnGuardarCombustible.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarCombustible.Location = new Point(12, 203);
            BtnGuardarCombustible.Name = "BtnGuardarCombustible";
            BtnGuardarCombustible.Size = new Size(130, 35);
            BtnGuardarCombustible.TabIndex = 4;
            BtnGuardarCombustible.Text = "Guardar Combustible";
            BtnGuardarCombustible.UseVisualStyleBackColor = false;
            // 
            // BtnEditarCombustible
            // 
            BtnEditarCombustible.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarCombustible.Location = new Point(148, 203);
            BtnEditarCombustible.Name = "BtnEditarCombustible";
            BtnEditarCombustible.Size = new Size(130, 35);
            BtnEditarCombustible.TabIndex = 5;
            BtnEditarCombustible.Text = "Editar Combustible";
            BtnEditarCombustible.UseVisualStyleBackColor = false;
            BtnEditarCombustible.Click += button2_Click;
            // 
            // BtnEliminarCombustible
            // 
            BtnEliminarCombustible.BackColor = Color.FromArgb(97, 97, 96);
            BtnEliminarCombustible.Location = new Point(284, 203);
            BtnEliminarCombustible.Name = "BtnEliminarCombustible";
            BtnEliminarCombustible.Size = new Size(130, 35);
            BtnEliminarCombustible.TabIndex = 6;
            BtnEliminarCombustible.Text = "Eliminar Combustible";
            BtnEliminarCombustible.UseVisualStyleBackColor = false;
            // 
            // DgvListaDeCombustible
            // 
            DgvListaDeCombustible.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaDeCombustible.Location = new Point(12, 328);
            DgvListaDeCombustible.Name = "DgvListaDeCombustible";
            DgvListaDeCombustible.Size = new Size(460, 160);
            DgvListaDeCombustible.TabIndex = 7;
            // 
            // FuelTypeMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 501);
            Controls.Add(DgvListaDeCombustible);
            Controls.Add(BtnEliminarCombustible);
            Controls.Add(BtnEditarCombustible);
            Controls.Add(BtnGuardarCombustible);
            Controls.Add(TextBoxNombreCombustible);
            Controls.Add(TextBoxCostoCombustible);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FuelTypeMenu";
            Text = "Gestión de Combustible";
            ((System.ComponentModel.ISupportInitialize)DgvListaDeCombustible).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TextBoxCostoCombustible;
        private TextBox TextBoxNombreCombustible;
        private Button BtnGuardarCombustible;
        private Button BtnEditarCombustible;
        private Button BtnEliminarCombustible;
        private DataGridView DgvListaDeCombustible;
    }
}