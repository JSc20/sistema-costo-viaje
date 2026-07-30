using System.Collections.Generic;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.VL
{
    public class TecnicoValidador
    {
        private readonly List<string> _errores;

        public TecnicoValidador()
        {
            _errores = new List<string>();
        }

        public bool Validar(Tecnico tecnico)
        {
            _errores.Clear();

            if (tecnico == null)
            {
                _errores.Add("El técnico no puede ser nulo");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tecnico.nombre))
                _errores.Add("El nombre del técnico es requerido");

            if (tecnico.salario_mensual < 0)
                _errores.Add("El salario mensual no puede ser negativo");

            if (tecnico.horas_semanales <= 0)
                _errores.Add("Las horas semanales deben ser mayor a 0");
            else if (tecnico.horas_semanales > 168)
                _errores.Add("Las horas semanales no pueden exceder 168");

            if (tecnico.costo_hora_ordinaria < 0)
                _errores.Add("El costo de hora ordinaria no puede ser negativo");

            if (tecnico.costo_hora_extra < 0)
                _errores.Add("El costo de hora extra no puede ser negativo");

            return _errores.Count == 0;
        }

        public List<string> ObtenerErrores()
        {
            return new List<string>(_errores);
        }
    }
}
