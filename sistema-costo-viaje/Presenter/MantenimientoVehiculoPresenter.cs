using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con el mantenimiento de vehículos.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="MantenimientoVehiculoLogicaNegocio"/> como modelo.
    /// </summary>
    public class MantenimientoVehiculoPresenter : PresenterBase
    {
        private readonly MantenimientoVehiculoLogicaNegocio _mantenimientoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public MantenimientoVehiculoPresenter(object view) : base(new MantenimientoVehiculoLogicaNegocio(), view)
        {
            _mantenimientoBL = (MantenimientoVehiculoLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de mantenimientos de vehículos.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los mantenimientos del modelo
            var mantenimientos = _mantenimientoBL.ObtenerTodos();

            // Si la vista expone un método SetMantenimientos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetMantenimientos");
            method?.Invoke(_view, new object[] { mantenimientos });
        }

        /// <summary>
        /// Obtiene un mantenimiento por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del mantenimiento.</param>
        public void ObtenerMantenimientoPorId(int id)
        {
            var mantenimiento = _mantenimientoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetMantenimiento");
            method?.Invoke(_view, new object[] { mantenimiento });
        }

        /// <summary>
        /// Obtiene mantenimientos por ID de vehículo y los pasa a la vista.
        /// </summary>
        /// <param name="vehiculoId">Identificador del vehículo.</param>
        public void ObtenerMantenimientosPorVehiculoId(int vehiculoId)
        {
            var mantenimientos = _mantenimientoBL.ObtenerPorVehiculoId(vehiculoId);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetMantenimientos");
            method?.Invoke(_view, new object[] { mantenimientos });
        }

        /// <summary>
        /// Crea un nuevo mantenimiento y actualiza la vista.
        /// </summary>
        /// <param name="mantenimiento">Objeto MantenimientoVehiculo a crear.</param>
        public void CrearMantenimiento(MantenimientoVehiculo mantenimiento)
        {
            _mantenimientoBL.Crear(mantenimiento);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un mantenimiento existente y actualiza la vista.
        /// </summary>
        /// <param name="mantenimiento">Objeto MantenimientoVehiculo con los cambios.</param>
        public void ActualizarMantenimiento(MantenimientoVehiculo mantenimiento)
        {
            _mantenimientoBL.Actualizar(mantenimiento);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un mantenimiento por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del mantenimiento a eliminar.</param>
        public void EliminarMantenimiento(int id)
        {
            _mantenimientoBL.Eliminar(id);
            ActualizarVista();
        }

        /// <summary>
        /// Calcula el costo por kilómetro.
        /// </summary>
        /// <param name="costoTotal">Costo total del mantenimiento.</param>
        /// <param name="kmIntervalo">Intervalo de kilómetros.</param>
        /// <returns>Costo por kilómetro.</returns>
        public decimal CalcularCostoPorKm(decimal costoTotal, int kmIntervalo)
        {
            return _mantenimientoBL.CalcularCostoPorKm(costoTotal, kmIntervalo);
        }
    }
}
