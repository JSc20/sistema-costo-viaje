namespace sistema_costo_viaje.View
{
    partial class TollMenu
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
            DgvListaDePeajes = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            TextBoxNombrePeaje = new TextBox();
            TextBoxCostoPeaje = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            BtnEliminarPeaje = new Button();
            BtnGuardarPeaje = new Button();
            BtnEditarPeaje = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvListaDePeajes).BeginInit();
            SuspendLayout();
            // 
            // DgvListaDePeajes
            // 
            DgvListaDePeajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvListaDePeajes.Location = new Point(12, 328);
            DgvListaDePeajes.Name = "DgvListaDePeajes";
            DgvListaDePeajes.Size = new Size(460, 160);
            DgvListaDePeajes.TabIndex = 0;
            DgvListaDePeajes.CellClick += DgvListaDePeajes_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 121);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Costo:";
            // 
            // TextBoxNombrePeaje
            // 
            TextBoxNombrePeaje.Location = new Point(72, 70);
            TextBoxNombrePeaje.Name = "TextBoxNombrePeaje";
            TextBoxNombrePeaje.Size = new Size(201, 23);
            TextBoxNombrePeaje.TabIndex = 3;
            // 
            // TextBoxCostoPeaje
            // 
            TextBoxCostoPeaje.Location = new Point(72, 121);
            TextBoxCostoPeaje.Name = "TextBoxCostoPeaje";
            TextBoxCostoPeaje.Size = new Size(201, 23);
            TextBoxCostoPeaje.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(95, 203);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(217, 203);
            button2.Name = "button2";
            button2.Size = new Size(0, 0);
            button2.TabIndex = 4;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(230, 255);
            button3.Name = "button3";
            button3.Size = new Size(0, 0);
            button3.TabIndex = 4;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            // 
            // BtnEliminarPeaje
            // 
            BtnEliminarPeaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnEliminarPeaje.Location = new Point(298, 203);
            BtnEliminarPeaje.Name = "BtnEliminarPeaje";
            BtnEliminarPeaje.Size = new Size(120, 35);
            BtnEliminarPeaje.TabIndex = 4;
            BtnEliminarPeaje.Text = "Eliminar Peaje";
            BtnEliminarPeaje.UseVisualStyleBackColor = false;
            BtnEliminarPeaje.Click += BtnEliminarPeaje_Click;
            // 
            // BtnGuardarPeaje
            // 
            BtnGuardarPeaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarPeaje.Location = new Point(12, 203);
            BtnGuardarPeaje.Name = "BtnGuardarPeaje";
            BtnGuardarPeaje.Size = new Size(120, 35);
            BtnGuardarPeaje.TabIndex = 4;
            BtnGuardarPeaje.Text = "Guardar Peaje";
            BtnGuardarPeaje.UseVisualStyleBackColor = false;
            BtnGuardarPeaje.Click += BtnGuardarPeaje_Click;
            // 
            // BtnEditarPeaje
            // 
            BtnEditarPeaje.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarPeaje.Location = new Point(153, 203);
            BtnEditarPeaje.Name = "BtnEditarPeaje";
            BtnEditarPeaje.Size = new Size(120, 35);
            BtnEditarPeaje.TabIndex = 4;
            BtnEditarPeaje.Text = "Editar Peaje";
            BtnEditarPeaje.UseVisualStyleBackColor = false;
            BtnEditarPeaje.Click += BtnEditarPeaje_Click;
            // 
            // TollMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 501);
            Controls.Add(BtnEditarPeaje);
            Controls.Add(BtnGuardarPeaje);
            Controls.Add(BtnEliminarPeaje);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(TextBoxCostoPeaje);
            Controls.Add(TextBoxNombrePeaje);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DgvListaDePeajes);
            Name = "TollMenu";
            Text = "Gestión de Peajes";
            Load += TollMenu_Load;
            ((System.ComponentModel.ISupportInitialize)DgvListaDePeajes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvListaDePeajes;
        private Label label1;
        private Label label2;
        private TextBox TextBoxNombrePeaje;
        private TextBox TextBoxCostoPeaje;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button BtnEliminarPeaje;
        private Button BtnGuardarPeaje;
        private Button BtnEditarPeaje;
    }
}