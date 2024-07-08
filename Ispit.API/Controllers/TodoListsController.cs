using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoData.Models;

namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : Controller
    {
        private readonly TodoApiContext _context;

        public TodoListsController(TodoApiContext context)
        {
            _context = context;
        }

        //// GET: api/TodoList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
        {
            return await _context.TodoLists.ToListAsync();
        }


        //// GET: api/TodoList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {
            var todo = await _context.TodoLists.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }



        //// PUT: api/TodoList/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id, TodoList todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        //// POST: api/TodoList
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList(TodoList todo)
        {
            _context.TodoLists.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostTodoList", new { id = todo.Id }, todo);
        }



        //// DELETE: api/TodoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var todo = await _context.TodoLists.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoLists.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.Id == id);
        }
    }
}
