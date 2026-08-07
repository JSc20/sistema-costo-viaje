namespace sistema_costo_viaje.View
{
    partial class DestinationMenu
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
            label3 = new Label();
            TextBoxKmsIdaYVueltaDestino = new TextBox();
            CheckListBoxPeajesDestino = new CheckedListBox();
            BtnGuardarDestino = new Button();
            BtnEditarDestino = new Button();
            BtnEliminarDestino = new Button();
            TextBoxNombreDestino = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 104);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 1;
            label2.Text = "Km´s ida y vuelta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 146);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 1;
            label3.Text = "Peajes:";
            // 
            // TextBoxKmsIdaYVueltaDestino
            // 
            TextBoxKmsIdaYVueltaDestino.Location = new Point(117, 101);
            TextBoxKmsIdaYVueltaDestino.Name = "TextBoxKmsIdaYVueltaDestino";
            TextBoxKmsIdaYVueltaDestino.Size = new Size(98, 23);
            TextBoxKmsIdaYVueltaDestino.TabIndex = 2;
            // 
            // CheckListBoxPeajesDestino
            // 
            CheckListBoxPeajesDestino.FormattingEnabled = true;
            CheckListBoxPeajesDestino.Items.AddRange(new object[] { "Peaje 1" });
            CheckListBoxPeajesDestino.Location = new Point(86, 146);
            CheckListBoxPeajesDestino.Name = "CheckListBoxPeajesDestino";
            CheckListBoxPeajesDestino.Size = new Size(129, 184);
            CheckListBoxPeajesDestino.TabIndex = 3;
            // 
            // BtnGuardarDestino
            // 
            BtnGuardarDestino.BackColor = Color.FromArgb(97, 97, 96);
            BtnGuardarDestino.Location = new Point(12, 378);
            BtnGuardarDestino.Name = "BtnGuardarDestino";
            BtnGuardarDestino.Size = new Size(120, 35);
            BtnGuardarDestino.TabIndex = 4;
            BtnGuardarDestino.Text = "Guardar Destino";
            BtnGuardarDestino.UseVisualStyleBackColor = false;
            BtnGuardarDestino.Click += BtnGuardarDestino_Click;
            // 
            // BtnEditarDestino
            // 
            BtnEditarDestino.BackColor = Color.FromArgb(97, 97, 96);
            BtnEditarDestino.Location = new Point(138, 378);
            BtnEditarDestino.Name = "BtnEditarDestino";
            BtnEditarDestino.Size = new Size(120, 35);
            BtnEditarDestino.TabIndex = 5;
            BtnEditarDestino.Text = "Editar Destino";
            BtnEditarDestino.UseVisualStyleBackColor = false;
            BtnEditarDestino.Click += BtnEditarDestino_Click;
            // 
            // BtnEliminarDestino
            // 
            BtnEliminarDestino.BackColor = Color.FromArgb(97, 97, 96);
            BtnEliminarDestino.Location = new Point(264, 378);
            BtnEliminarDestino.Name = "BtnEliminarDestino";
            BtnEliminarDestino.Size = new Size(120, 35);
            BtnEliminarDestino.TabIndex = 6;
            BtnEliminarDestino.Text = "Eliminar Destino";
            BtnEliminarDestino.UseVisualStyleBackColor = false;
            BtnEliminarDestino.Click += BtnEliminarDestino_Click;
            // 
            // TextBoxNombreDestino
            // 
            TextBoxNombreDestino.Location = new Point(72, 56);
            TextBoxNombreDestino.Name = "TextBoxNombreDestino";
            TextBoxNombreDestino.Size = new Size(143, 23);
            TextBoxNombreDestino.TabIndex = 2;
            // 
            // DestinationMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 501);
            Controls.Add(BtnEliminarDestino);
            Controls.Add(BtnEditarDestino);
            Controls.Add(BtnGuardarDestino);
            Controls.Add(CheckListBoxPeajesDestino);
            Controls.Add(TextBoxNombreDestino);
            Controls.Add(TextBoxKmsIdaYVueltaDestino);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DestinationMenu";
            Text = "DestinationMenu";
            Load += DestinationMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox TextBoxKmsIdaYVueltaDestino;
        private CheckedListBox CheckListBoxPeajesDestino;
        private Button BtnGuardarDestino;
        private Button BtnEditarDestino;
        private Button BtnEliminarDestino;
        private TextBox TextBoxNombreDestino;
    }
}