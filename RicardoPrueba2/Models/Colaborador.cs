using System.ComponentModel.DataAnnotations;

namespace RicardoPrueba2.Models
{
    public class Colaborador
    {
        public string? Rut { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Comuna { get; set; }
        public int Telefono { get; set; }
        public string? Correo { get; set; }
        public string? FechaContratacion { get; set; }
        public string? ContratoIndefinido { get; set; }

        //FK
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
