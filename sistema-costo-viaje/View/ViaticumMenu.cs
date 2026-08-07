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
    public partial class ViaticumMenu : Form
    {
        private ViaticoViajePresenter _presenter;
        private List<ViaticoViaje> _viaticos = new();
        private ViaticoViaje _viaticoSeleccionado;

        public ViaticumMenu()
        {
            InitializeComponent();
        }

        private void ViaticumMenu_Load(object sender, EventArgs e)
        {
            _presenter = new ViaticoViajePresenter(this);
            _presenter.Inicializar();
        }

        public void SetViaticos(List<ViaticoViaje> viaticos)
        {
            _viaticos = viaticos;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _viaticos;
            _viaticoSeleccionado = _viaticos.FirstOrDefault();
        }

        public void SetViatico(ViaticoViaje viatico)
        {
            _viaticoSeleccionado = viatico;
            if (viatico == null)
                return;

            TextBoxNombreViatico.Text = viatico.Tipo;
            TextBoxCostoDeViatico.Text = viatico.Monto.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow?.DataBoundItem is ViaticoViaje viatico)
            {
                _presenter.ObtenerViaticoPorId(viatico.Id);
            }
        }

        private void BtnGuardarViatico_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombreViatico.Text))
                    throw new ArgumentException("El tipo de viático es requerido");

                if (!decimal.TryParse(TextBoxCostoDeViatico.Text, out decimal monto) || monto <= 0)
                    throw new ArgumentException("El monto del viático debe ser mayor a 0");

                var viatico = new ViaticoViaje
                {
                    Tipo = TextBoxNombreViatico.Text.Trim(),
                    Monto = monto
                };

                _presenter.CrearViatico(viatico);
                MessageBox.Show("Viático guardado exitosamente.", "Gestión de Viáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarViatico_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viaticoSeleccionado == null)
                    throw new ArgumentException("No hay un viático seleccionado para editar");

                if (string.IsNullOrWhiteSpace(TextBoxNombreViatico.Text))
                    throw new ArgumentException("El tipo de viático es requerido");

                if (!decimal.TryParse(TextBoxCostoDeViatico.Text, out decimal monto) || monto <= 0)
                    throw new ArgumentException("El monto del viático debe ser mayor a 0");

                _viaticoSeleccionado.Tipo = TextBoxNombreViatico.Text.Trim();
                _viaticoSeleccionado.Monto = monto;

                _presenter.ActualizarViatico(_viaticoSeleccionado);
                MessageBox.Show("Viático actualizado exitosamente.", "Gestión de Viáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarViatico_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viaticoSeleccionado == null)
                    throw new ArgumentException("No hay un viático seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el viático '{_viaticoSeleccionado.Tipo}'?",
                    "Eliminar Viático",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _presenter.EliminarViatico(_viaticoSeleccionado.Id);
                MessageBox.Show("Viático eliminado exitosamente.", "Gestión de Viáticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            TextBoxNombreViatico.Clear();
            TextBoxCostoDeViatico.Clear();
        }
    }
}
