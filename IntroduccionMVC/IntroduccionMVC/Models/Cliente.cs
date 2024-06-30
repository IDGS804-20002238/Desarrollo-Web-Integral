namespace IntroduccionMVC.Models
{
    public class Cliente
    {
        //Propiedades del modelo
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Correo { get; set; }
    }
}
