using PentaStagione.Domain;
using PentaStagione.Domain.Repository;
using PentaStagione.Services.Contracts;
using PentaStagione.Repository.Contracts;
using PentaStagione.Repository.Contracts.ReadModel;
using System;
using System.Collections.Generic;

namespace PetnaStagione.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _repository;
        private IPizzaReadRepository _readRepository;

        public PizzaService(IPizzaRepository repository, IPizzaReadRepository readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public void Save(PizzaDto pizzaDto)
        {
           
            Pizza pizzaAggregate = new Pizza(); 
            pizzaAggregate.Name = pizzaDto.Name;
            
            _repository.Save(pizzaAggregate);
        }
        public void SaveIngredient(PizzaIngredient pizzaIngredient) {
            _repository.SaveIngredient(pizzaIngredient);
        }

        public PizzaDto GetById(string pizzaId)
        {
            return _readRepository.GetById(pizzaId);
        }
        public List<PizzaDto> GetAll() {
            return _readRepository.GetPizzas();
        }

    }
}