namespace RicardoPrueba2.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string? NombreDepartamento { get; set; }
        public string? AreaDepartamento { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }
}
