using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los peajes.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="PeajeLogicaNegocio"/> como modelo.
    /// </summary>
    public class PeajePresenter : PresenterBase
    {
        private readonly PeajeLogicaNegocio _peajeBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public PeajePresenter(object view) : base(new PeajeLogicaNegocio(), view)
        {
            _peajeBL = (PeajeLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de peajes.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los peajes del modelo
            var peajes = _peajeBL.ObtenerTodos();

            // Si la vista expone un método SetPeajes, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetPeajes");
            method?.Invoke(_view, new object[] { peajes });
        }

        /// <summary>
        /// Obtiene un peaje por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del peaje.</param>
        public void ObtenerPeajePorId(int id)
        {
            var peaje = _peajeBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetPeaje");
            method?.Invoke(_view, new object[] { peaje });
        }

        /// <summary>
        /// Crea un nuevo peaje y actualiza la vista.
        /// </summary>
        /// <param name="peaje">Objeto Peaje a crear.</param>
        public void CrearPeaje(Peaje peaje)
        {
            _peajeBL.Crear(peaje);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un peaje existente y actualiza la vista.
        /// </summary>
        /// <param name="peaje">Objeto Peaje con los cambios.</param>
        public void ActualizarPeaje(Peaje peaje)
        {
            _peajeBL.Actualizar(peaje);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un peaje por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del peaje a eliminar.</param>
        public void EliminarPeaje(int id)
        {
            _peajeBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
