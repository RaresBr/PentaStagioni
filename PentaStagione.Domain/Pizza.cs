using System.Collections.Generic;
using System.Linq;
using PentaStagione.Infrastructure.Domain;
using System;

namespace PentaStagione.Domain {
    public class Pizza : IAggregateRoot {
        private readonly List<PizzaIngredient> _ingredients;
        public Pizza() {
            var g = Guid.NewGuid();
            Id = g.ToString();
            _ingredients = new List<PizzaIngredient>();
        }
        public Pizza(string name) {
            var g = Guid.NewGuid();
            Id = g.ToString();
            this.Name = name;
        }
        
        public string Id { get;  private set; }
        
        public string Name { get; set; }
        
        public IEnumerable<PizzaIngredient> Ingredients {
            get { return new List<PizzaIngredient>(_ingredients); }
        }

        public void AddIngredient(PizzaIngredient ingredient) {
            //interception
            _ingredients.Add(ingredient);
        }
        
    }
}
