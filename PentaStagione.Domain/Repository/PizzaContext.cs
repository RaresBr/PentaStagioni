using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PentaStagione.Domain {
    public class PizzaContext : DbContext {
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
