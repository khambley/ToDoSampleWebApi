using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoSampleWebApi.Models;

namespace ToDoSampleWebApi.Data
{
    public class ToDoDataContext : DbContext
    {
        public ToDoDataContext (DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoSampleWebApi.Models.TodoItem> TodoItems { get; set; }
    }
}
