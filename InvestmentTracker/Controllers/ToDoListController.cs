using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        public IEnumerable<TodoItem> Get()
        {
            //

            return new List<TodoItem>();
        }

        public void Post(TodoItem todo)
        {

        }

    }

    public class TodoItem
    {
        public string Title { get; set; }
        public string Owner { get; set; }
    }
}