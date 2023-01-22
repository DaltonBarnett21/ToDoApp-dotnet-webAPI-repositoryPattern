using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Service.TodoService;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
       

        private ITodoService _todoService;
        public ToDoController(ITodoService todoService)
        {

            _todoService = todoService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodos()
        {
           var todos = await _todoService.GetAllTodos();
            return Ok(todos);
          

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetSingleTodo(int id)
        {
            var todo = await _todoService.GetSingleTodo(id);
            if (todo is null) return NotFound("Todo Not Found");

            return Ok(todo);

        }

        [HttpPost]
        public async Task<ActionResult<List<Todo>>> AddTodo(Todo todo)
        {
            var result = await _todoService.AddTodo(todo);

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> UpdateToDo(int id, Todo request)
        {
           var todo = await _todoService.UpdateToDo(id, request);
            if (todo is null) return NotFound("Todo Not Found");

            return Ok(todo);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Todo>> DeleteToDo(int id)
        {
            var result = await _todoService.DeleteToDo(id);
            if(result is null) return NotFound("Todo Not Found");

            return Ok(result);
        }
    }
}
