using GestionCommandes.Core.Entities;
using GestionCommandes.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionCommandes.Web.Controllers
{
    public class ComptableController : Controller
    {
        private readonly ICommandeService _commandeService;

        public ComptableController(ICommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        public async Task<IActionResult> Index()
        {
            var commandes = await _commandeService.GetCommandesAsync();
            return View(commandes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            return View(commande);
        }
    }
}