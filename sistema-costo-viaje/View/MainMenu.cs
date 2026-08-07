using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sistema_costo_viaje.View
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnEntrarAMenuDeViajes_Click(object sender, EventArgs e)
        {
            using (var formulario = new JourneyMenu())
            {
                formulario.ShowDialog(this);
            }
        }

        private void BtnEntrarAMenuDeTecnicos_Click(object sender, EventArgs e)
        {
            using (var formulario = new TechnicalMenu())
            {
                formulario.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            switch (boton.Name)
            {
                case "button3":
                    using (var formulario = new Menú_Vehículos())
                    {
                        formulario.ShowDialog(this);
                    }
                    break;
                case "button4":
                    using (var formulario = new ViaticumMenu())
                    {
                        formulario.ShowDialog(this);
                    }
                    break;
                case "button5":
                    using (var formulario = new TollMenu())
                    {
                        formulario.ShowDialog(this);
                    }
                    break;
            }
        }

        private void BtnEntrarAMenuDeTecnicos_Click(object sender, EventArgs e)
        {

        }
    }
}
