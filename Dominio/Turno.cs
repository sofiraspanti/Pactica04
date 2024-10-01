namespace Practica04.Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now.AddDays(1); // Define valor por defecto el día siguiente
        public TimeSpan Hora {  get; set; }
        public string Cliente { get; set; }
        public List<Detalle_turno> Detalle { get; set; }
    }
}
