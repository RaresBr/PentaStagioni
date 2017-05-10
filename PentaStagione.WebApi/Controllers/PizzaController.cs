using System.Web.Http;
using PentaStagione.Services.Contracts;
using PentaStagione.Repository.Contracts;
using System.Collections.Generic;
using PentaStagione.Domain;
using PentaStagione.Domain.Repository;
using PetnaStagione.Services;
using PentaStagione.Repository.ReadModel;
using PentaStagione.Repository;
namespace PentaStagione.WebApi.Controllers
{
    [Route("api/pizza")]
    public class PizzaController : ApiController
    {

        private readonly IPizzaService _pizzaService ;



        public PizzaController( )
        {
            _pizzaService = new PizzaService (new PizzaRepository(),new PizzaReadRepository());
        }
       

        [HttpGet]
        [Route("api/pizza/{id}")]
        public PizzaDto Get(string id)
        {
            return _pizzaService.GetById(id);
        }

        [HttpGet]
        [Route("api/pizza/")]
        public List<PizzaDto> Get() {
            return _pizzaService.GetAll();
        }

        [HttpPost]
        
        public void Post([FromBody]PizzaDto pizza)
        {
            _pizzaService.Save(pizza);
        }
    }
}