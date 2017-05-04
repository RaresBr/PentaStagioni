using PentaStagione.Domain;
using PentaStagione.Domain.Repository;
using PentaStagione.Services.Contracts;
using PentaStagione.Repository.Contracts;
using PentaStagione.Repository.Contracts.ReadModel;

namespace PetnaStagione.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _repository;
        private IPizzaReadRepository _readRepository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public void Save(object pizzaDto)
        {
            Pizza pizzaAggregate = null; // = map from pizza dto
            _repository.Save(pizzaAggregate);
        }

        public object GetById(int pizzaId)
        {
            return _readRepository.GetById(pizzaId);
        }
    }
}