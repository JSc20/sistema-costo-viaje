using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.Presenter;

namespace sistema_costo_viaje.View
{
    public partial class TollMenu : Form
    {
        private PeajePresenter _presenter;
        private List<Peaje> _peajes = new();
        private Peaje _peajeSeleccionado;

        public TollMenu()
        {
            InitializeComponent();
        }

        private void TollMenu_Load(object sender, EventArgs e)
        {
            _presenter = new PeajePresenter(this);
            _presenter.Inicializar();
        }

        public void SetPeajes(List<Peaje> peajes)
        {
            _peajes = peajes;
            DgvListaDePeajes.DataSource = null;
            DgvListaDePeajes.DataSource = _peajes;
            _peajeSeleccionado = _peajes.FirstOrDefault();
        }

        public void SetPeaje(Peaje peaje)
        {
            _peajeSeleccionado = peaje;
            if (peaje == null)
                return;

            TextBoxNombrePeaje.Text = peaje.Nombre;
            TextBoxCostoPeaje.Text = peaje.Costo.ToString();
        }

        private void DgvListaDePeajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DgvListaDePeajes.Rows.Count == 0)
                return;

            if (DgvListaDePeajes.CurrentRow?.DataBoundItem is Peaje peaje)
            {
                _presenter.ObtenerPeajePorId(peaje.Id);
            }
        }

        private void BtnGuardarPeaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombrePeaje.Text))
                    throw new ArgumentException("El nombre del peaje es requerido");

                if (!decimal.TryParse(TextBoxCostoPeaje.Text, out decimal costo) || costo < 0)
                    throw new ArgumentException("El costo del peaje no puede ser negativo");

                var peaje = new Peaje
                {
                    Nombre = TextBoxNombrePeaje.Text.Trim(),
                    Costo = costo
                };

                _presenter.CrearPeaje(peaje);
                MessageBox.Show("Peaje guardado exitosamente.", "Gestión de Peajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarPeaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (_peajeSeleccionado == null)
                    throw new ArgumentException("No hay un peaje seleccionado para editar");

                if (string.IsNullOrWhiteSpace(TextBoxNombrePeaje.Text))
                    throw new ArgumentException("El nombre del peaje es requerido");

                if (!decimal.TryParse(TextBoxCostoPeaje.Text, out decimal costo) || costo < 0)
                    throw new ArgumentException("El costo del peaje no puede ser negativo");

                _peajeSeleccionado.Nombre = TextBoxNombrePeaje.Text.Trim();
                _peajeSeleccionado.Costo = costo;

                _presenter.ActualizarPeaje(_peajeSeleccionado);
                MessageBox.Show("Peaje actualizado exitosamente.", "Gestión de Peajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarPeaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (_peajeSeleccionado == null)
                    throw new ArgumentException("No hay un peaje seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el peaje '{_peajeSeleccionado.Nombre}'?",
                    "Eliminar Peaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _presenter.EliminarPeaje(_peajeSeleccionado.Id);
                MessageBox.Show("Peaje eliminado exitosamente.", "Gestión de Peajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            TextBoxNombrePeaje.Clear();
            TextBoxCostoPeaje.Clear();
        }
    }
}
