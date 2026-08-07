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
    public partial class DestinationMenu : Form
    {
        private DestinoPresenter _presenter;
        private PeajePresenter _peajePresenter;
        private List<Destino> _destinos = new();
        private Destino _destinoSeleccionado;

        public DestinationMenu()
        {
            InitializeComponent();
        }

        private void DestinationMenu_Load(object sender, EventArgs e)
        {
            _presenter = new DestinoPresenter(this);
            _peajePresenter = new PeajePresenter(this);
            _presenter.Inicializar();
            _peajePresenter.Inicializar();
        }

        public void SetDestinos(List<Destino> destinos)
        {
            _destinos = destinos;
            _destinoSeleccionado = _destinos.FirstOrDefault();
        }

        public void SetDestino(Destino destino)
        {
            _destinoSeleccionado = destino;
            if (destino == null)
                return;

            TextBoxNombreDestino.Text = destino.Nombre;
            TextBoxKmsIdaYVueltaDestino.Text = destino.KmIdaVuelta.ToString();
        }

        public void SetPeajes(List<Peaje> peajes)
        {
            CheckListBoxPeajesDestino.Items.Clear();
            foreach (var peaje in peajes)
            {
                CheckListBoxPeajesDestino.Items.Add(peaje, false);
            }
            CheckListBoxPeajesDestino.DisplayMember = "Nombre";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardarDestino_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombreDestino.Text))
                    throw new ArgumentException("El nombre del destino es requerido");

                if (!decimal.TryParse(TextBoxKmsIdaYVueltaDestino.Text, out decimal kms) || kms <= 0)
                    throw new ArgumentException("Los kilómetros ida y vuelta deben ser mayor a 0");

                var destino = new Destino
                {
                    Nombre = TextBoxNombreDestino.Text.Trim(),
                    KmIdaVuelta = kms,
                    PeajeId = CheckListBoxPeajesDestino.CheckedItems.Cast<Peaje>().FirstOrDefault()?.Id ?? 0
                };

                _presenter.CrearDestino(destino);
                MessageBox.Show("Destino guardado exitosamente.", "Gestión de Destinos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarDestino_Click(object sender, EventArgs e)
        {
            try
            {
                if (_destinoSeleccionado == null)
                    throw new ArgumentException("No hay un destino seleccionado para editar");

                if (string.IsNullOrWhiteSpace(TextBoxNombreDestino.Text))
                    throw new ArgumentException("El nombre del destino es requerido");

                if (!decimal.TryParse(TextBoxKmsIdaYVueltaDestino.Text, out decimal kms) || kms <= 0)
                    throw new ArgumentException("Los kilómetros ida y vuelta deben ser mayor a 0");

                _destinoSeleccionado.Nombre = TextBoxNombreDestino.Text.Trim();
                _destinoSeleccionado.KmIdaVuelta = kms;
                _destinoSeleccionado.PeajeId = CheckListBoxPeajesDestino.CheckedItems.Cast<Peaje>().FirstOrDefault()?.Id ?? 0;

                _presenter.ActualizarDestino(_destinoSeleccionado);
                MessageBox.Show("Destino actualizado exitosamente.", "Gestión de Destinos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarDestino_Click(object sender, EventArgs e)
        {
            try
            {
                if (_destinoSeleccionado == null)
                    throw new ArgumentException("No hay un destino seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el destino '{_destinoSeleccionado.Nombre}'?",
                    "Eliminar Destino",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _presenter.EliminarDestino(_destinoSeleccionado.Id);
                MessageBox.Show("Destino eliminado exitosamente.", "Gestión de Destinos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            TextBoxNombreDestino.Clear();
            TextBoxKmsIdaYVueltaDestino.Clear();
            for (int i = 0; i < CheckListBoxPeajesDestino.Items.Count; i++)
            {
                CheckListBoxPeajesDestino.SetItemChecked(i, false);
            }
        }
    }
}
