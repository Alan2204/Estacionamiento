namespace Estacionamiento.Entidades
{
    public class Ingreso
    {
        public int id { get; set; }
        public int idEstacionamientos { get; set; }
        public int idVehiculo { get; set; }
        public int idLugar { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public float Monto { get; set; }
        public Estacionamientos Estacionamientos { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Lugar Lugar { get; set; }


    }
}
