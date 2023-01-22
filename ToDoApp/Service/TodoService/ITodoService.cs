namespace ToDoApp.Service.TodoService
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodos();
        Task<Todo> GetSingleTodo(int id);
        Task<List<Todo>> AddTodo(Todo todo);
        Task<Todo> UpdateToDo(int id, Todo request);
        Task<Todo> DeleteToDo(int id);


    }
}
