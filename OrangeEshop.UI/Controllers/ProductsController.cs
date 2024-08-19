using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL.Entities;
using OrangeEshop.UI.Models;

namespace OrangeEshop.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices productService, ICategoryServices categoryService)
        {
            _productServices = productService;
            _categoryServices = categoryService;
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();
            var categoryViewModels = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            var model = new ProductViewModel
            {
                Categories = categoryViewModels
            };

            return View(model);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Re-fetch categories if model state is not valid
                model.Categories = (await _categoryServices.GetAllCategoriesAsync())
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                return View(model);
            }

            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };

                await _productServices.CreateProductAsync(product);
                return RedirectToAction(nameof(Read));
            }
            catch (Exception ex)
            {
                // Log exception to console
                Console.WriteLine($"An error occurred while creating the product: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while creating the product.");

                // Re-fetch categories if an exception occurs
                model.Categories = (await _categoryServices.GetAllCategoriesAsync())
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                return View(model);
            }
        }

        // GET: Products/Read
        public async Task<IActionResult> Read()
        {
            var products = await _productServices.GetAllProductsAsync();
            var categories = await _categoryServices.GetAllCategoriesAsync();

            // Create a dictionary to map category IDs to CategoryViewModel
            var categoryDictionary = categories.ToDictionary(c => c.Id, c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });

            // Map products to ProductViewModel and use the dictionary to fetch category data
            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = categoryDictionary.TryGetValue(p.CategoryId, out var category)
                    ? category
                    : new CategoryViewModel
                    {
                        Id = 0,
                        Name = "Unknown" // Default value if Category is not found
                    }
            }).ToList();

            return View(productViewModels);
        }


        // GET: Products/Update/5
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryServices.GetAllCategoriesAsync();

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                Category = new CategoryViewModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };

            return View(viewModel);
        }

        // POST: Products/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Fetch categories again in case of validation errors
                var categories = await _categoryServices.GetAllCategoriesAsync();
                model.Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                return View(model);
            }

            try
            {
                // Fetch the product to be updated
                var product = await _productServices.GetProductByIdAsync(model.Id);
                if (product == null)
                {
                    return NotFound();
                }

                // Update the product details
                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;

                // Save changes
                await _productServices.UpdateProductAsync(product);

                // Redirect to the Read view after successful update
                return RedirectToAction("Read");
            }
            catch
            {
                // Handle exceptions if any
                return View(model);
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryServices.GetAllCategoriesAsync();
            var categoryViewModel = categories
                .FirstOrDefault(c => c.Id == product.CategoryId);

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = categoryViewModel != null ? new CategoryViewModel
                {
                    Id = categoryViewModel.Id,
                    Name = categoryViewModel.Name
                } : null
            };

            return View(productViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productServices.RemoveProductAsync(id);
                return RedirectToAction(nameof(Read));
            }
            catch (Exception ex)
            {
                // Log exception to console
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
