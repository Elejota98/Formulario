using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturacionElectronica.Models
{
    public class FacturacionElectronicaCreacionViewModel : FacturacionElectronica
    {
        public IEnumerable<SelectListItem> Estacionamientos { get; set; }
        public IEnumerable<SelectListItem> Prefijo { get; set; }

    }
}
