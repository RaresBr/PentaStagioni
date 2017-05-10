using PentaStagione.Repository.Contracts.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PentaStagione.Repository.Contracts;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PentaStagione.Domain;
using Dapper;

namespace PentaStagione.Repository.ReadModel {
    public class PizzaReadRepository : IPizzaReadRepository  {
        private readonly IDbConnection connection;

        public PizzaDto GetById(string pizzaId) {
            Pizza pizza = new Pizza();
            pizza = connection.Query<Pizza>("SELECT * FROM PIZZAS WHERE ltrim(rtrim(ID)) like @ID", new { ID = pizzaId }).SingleOrDefault();
            PizzaDto pizzaDto = new PizzaDto();
            pizzaDto.Name = pizza.Name;
            return pizzaDto;
        }


        public List<PizzaDto> GetPizzas() {
            var allPizzas = connection.Query<Pizza>("SELECT ALL [NAME],[ID] FROM [PIZZAS]" ).ToList();
            List<PizzaDto> allPizzaDtos = new List<PizzaDto>();

            foreach (var item in allPizzas) {
                PizzaDto tempPizzaDto = new PizzaDto();
                tempPizzaDto.Name = item.Name;
                allPizzaDtos.Add(tempPizzaDto);
            }

            return allPizzaDtos;
        }

        public PizzaReadRepository() {
             connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }


    }
}
