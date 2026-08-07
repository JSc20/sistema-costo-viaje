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
    public partial class TechnicalMenu : Form
    {
        private TecnicoPresenter _presenter;
        private List<Tecnico> _tecnicos = new();
        private Tecnico _tecnicoSeleccionado;

        public TechnicalMenu()
        {
            InitializeComponent();
        }

        private void TechnicalMenu_Load(object sender, EventArgs e)
        {
            _presenter = new TecnicoPresenter(this);
            _presenter.Inicializar();
        }

        public void SetTecnicos(List<Tecnico> tecnicos)
        {
            _tecnicos = tecnicos;
            DgvListaDeTenicos.DataSource = null;
            DgvListaDeTenicos.DataSource = _tecnicos;
            _tecnicoSeleccionado = _tecnicos.FirstOrDefault();
        }

        public void SetTecnico(Tecnico tecnico)
        {
            _tecnicoSeleccionado = tecnico;
            if (tecnico == null)
                return;

            TextBoxNombreTecnico.Text = tecnico.nombre;
            TextBoxSalarioTecnico.Text = tecnico.salario_mensual.ToString();
            TextBoxHrsDeTrabajoSemanalTecnico.Text = tecnico.horas_semanales.ToString();
            TextBoxCostoDeHoraOrdinariaTecnico.Text = tecnico.costo_hora_ordinaria.ToString();
            TextBoxCostoDeHoraExtraTecnica.Text = tecnico.costo_hora_extra.ToString();
        }

        private void BtnGuardarTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                var tecnico = ConstruirTecnico();
                _presenter.CrearTecnico(tecnico);
                MessageBox.Show("Técnico guardado exitosamente.", "Gestión de Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tecnicoSeleccionado == null)
                    throw new ArgumentException("No hay un técnico seleccionado para editar");

                var tecnico = ConstruirTecnico();
                tecnico.id = _tecnicoSeleccionado.id;

                _presenter.ActualizarTecnico(tecnico);
                MessageBox.Show("Técnico actualizado exitosamente.", "Gestión de Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tecnicoSeleccionado == null)
                    throw new ArgumentException("No hay un técnico seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar al técnico '{_tecnicoSeleccionado.nombre}'?",
                    "Eliminar Técnico",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _presenter.EliminarTecnico(_tecnicoSeleccionado.id);
                MessageBox.Show("Técnico eliminado exitosamente.", "Gestión de Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Tecnico ConstruirTecnico()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNombreTecnico.Text))
                throw new ArgumentException("El nombre del técnico es requerido");

            if (!decimal.TryParse(TextBoxSalarioTecnico.Text, out decimal salario) || salario < 0)
                throw new ArgumentException("El salario mensual no es válido");

            if (!int.TryParse(TextBoxHrsDeTrabajoSemanalTecnico.Text, out int horas) || horas <= 0)
                throw new ArgumentException("Las horas semanales no son válidas");

            decimal horaOrdinaria = 0;
            if (!string.IsNullOrWhiteSpace(TextBoxCostoDeHoraOrdinariaTecnico.Text))
            {
                if (!decimal.TryParse(TextBoxCostoDeHoraOrdinariaTecnico.Text, out horaOrdinaria) || horaOrdinaria < 0)
                    throw new ArgumentException("El costo de hora ordinaria no es válido");
            }
            else
            {
                horaOrdinaria = _presenter.CalcularCostoHoraOrdinaria(salario, horas);
            }

            decimal horaExtra = 0;
            if (!string.IsNullOrWhiteSpace(TextBoxCostoDeHoraExtraTecnica.Text))
            {
                if (!decimal.TryParse(TextBoxCostoDeHoraExtraTecnica.Text, out horaExtra) || horaExtra < 0)
                    throw new ArgumentException("El costo de hora extra no es válido");
            }
            else
            {
                horaExtra = _presenter.CalcularCostoHoraExtra(horaOrdinaria);
            }

            return new Tecnico
            {
                nombre = TextBoxNombreTecnico.Text.Trim(),
                salario_mensual = salario,
                horas_semanales = horas,
                costo_hora_ordinaria = horaOrdinaria,
                costo_hora_extra = horaExtra
            };
        }

        private void LimpiarFormulario()
        {
            TextBoxNombreTecnico.Clear();
            TextBoxSalarioTecnico.Clear();
            TextBoxHrsDeTrabajoSemanalTecnico.Clear();
            TextBoxCostoDeHoraOrdinariaTecnico.Clear();
            TextBoxCostoDeHoraExtraTecnica.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DgvListaDeTenicos.Rows.Count == 0)
                return;

            if (DgvListaDeTenicos.CurrentRow?.DataBoundItem is Tecnico tecnico)
            {
                _presenter.ObtenerTecnicoPorId(tecnico.id);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxNombreTecnico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
