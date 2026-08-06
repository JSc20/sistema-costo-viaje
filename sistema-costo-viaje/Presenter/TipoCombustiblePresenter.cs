using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los tipos de combustible.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="TipoCombustibleLogicaNegocio"/> como modelo.
    /// </summary>
    public class TipoCombustiblePresenter : PresenterBase
    {
        private readonly TipoCombustibleLogicaNegocio _tipoCombustibleBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public TipoCombustiblePresenter(object view) : base(new TipoCombustibleLogicaNegocio(), view)
        {
            _tipoCombustibleBL = (TipoCombustibleLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de tipos de combustible.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los tipos de combustible del modelo
            var tiposCombustible = _tipoCombustibleBL.ObtenerTodos();

            // Si la vista expone un método SetTiposCombustible, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetTiposCombustible");
            method?.Invoke(_view, new object[] { tiposCombustible });
        }

        /// <summary>
        /// Obtiene un tipo de combustible por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del tipo de combustible.</param>
        public void ObtenerTipoCombustiblePorId(int id)
        {
            var tipoCombustible = _tipoCombustibleBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetTipoCombustible");
            method?.Invoke(_view, new object[] { tipoCombustible });
        }

        /// <summary>
        /// Crea un nuevo tipo de combustible y actualiza la vista.
        /// </summary>
        /// <param name="tipoCombustible">Objeto TipoCombustible a crear.</param>
        public void CrearTipoCombustible(TipoCombustible tipoCombustible)
        {
            _tipoCombustibleBL.Crear(tipoCombustible);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un tipo de combustible existente y actualiza la vista.
        /// </summary>
        /// <param name="tipoCombustible">Objeto TipoCombustible con los cambios.</param>
        public void ActualizarTipoCombustible(TipoCombustible tipoCombustible)
        {
            _tipoCombustibleBL.Actualizar(tipoCombustible);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un tipo de combustible por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del tipo de combustible a eliminar.</param>
        public void EliminarTipoCombustible(int id)
        {
            _tipoCombustibleBL.Eliminar(id);
            ActualizarVista();
        }
    }
}
