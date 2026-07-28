using System;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Clase base Presenter que actúa como intermediaria entre la Vista y el Modelo
    /// Implementa el patrón MVP (Model-View-Presenter)
    /// </summary>
    public abstract class PresenterBase
    {
        protected object _model;
        protected object _view;

        public PresenterBase(object model, object view)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <summary>
        /// Método virtual para inicializar la vista
        /// </summary>
        public virtual void Inicializar()
        {
            Console.WriteLine("Presenter inicializado");
        }

        /// <summary>
        /// Método virtual para actualizar la vista
        /// </summary>
        public virtual void ActualizarVista()
        {
            Console.WriteLine("Vista actualizada");
        }

        /// <summary>
        /// Obtiene el modelo
        /// </summary>
        public object ObtenerModelo() => _model;

        /// <summary>
        /// Obtiene la vista
        /// </summary>
        public object ObtenerVista() => _view;
    }
}