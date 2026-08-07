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
    public partial class Menú_Vehículos : Form
    {
        private VehiculoPresenter _vehiculoPresenter;
        private RendimientoVehiculoPresenter _rendimientoPresenter;
        private MantenimientoVehiculoPresenter _mantenimientoPresenter;

        private List<Vehiculo> _vehiculos = new();
        private List<RendimientoVehiculo> _rendimientos = new();
        private List<MantenimientoVehiculo> _mantenimientos = new();

        private Vehiculo _vehiculoSeleccionado;
        private RendimientoVehiculo _rendimientoSeleccionado;
        private MantenimientoVehiculo _mantenimientoSeleccionado;

        public Menú_Vehículos()
        {
            InitializeComponent();
        }

        private void Menú_Vehículos_Load(object sender, EventArgs e)
        {
            _vehiculoPresenter = new VehiculoPresenter(this);
            _rendimientoPresenter = new RendimientoVehiculoPresenter(this);
            _mantenimientoPresenter = new MantenimientoVehiculoPresenter(this);

            _vehiculoPresenter.Inicializar();
            _rendimientoPresenter.Inicializar();
            _mantenimientoPresenter.Inicializar();
        }

        public void SetVehiculos(List<Vehiculo> vehiculos)
        {
            _vehiculos = vehiculos;
            DgvListaDeListaVehiculos.DataSource = null;
            DgvListaDeListaVehiculos.DataSource = _vehiculos;
            _vehiculoSeleccionado = _vehiculos.FirstOrDefault();

            ComboBoxVehiculoRendimiento.DataSource = null;
            ComboBoxVehiculoRendimiento.DataSource = _vehiculos;
            ComboBoxVehiculoRendimiento.DisplayMember = nameof(Vehiculo.Modelo);
            ComboBoxVehiculoRendimiento.ValueMember = nameof(Vehiculo.Id);

            ComboBoxVehiculoMantenimiento.DataSource = null;
            ComboBoxVehiculoMantenimiento.DataSource = _vehiculos;
            ComboBoxVehiculoMantenimiento.DisplayMember = nameof(Vehiculo.Modelo);
            ComboBoxVehiculoMantenimiento.ValueMember = nameof(Vehiculo.Id);
        }

        public void SetVehiculo(Vehiculo vehiculo)
        {
            _vehiculoSeleccionado = vehiculo;
            if (vehiculo == null)
                return;

            TextBoxMarcaVehiculo.Text = vehiculo.Marca;
            TextBoxModeloVehiculo.Text = vehiculo.Modelo;
            TextBoxAnioVehiculo.Text = vehiculo.Año.ToString();
            TextBoxCostoPorKmVehiculo.Text = vehiculo.CostoPorKm.ToString();
            TextBoxValorActualVehiculo.Text = vehiculo.ValorActual.ToString();
            TextBoxValorFuturoVehiculo.Text = vehiculo.ValorFuturo.ToString();
            TextBoxKmActualVehiculo.Text = vehiculo.KmRestantesUso.ToString();
            TextBoxKmAnualesVehiculo.Text = vehiculo.KmAnuales.ToString();
            TextBoxCostosFijosAnualesVehiculo.Text = vehiculo.CostosFijosAnuales.ToString();
        }

        public void SetRendimientos(List<RendimientoVehiculo> rendimientos)
        {
            _rendimientos = rendimientos;
            DgvListaRendimientoVehiculo.DataSource = null;
            DgvListaRendimientoVehiculo.DataSource = _rendimientos;
            _rendimientoSeleccionado = _rendimientos.FirstOrDefault();
        }

        public void SetRendimiento(RendimientoVehiculo rendimiento)
        {
            _rendimientoSeleccionado = rendimiento;
            if (rendimiento == null)
                return;

            TextBoxTipoEntornoRendimientoVehiculo.Text = rendimiento.tipo_entorno;
            TextBoxCostoXKmRendimientoVehiculo.Text = rendimiento.costo_por_km.ToString();
            TextBoxKmXLitroRendimientoVehiculo.Text = rendimiento.km_por_litro.ToString();
        }

        public void SetMantenimientos(List<MantenimientoVehiculo> mantenimientos)
        {
            _mantenimientos = mantenimientos;
            DgvListaMantenimientoVehiculo.DataSource = null;
            DgvListaMantenimientoVehiculo.DataSource = _mantenimientos;
            _mantenimientoSeleccionado = _mantenimientos.FirstOrDefault();
        }

        public void SetMantenimiento(MantenimientoVehiculo mantenimiento)
        {
            _mantenimientoSeleccionado = mantenimiento;
            if (mantenimiento == null)
                return;

            TextBoxDescripcionMantenimientoVehiculo.Text = mantenimiento.Descripcion;
            TextBoxCostoTotalMantenimientoVehiculo.Text = mantenimiento.CostoTotal.ToString();
            TextBoxIntervaloXKmMantenimientoVehiculo.Text = mantenimiento.KmIntervalo.ToString();
            TextBoxCostoRealXKmMantenimientoVehiculo.Text = mantenimiento.CostoPorKm.ToString();
        }

        private void BtnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                var vehiculo = ConstruirVehiculo();
                _vehiculoPresenter.CrearVehiculo(vehiculo);
                MessageBox.Show("Vehículo guardado exitosamente.", "Gestión de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_vehiculoSeleccionado == null)
                    throw new ArgumentException("No hay un vehículo seleccionado para editar");

                var vehiculo = ConstruirVehiculo();
                vehiculo.Id = _vehiculoSeleccionado.Id;

                _vehiculoPresenter.ActualizarVehiculo(vehiculo);
                MessageBox.Show("Vehículo actualizado exitosamente.", "Gestión de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_vehiculoSeleccionado == null)
                    throw new ArgumentException("No hay un vehículo seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el vehículo '{_vehiculoSeleccionado.Modelo}'? Se eliminarán también sus rendimientos y mantenimientos.",
                    "Eliminar Vehículo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                var eliminado = _vehiculoPresenter.EliminarVehiculo(_vehiculoSeleccionado.Id);
                if (!eliminado)
                    throw new InvalidOperationException("No se encontró el vehículo para eliminar");

                _rendimientoPresenter.ActualizarVista();
                _mantenimientoPresenter.ActualizarVista();
                MessageBox.Show("Vehículo eliminado exitosamente.", "Gestión de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarRendimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                var rendimiento = ConstruirRendimiento();
                _rendimientoPresenter.CrearRendimiento(rendimiento);
                MessageBox.Show("Rendimiento guardado exitosamente.", "Rendimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioRendimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarRendimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rendimientoSeleccionado == null)
                    throw new ArgumentException("No hay un rendimiento seleccionado para editar");

                var rendimiento = ConstruirRendimiento();
                rendimiento.id = _rendimientoSeleccionado.id;

                _rendimientoPresenter.ActualizarRendimiento(rendimiento);
                MessageBox.Show("Rendimiento actualizado exitosamente.", "Rendimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioRendimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarRendimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rendimientoSeleccionado == null)
                    throw new ArgumentException("No hay un rendimiento seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    "¿Desea eliminar el rendimiento seleccionado?",
                    "Eliminar Rendimiento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _rendimientoPresenter.EliminarRendimiento(_rendimientoSeleccionado.id);
                MessageBox.Show("Rendimiento eliminado exitosamente.", "Rendimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioRendimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarMantenimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                var mantenimiento = ConstruirMantenimiento();
                _mantenimientoPresenter.CrearMantenimiento(mantenimiento);
                MessageBox.Show("Mantenimiento guardado exitosamente.", "Mantenimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioMantenimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditarMantenimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mantenimientoSeleccionado == null)
                    throw new ArgumentException("No hay un mantenimiento seleccionado para editar");

                var mantenimiento = ConstruirMantenimiento();
                mantenimiento.Id = _mantenimientoSeleccionado.Id;

                _mantenimientoPresenter.ActualizarMantenimiento(mantenimiento);
                MessageBox.Show("Mantenimiento actualizado exitosamente.", "Mantenimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioMantenimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarMantenimientoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mantenimientoSeleccionado == null)
                    throw new ArgumentException("No hay un mantenimiento seleccionado para eliminar");

                var confirmacion = MessageBox.Show(
                    "¿Desea eliminar el mantenimiento seleccionado?",
                    "Eliminar Mantenimiento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                _mantenimientoPresenter.EliminarMantenimiento(_mantenimientoSeleccionado.Id);
                MessageBox.Show("Mantenimiento eliminado exitosamente.", "Mantenimiento del Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioMantenimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Vehiculo ConstruirVehiculo()
        {
            if (string.IsNullOrWhiteSpace(TextBoxMarcaVehiculo.Text))
                throw new ArgumentException("La marca del vehículo es requerida");

            if (string.IsNullOrWhiteSpace(TextBoxModeloVehiculo.Text))
                throw new ArgumentException("El modelo del vehículo es requerido");

            if (!int.TryParse(TextBoxAnioVehiculo.Text, out int anio) || anio < 1900 || anio > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del vehículo no es válido");

            if (!decimal.TryParse(TextBoxCostoPorKmVehiculo.Text, out decimal costoPorKm) || costoPorKm <= 0)
                throw new ArgumentException("El costo por kilómetro debe ser mayor a 0");

            if (!decimal.TryParse(TextBoxValorActualVehiculo.Text, out decimal valorActual) || valorActual < 0)
                throw new ArgumentException("El valor actual no es válido");

            if (!decimal.TryParse(TextBoxValorFuturoVehiculo.Text, out decimal valorFuturo) || valorFuturo < 0)
                throw new ArgumentException("El valor futuro no es válido");

            if (!int.TryParse(TextBoxKmActualVehiculo.Text, out int kmRestantes) || kmRestantes < 0)
                throw new ArgumentException("El kilometraje actual no es válido");

            if (!int.TryParse(TextBoxKmAnualesVehiculo.Text, out int kmAnuales) || kmAnuales < 0)
                throw new ArgumentException("Los kilómetros anuales no son válidos");

            if (!decimal.TryParse(TextBoxCostosFijosAnualesVehiculo.Text, out decimal costosFijosAnuales) || costosFijosAnuales < 0)
                throw new ArgumentException("Los costos fijos anuales no son válidos");

            return new Vehiculo
            {
                Marca = TextBoxMarcaVehiculo.Text.Trim(),
                Modelo = TextBoxModeloVehiculo.Text.Trim(),
                Año = anio,
                CostoPorKm = costoPorKm,
                ValorActual = valorActual,
                ValorFuturo = valorFuturo,
                KmRestantesUso = kmRestantes,
                KmAnuales = kmAnuales,
                CostosFijosAnuales = costosFijosAnuales
            };
        }

        private RendimientoVehiculo ConstruirRendimiento()
        {
            if (ComboBoxVehiculoRendimiento.SelectedItem is not Vehiculo vehiculo)
                throw new ArgumentException("Seleccione primero un vehículo");

            if (string.IsNullOrWhiteSpace(TextBoxTipoEntornoRendimientoVehiculo.Text))
                throw new ArgumentException("El tipo de entorno es requerido");

            if (!decimal.TryParse(TextBoxCostoXKmRendimientoVehiculo.Text, out decimal costoPorKm) || costoPorKm < 0)
                throw new ArgumentException("El costo por kilómetro no es válido");

            if (!decimal.TryParse(TextBoxKmXLitroRendimientoVehiculo.Text, out decimal kmPorLitro) || kmPorLitro <= 0)
                throw new ArgumentException("Los kilómetros por litro deben ser mayor a 0");

            return new RendimientoVehiculo
            {
                vehiculo_id = vehiculo.Id,
                tipo_combustible_id = 1,
                tipo_entorno = TextBoxTipoEntornoRendimientoVehiculo.Text.Trim(),
                costo_por_km = costoPorKm,
                km_por_litro = kmPorLitro
            };
        }

        private MantenimientoVehiculo ConstruirMantenimiento()
        {
            if (ComboBoxVehiculoMantenimiento.SelectedItem is not Vehiculo vehiculo)
                throw new ArgumentException("Seleccione primero un vehículo");

            if (string.IsNullOrWhiteSpace(TextBoxDescripcionMantenimientoVehiculo.Text))
                throw new ArgumentException("La descripción del mantenimiento es requerida");

            if (!decimal.TryParse(TextBoxCostoTotalMantenimientoVehiculo.Text, out decimal costoTotal) || costoTotal < 0)
                throw new ArgumentException("El costo total no es válido");

            if (!int.TryParse(TextBoxIntervaloXKmMantenimientoVehiculo.Text, out int kmIntervalo) || kmIntervalo <= 0)
                throw new ArgumentException("El intervalo en kilómetros debe ser mayor a 0");

            var costoPorKm = _mantenimientoPresenter.CalcularCostoPorKm(costoTotal, kmIntervalo);
            TextBoxCostoRealXKmMantenimientoVehiculo.Text = costoPorKm.ToString();

            return new MantenimientoVehiculo
            {
                VehiculoId = vehiculo.Id,
                Descripcion = TextBoxDescripcionMantenimientoVehiculo.Text.Trim(),
                CostoTotal = costoTotal,
                KmIntervalo = kmIntervalo,
                CostoPorKm = costoPorKm
            };
        }

        private void DgvListaDeListaVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DgvListaDeListaVehiculos.Rows.Count == 0)
                return;

            if (DgvListaDeListaVehiculos.CurrentRow?.DataBoundItem is not Vehiculo vehiculo)
                return;

            _vehiculoPresenter.ObtenerVehiculoPorId(vehiculo.Id);
            _rendimientoPresenter.ObtenerRendimientosPorVehiculoId(vehiculo.Id);
            _mantenimientoPresenter.ObtenerMantenimientosPorVehiculoId(vehiculo.Id);

            ComboBoxVehiculoRendimiento.SelectedItem = vehiculo;
            ComboBoxVehiculoMantenimiento.SelectedItem = vehiculo;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (sender is DataGridView grilla && grilla.CurrentRow?.DataBoundItem is RendimientoVehiculo rendimiento)
            {
                _rendimientoPresenter.ObtenerRendimientoPorId(rendimiento.id);
            }
            else if (sender is DataGridView grillaMantenimiento &&
                     grillaMantenimiento.CurrentRow?.DataBoundItem is MantenimientoVehiculo mantenimiento)
            {
                _mantenimientoPresenter.ObtenerMantenimientoPorId(mantenimiento.Id);
            }
        }

        private void LimpiarFormularioVehiculo()
        {
            TextBoxMarcaVehiculo.Clear();
            TextBoxModeloVehiculo.Clear();
            TextBoxAnioVehiculo.Clear();
            TextBoxCostoPorKmVehiculo.Clear();
            TextBoxValorActualVehiculo.Clear();
            TextBoxValorFuturoVehiculo.Clear();
            TextBoxKmActualVehiculo.Clear();
            TextBoxKmAnualesVehiculo.Clear();
            TextBoxCostosFijosAnualesVehiculo.Clear();
        }

        private void LimpiarFormularioRendimiento()
        {
            TextBoxTipoEntornoRendimientoVehiculo.Clear();
            TextBoxCostoXKmRendimientoVehiculo.Clear();
            TextBoxKmXLitroRendimientoVehiculo.Clear();
        }

        private void LimpiarFormularioMantenimiento()
        {
            TextBoxDescripcionMantenimientoVehiculo.Clear();
            TextBoxCostoTotalMantenimientoVehiculo.Clear();
            TextBoxIntervaloXKmMantenimientoVehiculo.Clear();
            TextBoxCostoRealXKmMantenimientoVehiculo.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
