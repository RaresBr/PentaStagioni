using PentaStagione.Domain;
using PentaStagione.Repository.Contracts;
using PentaStagione.Repository.Contracts.ReadModel;
using System.Linq;

namespace PentaStagione.Repository.ReadModel
{
    public class PizzaReadRepository : IPizzaReadRepository
    {
        private readonly PizzaContext context = new PizzaContext();
       
        public PizzaDto GetById(int pizzaId)
        {
            var query = context.Pizzas.FirstOrDefault(pizza => pizza.PizzaId == pizzaId);
            PizzaDto pizzaDto = new PizzaDto();
            pizzaDto.Name = query.Name;
            return pizzaDto;
        }
    }
}