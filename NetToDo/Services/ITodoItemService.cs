using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetToDo.Models;

namespace NetToDo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
        // Si la sintaxis parece confusa, recuerda "una Tarea(Task) que contiene un arreglo de TodoItems"

        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
