namespace PentaStagione.Domain.Repository
{
    public interface IPizzaRepository
    {
        void Save(Pizza pizzaAggregate);
        void SaveIngredient(PizzaIngredient pizzaIngredient);
    }
}