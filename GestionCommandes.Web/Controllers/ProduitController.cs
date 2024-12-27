using GestionCommandes.Core.Entities;
using GestionCommandes.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionCommandes.Web.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _produitService.GetProduitsAsync();
            return View(produits);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produit = await _produitService.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                await _produitService.AddProduitAsync(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produit = await _produitService.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produit produit)
        {
            if (id != produit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _produitService.UpdateProduitAsync(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produit = await _produitService.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produitService.DeleteProduitAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}