using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los viáticos de viaje.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="ViaticoViajeLogicaNegocio"/> como modelo.
    /// </summary>
    public class ViaticoViajePresenter : PresenterBase
    {
        private readonly ViaticoViajeLogicaNegocio _viaticoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public ViaticoViajePresenter(object view) : base(new ViaticoViajeLogicaNegocio(), view)
        {
            _viaticoBL = (ViaticoViajeLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de viáticos de viaje.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los viáticos del modelo
            var viaticos = _viaticoBL.ObtenerTodos();

            // Si la vista expone un método SetViaticos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetViaticos");
            method?.Invoke(_view, new object[] { viaticos });
        }

        /// <summary>
        /// Obtiene un viático por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del viático.</param>
        public void ObtenerViaticoPorId(int id)
        {
            var viatico = _viaticoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetViatico");
            method?.Invoke(_view, new object[] { viatico });
        }

        /// <summary>
        /// Obtiene viáticos por ID de viaje y los pasa a la vista.
        /// </summary>
        /// <param name="viajeId">Identificador del viaje.</param>
        public void ObtenerViaticosPorViajeId(int viajeId)
        {
            var viaticos = _viaticoBL.ObtenerPorViajeId(viajeId);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetViaticos");
            method?.Invoke(_view, new object[] { viaticos });
        }

        /// <summary>
        /// Crea un nuevo viático y actualiza la vista.
        /// </summary>
        /// <param name="viatico">Objeto ViaticoViaje a crear.</param>
        public void CrearViatico(ViaticoViaje viatico)
        {
            _viaticoBL.Crear(viatico);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un viático existente y actualiza la vista.
        /// </summary>
        /// <param name="viatico">Objeto ViaticoViaje con los cambios.</param>
        public void ActualizarViatico(ViaticoViaje viatico)
        {
            _viaticoBL.Actualizar(viatico);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un viático por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del viático a eliminar.</param>
        public void EliminarViatico(int id)
        {
            _viaticoBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
