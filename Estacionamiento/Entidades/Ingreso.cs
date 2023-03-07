namespace Estacionamiento.Entidades
{
    public class Ingreso
    {
        public int id { get; set; }
        public int idVehiculo { get; set; }
        public int idLugar { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }


    }
}
