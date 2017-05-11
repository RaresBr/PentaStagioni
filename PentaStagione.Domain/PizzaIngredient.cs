using PentaStagione.Infrastructure.Domain;
using System;

namespace PentaStagione.Domain {
    public class PizzaIngredient : IEntity {
        //TODO: generate id
        public string Id { get; private set; }
        public string Name { get; set; }

        public PizzaIngredient() {
            var g = Guid.NewGuid();
            Id = g.ToString();
        }
        public PizzaIngredient(string name) {
            var g = Guid.NewGuid();
            Id = g.ToString();
            this.Name = name;
        }
    }
}