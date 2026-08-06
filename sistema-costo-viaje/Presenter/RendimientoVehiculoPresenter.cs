using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con el rendimiento de vehículos.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="RendimientoVehiculoLogicaNegocio"/> como modelo.
    /// </summary>
    public class RendimientoVehiculoPresenter : PresenterBase
    {
        private readonly RendimientoVehiculoLogicaNegocio _rendimientoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public RendimientoVehiculoPresenter(object view) : base(new RendimientoVehiculoLogicaNegocio(), view)
        {
            _rendimientoBL = (RendimientoVehiculoLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de rendimientos de vehículos.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los rendimientos del modelo
            var rendimientos = _rendimientoBL.ObtenerTodos();

            // Si la vista expone un método SetRendimientos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetRendimientos");
            method?.Invoke(_view, new object[] { rendimientos });
        }

        /// <summary>
        /// Obtiene un rendimiento por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del rendimiento.</param>
        public void ObtenerRendimientoPorId(int id)
        {
            var rendimiento = _rendimientoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetRendimiento");
            method?.Invoke(_view, new object[] { rendimiento });
        }

        /// <summary>
        /// Obtiene rendimientos por ID de vehículo y los pasa a la vista.
        /// </summary>
        /// <param name="vehiculoId">Identificador del vehículo.</param>
        public void ObtenerRendimientosPorVehiculoId(int vehiculoId)
        {
            var rendimientos = _rendimientoBL.ObtenerPorVehiculoId(vehiculoId);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetRendimientos");
            method?.Invoke(_view, new object[] { rendimientos });
        }

        /// <summary>
        /// Crea un nuevo rendimiento y actualiza la vista.
        /// </summary>
        /// <param name="rendimiento">Objeto RendimientoVehiculo a crear.</param>
        public void CrearRendimiento(RendimientoVehiculo rendimiento)
        {
            _rendimientoBL.Crear(rendimiento);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un rendimiento existente y actualiza la vista.
        /// </summary>
        /// <param name="rendimiento">Objeto RendimientoVehiculo con los cambios.</param>
        public void ActualizarRendimiento(RendimientoVehiculo rendimiento)
        {
            _rendimientoBL.Actualizar(rendimiento);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un rendimiento por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del rendimiento a eliminar.</param>
        public void EliminarRendimiento(int id)
        {
            _rendimientoBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
