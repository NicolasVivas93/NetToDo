using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetToDo.Services;
using NetToDo.Models;

namespace NetToDo.Controllers
{
    public class TodoController : Controller
    {

        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteItemsAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        // Obtener las tareas desde la base de datos

        // Colocar los tareas en un modelo

        // Genera la vista usando el modelo
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            
            if (!successful)
            {
                return BadRequest(new {error = "Could not add item."});
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
    
            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
    
            return RedirectToAction("Index");
        }       
    }
}