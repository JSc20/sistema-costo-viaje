using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los vehículos.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="VehiculoLogicaNegocio"/> como modelo.
    /// </summary>
    public class VehiculoPresenter : PresenterBase
    {
        private readonly VehiculoLogicaNegocio _vehiculoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public VehiculoPresenter(object view) : base(new VehiculoLogicaNegocio(), view)
        {
            _vehiculoBL = (VehiculoLogicaNegocio)_model;
            _view = view;
        }

        /// <summary>
        /// Inicializa la vista y carga los datos iniciales.
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza la vista con la lista completa de vehículos.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los vehículos del modelo
            var vehiculos = _vehiculoBL.ObtenerTodos();

            // Si la vista expone un método SetVehiculos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetVehiculos");
            method?.Invoke(_view, new object[] { vehiculos });
        }

        /// <summary>
        /// Obtiene un vehículo por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del vehículo.</param>
        public void ObtenerVehiculoPorId(int id)
        {
            var vehiculo = _vehiculoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetVehiculo");
            method?.Invoke(_view, new object[] { vehiculo });
        }

        /// <summary>
        /// Crea un nuevo vehículo y actualiza la vista.
        /// </summary>
        /// <param name="vehiculo">Objeto Vehiculo a crear.</param>
        public void CrearVehiculo(Vehiculo vehiculo)
        {
            _vehiculoBL.Crear(vehiculo);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un vehículo existente y actualiza la vista.
        /// </summary>
        /// <param name="vehiculo">Objeto Vehiculo con los cambios.</param>
        public void ActualizarVehiculo(Vehiculo vehiculo)
        {
            _vehiculoBL.Actualizar(vehiculo);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un vehículo por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del vehículo a eliminar.</param>
        /// <returns>True si el vehículo existía y fue eliminado; de lo contrario, false.</returns>
        public bool EliminarVehiculo(int id)
        {
            var eliminado = _vehiculoBL.Eliminar(id);
            if (eliminado)
                ActualizarVista();

            return eliminado;
        }

        /// <summary>
        /// Calcula el costo operacional de un vehículo.
        /// </summary>
        /// <param name="vehiculoId">Identificador del vehículo.</param>
        /// <returns>Costo operacional del vehículo.</returns>
        public decimal CalcularCostoOperacional(int vehiculoId)
        {
            return _vehiculoBL.CalcularCostoOperacional(vehiculoId);
        }
    }
}
