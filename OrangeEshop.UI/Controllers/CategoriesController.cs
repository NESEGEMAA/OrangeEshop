using Microsoft.AspNetCore.Mvc;
using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL.Entities;
using OrangeEshop.UI.Models;

namespace OrangeEshop.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                await _categoryServices.CreateCategoryAsync(category);
                return RedirectToAction("Read");
            }

            return View(viewModel);
        }

        // GET: Categories/Read
        public async Task<IActionResult> Read()
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();
            var viewModels = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();

            return View(viewModels);
        }

        // GET: Categories/Update/5
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(viewModel);
        }

        // POST: Categories/Update
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                await _categoryServices.UpdateCategoryAsync(category);
                return RedirectToAction("Read");
            }

            return View(viewModel);
        }


        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(viewModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryServices.RemoveCategoryAsync(id);
            return RedirectToAction("Read");
        }

    }
}
