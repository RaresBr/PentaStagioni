using System.Collections.Generic;

namespace PentaStagione.Repository.Contracts.ReadModel
{
    public interface IPizzaReadRepository
    {
        PizzaDto GetById(string pizzaId);
        List<PizzaDto> GetPizzas();
    }
}