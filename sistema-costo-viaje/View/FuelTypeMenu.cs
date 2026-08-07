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
    public partial class FuelTypeMenu : Form
    {
        private TipoCombustiblePresenter _presenter;
        private List<TipoCombustible> _tiposCombustible = new();
        private TipoCombustible _tipoCombustibleSeleccionado;

        public FuelTypeMenu()
        {
            InitializeComponent();
        }

        private void FuelTypeMenu_Load(object sender, EventArgs e)
        {
            _presenter = new TipoCombustiblePresenter(this);
            _presenter.Inicializar();
        }

        public void SetTiposCombustible(List<TipoCombustible> tiposCombustible)
        {
            _tiposCombustible = tiposCombustible;
            DgvListaDeCombustible.DataSource = null;
            DgvListaDeCombustible.DataSource = _tiposCombustible;
            _tipoCombustibleSeleccionado = _tiposCombustible.FirstOrDefault();
        }

        public void SetTipoCombustible(TipoCombustible tipoCombustible)
        {
            _tipoCombustibleSeleccionado = tipoCombustible;
            if (tipoCombustible == null)
                return;

            TextBoxNombreCombustible.Text = tipoCombustible.Nombre;
            TextBoxCostoCombustible.Text = tipoCombustible.CostoPorLitro.ToString();
        }

        private void DgvListaDeCombustible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DgvListaDeCombustible.Rows.Count == 0)
                return;

            if (DgvListaDeCombustible.CurrentRow?.DataBoundItem is TipoCombustible tipoCombustible)
            {
                _presenter.ObtenerTipoCombustiblePorId(tipoCombustible.Id);
            }
        }

        private void BtnGuardarCombustible_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombreCombustible.Text))
                    throw new ArgumentException("El nombre del combustible es requerido");

                if (!decimal.TryParse(TextBoxCostoCombustible.Text, out decimal costo) || costo <= 0)
                    throw new ArgumentException("El costo por litro debe ser mayor a 0");

                var tipoCombustible = new TipoCombustible
                {
                    Nombre = TextBoxNombreCombustible.Text.Trim(),
                    CostoPorLitro = costo
                };

                _presenter.CrearTipoCombustible(tipoCombustible);
                MessageBox.Show("Combustible guardado exitosamente.", "Gestión de Combustible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarCombustible_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tipoCombustibleSeleccionado == null)
                    throw new ArgumentException("No hay un combustible seleccionado para editar");

                if (string.IsNullOrWhiteSpace(TextBoxNombreCombustible.Text))
                    throw new ArgumentException("El nombre del combustible es requerido");

                if (!decimal.TryParse(TextBoxCostoCombustible.Text, out decimal costo) || costo <= 0)
                    throw new ArgumentException("El costo por litro debe ser mayor a 0");

                _tipoCombustibleSeleccionado.Nombre = TextBoxNombreCombustible.Text.Trim();
                _tipoCombustibleSeleccionado.CostoPorLitro = costo;

                _presenter.ActualizarTipoCombustible(_tipoCombustibleSeleccionado);
                MessageBox.Show("Combustible actualizado exitosamente.", "Gestión de Combustible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarCombustible_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tipoCombustibleSeleccionado == null)
                    throw new ArgumentException("No hay un combustible seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el combustible '{_tipoCombustibleSeleccionado.Nombre}'?",
                    "Eliminar Combustible",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _presenter.EliminarTipoCombustible(_tipoCombustibleSeleccionado.Id);
                MessageBox.Show("Combustible eliminado exitosamente.", "Gestión de Combustible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            TextBoxNombreCombustible.Clear();
            TextBoxCostoCombustible.Clear();
        }
    }
}
