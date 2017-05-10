using PentaStagione.Repository.Contracts;
using System.Collections.Generic;

namespace PentaStagione.Services.Contracts
{
    public interface IPizzaService
    {
        void Save(PizzaDto pizza);
        PizzaDto GetById(string id);
        List<PizzaDto> GetAll();
    }
}