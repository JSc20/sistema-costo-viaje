using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los viajes.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="ViajeLogicaNegocio"/> como modelo.
    /// </summary>
    public class ViajePresenter : PresenterBase
    {
        private readonly ViajeLogicaNegocio _viajeBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public ViajePresenter(object view) : base(new ViajeLogicaNegocio(), view)
        {
            _viajeBL = (ViajeLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de viajes.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los viajes del modelo
            var viajes = _viajeBL.ObtenerTodos();

            // Si la vista expone un método SetViajes, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetViajes");
            method?.Invoke(_view, new object[] { viajes });
        }

        /// <summary>
        /// Obtiene un viaje por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del viaje.</param>
        public void ObtenerViajePorId(int id)
        {
            var viaje = _viajeBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetViaje");
            method?.Invoke(_view, new object[] { viaje });
        }

        /// <summary>
        /// Crea un nuevo viaje y actualiza la vista.
        /// </summary>
        /// <param name="viaje">Objeto Viaje a crear.</param>
        public void CrearViaje(Viaje viaje)
        {
            _viajeBL.Crear(viaje);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un viaje existente y actualiza la vista.
        /// </summary>
        /// <param name="viaje">Objeto Viaje con los cambios.</param>
        public void ActualizarViaje(Viaje viaje)
        {
            _viajeBL.Actualizar(viaje);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un viaje por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del viaje a eliminar.</param>
        public void EliminarViaje(int id)
F        {
            _viajeBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
