using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using blog.data.Data;
using blog.data.Models;
using blog.business.Repositories;
using blog.ui.Models;

namespace blog.ui.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public IActionResult Index()
        {

            var categoryEntities = _categoryRepository.GetAll();
     
            var categoryViewModelList = categoryEntities.Select(x => new CategoriesViewModel()
            {
                Name=x.Name,
                Id=x.Id

            });

            return View(categoryViewModelList);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryEntites = _categoryRepository.GetByID(id.Value);
            if (categoryEntites == null)
            {
                return NotFound();
            }
            var model = new CategoriesUpdateViewModel
            {
                Id = categoryEntites.Id,
                Name = categoryEntites.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoriesUpdateViewModel model)
        {
            var entity = new Category
            {
                Name = model.Name,
                Id = model.Id
            };
            _categoryRepository.Update(entity);
         
            return RedirectToAction(nameof(Index), "Categories"); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoriesViewModel model)
        {
            if(!ModelState.IsValid)
            {

                return View(model);

            }
            Category entity = new Category()
            {

                Name = model.Name
            };
            _categoryRepository.Add(entity);
            return RedirectToAction(nameof(Index), "Categories");

        }

        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction(nameof(Index), "Categories");
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryEntity = _categoryRepository.GetByID(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }
            var categoryViewModel = new CategoriesInsertViewModel()
            {
                Name = categoryEntity.Name
            };
            return View(categoryViewModel); 

        
        }
    }
}
