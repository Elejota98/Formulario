namespace FacturacionElectronica.Models
{
    public class FacturacionElectronica
    {
        public int IdRegistro { get; set; }
        public string TipoPersona { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombresApellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public int NumeroFactura { get; set; }
        public int Total { get; set; }
        public string Prefijo { get; set; }
        public long IdEstacionamiento { get; set; }
        public byte[] Imagen { get; set; }

        public bool Sincronizacion = false;
    }
}
