namespace sistema_costo_viaje.View
{
    partial class MainMenu
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(173, 165);
            button1.Name = "button1";
            button1.Size = new Size(130, 50);
            button1.TabIndex = 3;
            button1.Text = "Gestionar viajes";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(173, 221);
            button2.Name = "button2";
            button2.Size = new Size(130, 50);
            button2.TabIndex = 4;
            button2.Text = "Gestionar técnicos";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(173, 277);
            button3.Name = "button3";
            button3.Size = new Size(130, 50);
            button3.TabIndex = 4;
            button3.Text = "Gestionar vehículos ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(173, 333);
            button4.Name = "button4";
            button4.Size = new Size(130, 50);
            button4.TabIndex = 4;
            button4.Text = "Gestionar viáticos ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(173, 389);
            button5.Name = "button5";
            button5.Size = new Size(130, 50);
            button5.TabIndex = 4;
            button5.Text = "Gestionar Peajes";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button3_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 501);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainMenu";
            Text = "Menú Principal ";
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}