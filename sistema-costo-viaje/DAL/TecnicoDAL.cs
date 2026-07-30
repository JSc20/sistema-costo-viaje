using System.Collections.Generic;
using System.Linq;
using SistemaCostoViaje.EL;

namespace SistemaCostoViaje.DAL
{
    public class TecnicoDAL
    {
        private static readonly List<Tecnico> _tecnicos = new();
        private static int _nextId = 1;

        public List<Tecnico> ObtenerTodos()
        {
            return _tecnicos.Select(Clone).ToList();
        }

        public Tecnico? ObtenerPorId(int id)
        {
            return Clone(_tecnicos.FirstOrDefault(t => t.id == id));
        }

        public Tecnico Crear(Tecnico tecnico)
        {
            var nuevoTecnico = Clone(tecnico);
            nuevoTecnico.id = _nextId++;
            _tecnicos.Add(nuevoTecnico);
            return Clone(nuevoTecnico);
        }

        public Tecnico? Actualizar(Tecnico tecnico)
        {
            var existente = _tecnicos.FirstOrDefault(t => t.id == tecnico.id);
            if (existente == null)
                return null;

            existente.nombre = tecnico.nombre;
            existente.salario_mensual = tecnico.salario_mensual;
            existente.horas_semanales = tecnico.horas_semanales;
            existente.costo_hora_ordinaria = tecnico.costo_hora_ordinaria;
            existente.costo_hora_extra = tecnico.costo_hora_extra;

            return Clone(existente);
        }

        public bool Eliminar(int id)
        {
            var tecnico = _tecnicos.FirstOrDefault(t => t.id == id);
            if (tecnico == null)
                return false;

            return _tecnicos.Remove(tecnico);
        }

        private static Tecnico Clone(Tecnico? tecnico)
        {
            if (tecnico == null)
                return null!;

            return new Tecnico
            {
                id = tecnico.id,
                nombre = tecnico.nombre,
                salario_mensual = tecnico.salario_mensual,
                horas_semanales = tecnico.horas_semanales,
                costo_hora_ordinaria = tecnico.costo_hora_ordinaria,
                costo_hora_extra = tecnico.costo_hora_extra
            };
        }
    }
}
