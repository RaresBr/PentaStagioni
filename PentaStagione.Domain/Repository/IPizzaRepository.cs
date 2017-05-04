namespace PentaStagione.Domain.Repository
{
    public interface IPizzaRepository
    {
        void Save(Pizza pizzaAggregate);
    }
}