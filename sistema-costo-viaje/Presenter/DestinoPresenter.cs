using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los destinos.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="DestinoLogicaNegocio"/> como modelo.
    /// </summary>
    public class DestinoPresenter : PresenterBase
    {
        private readonly DestinoLogicaNegocio _destinoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public DestinoPresenter(object view) : base(new DestinoLogicaNegocio(), view)
        {
            _destinoBL = (DestinoLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de destinos.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los destinos del modelo
            var destinos = _destinoBL.ObtenerTodos();

            // Si la vista expone un método SetDestinos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetDestinos");
            method?.Invoke(_view, new object[] { destinos });
        }

        /// <summary>
        /// Obtiene un destino por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del destino.</param>
        public void ObtenerDestinoPorId(int id)
        {
            var destino = _destinoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetDestino");
            method?.Invoke(_view, new object[] { destino });
        }

        /// <summary>
        /// Crea un nuevo destino y actualiza la vista.
        /// </summary>
        /// <param name="destino">Objeto Destino a crear.</param>
        public void CrearDestino(Destino destino)
        {
            _destinoBL.Crear(destino);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un destino existente y actualiza la vista.
        /// </summary>
        /// <param name="destino">Objeto Destino con los cambios.</param>
        public void ActualizarDestino(Destino destino)
        {
            _destinoBL.Actualizar(destino);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un destino por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del destino a eliminar.</param>
        public void EliminarDestino(int id)
        {
            _destinoBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
