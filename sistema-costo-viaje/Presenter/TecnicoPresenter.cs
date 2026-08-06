using System;
using SistemaCostoViaje.BL;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.Presenter
{
    /// <summary>
    /// Presenter encargado de la lógica de negocio relacionada con los técnicos.
    /// Hereda de <see cref="PresenterBase"/> y utiliza <see cref="TecnicoLogicaNegocio"/> como modelo.
    /// </summary>
    public class TecnicoPresenter : PresenterBase
    {
        private readonly TecnicoLogicaNegocio _tecnicoBL;
        private readonly object _view;

        /// <summary>
        /// Crea una nueva instancia del presenter.
        /// </summary>
        /// <param name="view">Objeto que representa la vista (puede ser una interfaz).</param>
        public TecnicoPresenter(object view) : base(new TecnicoLogicaNegocio(), view)
        {
            _tecnicoBL = (TecnicoLogicaNegocio)_model;
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
        /// Actualiza la vista con la lista completa de técnicos.
        /// </summary>
        public override void ActualizarVista()
        {
            base.ActualizarVista();

            // Obtener todos los técnicos del modelo
            var tecnicos = _tecnicoBL.ObtenerTodos();

            // Si la vista expone un método SetTecnicos, lo invocamos mediante reflexión
            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetTecnicos");
            method?.Invoke(_view, new object[] { tecnicos });
        }

        /// <summary>
        /// Obtiene un técnico por su identificador y lo pasa a la vista.
        /// </summary>
        /// <param name="id">Identificador del técnico.</param>
        public void ObtenerTecnicoPorId(int id)
        {
            var tecnico = _tecnicoBL.ObtenerPorId(id);

            var viewType = _view.GetType();
            var method = viewType.GetMethod("SetTecnico");
            method?.Invoke(_view, new object[] { tecnico });
        }

        /// <summary>
        /// Crea un nuevo técnico y actualiza la vista.
        /// </summary>
        /// <param name="tecnico">Objeto Tecnico a crear.</param>
        public void CrearTecnico(Tecnico tecnico)
        {
            _tecnicoBL.Crear(tecnico);
            ActualizarVista();
        }

        /// <summary>
        /// Actualiza un técnico existente y actualiza la vista.
        /// </summary>
        /// <param name="tecnico">Objeto Tecnico con los cambios.</param>
        public void ActualizarTecnico(Tecnico tecnico)
        {
            _tecnicoBL.Actualizar(tecnico);
            ActualizarVista();
        }

        /// <summary>
        /// Elimina un técnico por su identificador y actualiza la vista.
        /// </summary>
        /// <param name="id">Identificador del técnico a eliminar.</param>
        public void EliminarTecnico(int id)
        {
            _tecnicoBL.Eliminar(id);
            ActualizarVista();
        }

        /// <summary>
        /// Calcula el costo por hora ordinaria.
        /// </summary>
        /// <param name="salarioMensual">Salario mensual del técnico.</param>
        /// <param name="horasSemanales">Horas semanales trabajadas.</param>
        /// <returns>Costo por hora ordinaria.</returns>
        public decimal CalcularCostoHoraOrdinaria(decimal salarioMensual, int horasSemanales)
        {
            return _tecnicoBL.CalcularCostoHoraOrdinaria(salarioMensual, horasSemanales);
        }

        /// <summary>
        /// Calcula el costo por hora extra.
        /// </summary>
        /// <param name="costoHoraOrdinaria">Costo por hora ordinaria.</param>
        /// <param name="factorRecargo">Factor de recargo para horas extra (por defecto 1.5).</param>
        /// <returns>Costo por hora extra.</returns>
        public decimal CalcularCostoHoraExtra(decimal costoHoraOrdinaria, decimal factorRecargo = 1.5m)
        {
            return _tecnicoBL.CalcularCostoHoraExtra(costoHoraOrdinaria, factorRecargo);
        }
    }
}
