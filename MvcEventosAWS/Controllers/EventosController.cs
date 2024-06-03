using Microsoft.AspNetCore.Mvc;
using MvcEventosAWS.Models;
using MvcEventosAWS.Services;

namespace MvcEventosAWS.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiEventos service;

        public EventosController(ServiceApiEventos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Evento> eventos =
                await this.service.GetEventos();
            return View(eventos);
        }

        public async Task<IActionResult> EventosPorCategoria(int idcategoria)
        {
            List<Evento> eventos = await this.service.GetEventosPorCategorias(idcategoria);
            return View(eventos);
        }

        public async Task<IActionResult> Categorias()
        {
            List<CategoriaEvento> categorias =
                await this.service.GetCategoriasEventos();
            return View(categorias);
        }
    }
}
