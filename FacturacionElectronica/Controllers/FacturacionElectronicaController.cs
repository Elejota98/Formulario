using FacturacionElectronica.Models;
using FacturacionElectronica.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturacionElectronica.Controllers
{
    public class FacturacionElectronicaController : Controller
    {
        private readonly IRepositorioFacturacionElectronica repositorioFacturacionElectronica;

        public FacturacionElectronicaController(IRepositorioFacturacionElectronica repositorioFacturacionElectronica)
        {
            this.repositorioFacturacionElectronica = repositorioFacturacionElectronica;
        }

        public async Task<IActionResult> Crear()
        {
            var modelo = new FacturacionElectronicaCreacionViewModel();
            modelo.Estacionamientos = await BuscarEstacionamientos();
            return View(modelo);
        }

        private async Task<IEnumerable<SelectListItem>> BuscarEstacionamientos()
        {
            var estacionamientos = await repositorioFacturacionElectronica.BuscarEstacionamientos();
            return estacionamientos.Select(x => new SelectListItem(x.Nombre, x.IdEstacionamiento.ToString()));
        }

        private async Task<IEnumerable<SelectListItem>>ObtenerPrefijos(FacturacionElectronicaCreacionViewModel modelo)
        {
            var prefijos = await repositorioFacturacionElectronica.ObtenerPrefijoPorIdEstacionamiento(modelo.IdEstacionamiento);
            return prefijos.Select(x => new SelectListItem(x.Prefijo, x.Prefijo.ToString()));
        }
        [HttpPost]
        public async Task<IActionResult>ListarPrefijos([FromBody] FacturacionElectronicaCreacionViewModel modelo)
        {
            var prefijos = await ObtenerPrefijos(modelo);
            return Ok(prefijos);

        }
    }
}
