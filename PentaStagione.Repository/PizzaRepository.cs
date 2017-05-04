using PentaStagione.Domain;
using PentaStagione.Domain.Repository;

namespace PentaStagione.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext context = new PizzaContext();
        public void Save(Pizza pizzaAggregate)
        {
            context.Pizzas.Add(pizzaAggregate);
            context.SaveChanges();
        }
    }
}