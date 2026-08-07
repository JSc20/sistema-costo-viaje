using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaCostoViaje.EL;
using SistemaCostoViaje.Presenter;

namespace sistema_costo_viaje.View
{
    public partial class JourneyMenu : Form
    {
        private ViajePresenter _viajePresenter;
        private VehiculoPresenter _vehiculoPresenter;
        private DestinoPresenter _destinoPresenter;
        private TipoCombustiblePresenter _combustiblePresenter;
        private ViaticoViajePresenter _viaticoPresenter;

        private List<Viaje> _viajes = new();
        private List<Vehiculo> _vehiculos = new();
        private List<Destino> _destinos = new();
        private List<TipoCombustible> _combustibles = new();
        private List<ViaticoViaje> _viaticos = new();

        private Viaje _viajeSeleccionado;

        public JourneyMenu()
        {
            InitializeComponent();
        }

        private void JourneyMenu_Load(object sender, EventArgs e)
        {
            _viajePresenter = new ViajePresenter(this);
            _vehiculoPresenter = new VehiculoPresenter(this);
            _destinoPresenter = new DestinoPresenter(this);
            _combustiblePresenter = new TipoCombustiblePresenter(this);
            _viaticoPresenter = new ViaticoViajePresenter(this);

            _viajePresenter.Inicializar();
            _vehiculoPresenter.Inicializar();
            _destinoPresenter.Inicializar();
            _combustiblePresenter.Inicializar();
            _viaticoPresenter.Inicializar();

            DateTimePickerViajes.Value = DateTime.Today;
        }

        public void SetViajes(List<Viaje> viajes)
        {
            _viajes = viajes;
            CheckListBoxViaje.Items.Clear();
            foreach (var viaje in viajes)
            {
                CheckListBoxViaje.Items.Add(viaje);
            }
            CheckListBoxViaje.DisplayMember = "Destino";
            _viajeSeleccionado = viajes.FirstOrDefault();
        }

        public void SetViaje(Viaje viaje)
        {
            _viajeSeleccionado = viaje;
            if (viaje == null)
                return;

            SeleccionarCombo(ComboBoxVehículoViaje, viaje.VehiculoId);
            SeleccionarCombo(ComboBoxDestinoViaje, viaje.Destino);
            SeleccionarCombo(ComboBoxCombustibleViaje, viaje.Id);
            textBox1.Text = viaje.CostoFerry.ToString();
            DateTimePickerViajes.Value = viaje.FechaViaje;
        }

        public void SetVehiculos(List<Vehiculo> vehiculos)
        {
            _vehiculos = vehiculos;
            ComboBoxVehículoViaje.DataSource = null;
            ComboBoxVehículoViaje.DataSource = vehiculos;
            ComboBoxVehículoViaje.DisplayMember = "Modelo";
            ComboBoxVehículoViaje.ValueMember = "Id";
        }

        public void SetDestinos(List<Destino> destinos)
        {
            _destinos = destinos;
            ComboBoxDestinoViaje.DataSource = null;
            ComboBoxDestinoViaje.DataSource = destinos;
            ComboBoxDestinoViaje.DisplayMember = "Nombre";
            ComboBoxDestinoViaje.ValueMember = "Id";
        }

        public void SetTiposCombustible(List<TipoCombustible> tiposCombustible)
        {
            _combustibles = tiposCombustible;
            ComboBoxCombustibleViaje.DataSource = null;
            ComboBoxCombustibleViaje.DataSource = tiposCombustible;
            ComboBoxCombustibleViaje.DisplayMember = "Nombre";
            ComboBoxCombustibleViaje.ValueMember = "Id";
        }

        public void SetViaticos(List<ViaticoViaje> viaticos)
        {
            _viaticos = viaticos;
            CheckListViaticoViaje.Items.Clear();
            foreach (var viatico in viaticos)
            {
                CheckListViaticoViaje.Items.Add(viatico, false);
            }
            CheckListViaticoViaje.DisplayMember = "Tipo";
        }

        private void BtnGuardarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxDestinoViaje.SelectedItem is not Destino destino)
                    throw new ArgumentException("Seleccione un destino para el viaje");

                if (ComboBoxVehículoViaje.SelectedItem is not Vehiculo vehiculo)
                    throw new ArgumentException("Seleccione un vehículo para el viaje");

                decimal costoFerry = 0;
                if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                    !decimal.TryParse(textBox1.Text, out costoFerry))
                {
                    throw new ArgumentException("El costo del ferri no es válido");
                }

                var viaje = new Viaje
                {
                    Origen = "Origen",
                    Destino = destino.Nombre,
                    DistanciaKm = destino.KmIdaVuelta,
                    FechaViaje = DateTimePickerViajes.Value,
                    IdConductor = 1,
                    VehiculoId = vehiculo.Id,
                    HorasOrdinarias = 0,
                    HorasExtra = 0,
                    CostoFerry = costoFerry,
                    CostoHospedaje = 0,
                    CostoInsumos = 0
                };

                _viajePresenter.CrearViaje(viaje);
                MessageBox.Show("Viaje guardado exitosamente.", "Gestión de Viajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RecalcularDesglose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viajeSeleccionado == null)
                    throw new ArgumentException("No hay un viaje seleccionado para editar");

                if (ComboBoxDestinoViaje.SelectedItem is not Destino destino)
                    throw new ArgumentException("Seleccione un destino para el viaje");

                if (ComboBoxVehículoViaje.SelectedItem is not Vehiculo vehiculo)
                    throw new ArgumentException("Seleccione un vehículo para el viaje");

                decimal costoFerry = 0;
                if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                    !decimal.TryParse(textBox1.Text, out costoFerry))
                {
                    throw new ArgumentException("El costo del ferri no es válido");
                }

                _viajeSeleccionado.Destino = destino.Nombre;
                _viajeSeleccionado.DistanciaKm = destino.KmIdaVuelta;
                _viajeSeleccionado.VehiculoId = vehiculo.Id;
                _viajeSeleccionado.CostoFerry = costoFerry;

                _viajePresenter.ActualizarViaje(_viajeSeleccionado);
                MessageBox.Show("Viaje actualizado exitosamente.", "Gestión de Viajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viajeSeleccionado == null)
                    throw new ArgumentException("No hay un viaje seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el viaje a '{_viajeSeleccionado.Destino}'?",
                    "Eliminar Viaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _viajePresenter.EliminarViaje(_viajeSeleccionado.Id);
                MessageBox.Show("Viaje eliminado exitosamente.", "Gestión de Viajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                using var dialogo = new SaveFileDialog
                {
                    Filter = "Archivo CSV (*.csv)|*.csv",
                    FileName = $"viajes_{DateTime.Now:yyyyMMdd}.csv",
                    Title = "Exportar registros de viajes"
                };

                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                var lineas = new List<string> { "Id,Destino,DistanciaKm,CostoTotal,Fecha" };
                lineas.AddRange(_viajes.Select(v =>
                    $"{v.Id},{v.Destino},{v.DistanciaKm},{v.CostoBase},{v.FechaViaje:yyyy-MM-dd}"));

                File.WriteAllLines(dialogo.FileName, lineas, Encoding.UTF8);
                MessageBox.Show("Registro exportado exitosamente.", "Exportar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcularDesglose()
        {
            var destino = ComboBoxDestinoViaje.SelectedItem as Destino;
            var combustible = ComboBoxCombustibleViaje.SelectedItem as TipoCombustible;

            decimal distancia = destino?.KmIdaVuelta ?? 0;
            const decimal rendimientoPorLitro = 10m;

            decimal costoCombustible = combustible != null && distancia > 0
                ? Math.Round((distancia / rendimientoPorLitro) * combustible.CostoPorLitro, 2)
                : 0;

            decimal costoViaticos = CheckListViaticoViaje.CheckedItems.Cast<ViaticoViaje>().Sum(v => v.Monto);

            decimal costoFerry = 0;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                decimal.TryParse(textBox1.Text, out costoFerry);
            }

            var desgloseCombustible = new List<object>
            {
                new { Concepto = "Combustible", Monto = costoCombustible },
                new { Concepto = "Peajes", Monto = 0m },
                new { Concepto = "Viáticos", Monto = costoViaticos },
                new { Concepto = "Ferri", Monto = costoFerry }
            };

            var desgloseTotal = new List<object>
            {
                new { Concepto = "Combustible", Monto = costoCombustible },
                new { Concepto = "Peajes", Monto = 0m },
                new { Concepto = "Viáticos", Monto = costoViaticos },
                new { Concepto = "Ferri", Monto = costoFerry },
                new { Concepto = "Total", Monto = costoCombustible + costoViaticos + costoFerry }
            };

            DgvDesglosePrecioSoloDelCombustible.DataSource = null;
            DgvDesglosePrecioSoloDelCombustible.DataSource = desgloseCombustible;

            DgvDesglosePrecioTotal.DataSource = null;
            DgvDesglosePrecioTotal.DataSource = desgloseTotal;
        }

        private void MostrarDesgloseDelViaje(Viaje viaje)
        {
            var desglose = new List<object>
            {
                new { Concepto = "Distancia (km)", Monto = viaje.DistanciaKm },
                new { Concepto = "Costo total", Monto = viaje.CostoBase },
                new { Concepto = "Ferri", Monto = viaje.CostoFerry },
                new { Concepto = "Hospedaje", Monto = viaje.CostoHospedaje },
                new { Concepto = "Insumos", Monto = viaje.CostoInsumos }
            };

            DgvDesglosePrecioSoloDelCombustibleGuardado.DataSource = null;
            DgvDesglosePrecioSoloDelCombustibleGuardado.DataSource = desglose;

            DgvDesglosePrecioTotalGuardados.DataSource = null;
            DgvDesglosePrecioTotalGuardados.DataSource = desglose;
        }

        private void SeleccionarCombo(ComboBox combo, int valorId)
        {
            if (combo.Items.Count == 0)
                return;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is Vehiculo v && v.Id == valorId)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        private void SeleccionarCombo(ComboBox combo, string valorNombre)
        {
            if (combo.Items.Count == 0)
                return;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is Destino d && d.Nombre.Equals(valorNombre, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckListBoxViaje.SelectedItem is Viaje viaje)
            {
                _viajePresenter.ObtenerViajePorId(viaje.Id);
                MostrarDesgloseDelViaje(viaje);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularDesglose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularDesglose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RecalcularDesglose();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularDesglose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
