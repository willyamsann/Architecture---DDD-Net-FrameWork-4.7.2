using Arquitetura.Application.Modules.ProductManagement.Interfaces;
using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using Arquitetura.Infra.Crosscuting.MvcFilters;
using Microsoft.Ajax.Utilities;
using System;
using System.Web.Mvc;

namespace Arquitetura.UI.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Index()
        {
            var products = _productAppService.GetAllActive();

            return View(products);
        }

        public ActionResult Details(Guid id)
        {
            var product = _productAppService.GetById(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [ClaimsAuthorize("Product", "Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ClaimsAuthorize("Product", "Create")]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                product = _productAppService.Add(product);

                if (!product.ValidationResult.IsValid)
                {
                    foreach (var error in product.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(product);
                }

                if (!product.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = product.ValidationResult.Message;
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }

        [ClaimsAuthorize("Product", "Edit")]
        public ActionResult Edit(Guid id)
        {
            var product = _productAppService.GetById(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        [ClaimsAuthorize("Product", "Edit")]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                product = _productAppService.Update(product);

                if (!product.ValidationResult.IsValid)
                {
                    foreach (var error in product.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(product);
                }

                if (!product.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = product.ValidationResult.Message;
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }

        [ClaimsAuthorize("Product", "Delete")]
        public ActionResult Delete(Guid id)
        {
            var product = _productAppService.GetById(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ClaimsAuthorize("Product", "Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _productAppService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
