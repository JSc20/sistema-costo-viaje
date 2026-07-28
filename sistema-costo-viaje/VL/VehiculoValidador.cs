using System;

namespace SistemaCostoViaje.VL
{
    public class VehiculoValidador
    {
        public static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            placa = placa.Trim().ToUpper();
            return placa.Length >= 3 && placa.Length <= 8;
        }

        public static bool ValidarMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
                return false;

            return marca.Trim().Length >= 2;
        }

        public static bool ValidarModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                return false;

            return modelo.Trim().Length >= 1;
        }

        public static bool ValidarAnio(int anio)
        {
            int anioActual = DateTime.Now.Year;
            return anio >= 1900 && anio <= anioActual + 1;
        }

        public static bool ValidarColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return false;

            return color.Trim().Length >= 2;
        }

        public static bool ValidarTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                return false;

            string tipoLower = tipo.Trim().ToLower();
            return tipoLower == "automovil" || tipoLower == "camion" || 
                   tipoLower == "moto" || tipoLower == "bus";
        }

        public static bool ValidarCapacidad(int capacidad)
        {
            return capacidad > 0 && capacidad <= 200;
        }

        public static bool ValidarVehiculo(string placa, string marca, string modelo, 
                                            int anio, string color, string tipo, int capacidad)
        {
            return ValidarPlaca(placa) && 
                   ValidarMarca(marca) && 
                   ValidarModelo(modelo) && 
                   ValidarAnio(anio) && 
                   ValidarColor(color) && 
                   ValidarTipo(tipo) && 
                   ValidarCapacidad(capacidad);
        }
    }
}
