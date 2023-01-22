using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;

namespace ToDoApp.Service.TodoService
{
    public class TodoService : ITodoService
    {
        
        private readonly DataContext _dataContext;

        public TodoService(DataContext dataContext) {
            _dataContext = dataContext;
        }    

        public async Task<List<Todo>> AddTodo(Todo todo)
        {
            _dataContext.Todos.Add(todo);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Todos.ToListAsync();
        }

        public async Task<Todo> DeleteToDo(int id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return null;
            }

            _dataContext.Todos.Remove(todo);
            await _dataContext.SaveChangesAsync();

            return todo;
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            var todos = await _dataContext.Todos.ToListAsync();
            return todos;
        }

        public async Task<Todo> GetSingleTodo(int id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return null;
            }
            return todo;
        }

        public async Task<Todo> UpdateToDo(int id, Todo request)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return null;
            }
                  
            todo.Description = request.Description;
            todo.Category = request.Category;
            todo.isComplete = request.isComplete;

            await _dataContext.SaveChangesAsync();

            return todo;
        }
    }
}
