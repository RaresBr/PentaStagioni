namespace PentaStagione.Repository.Contracts.ReadModel
{
    public interface IPizzaReadRepository
    {
        PizzaDto GetById(int pizzaId);
    }
}