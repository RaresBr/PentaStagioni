﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using PentaStagione.Domain;
using PentaStagione.Domain.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper.Contrib.Extensions;

namespace PentaStagione.Repository {
    public class PizzaRepository : IPizzaRepository {
        private readonly IDbConnection connection;
        public void Save(Pizza pizzaAggregate) {
            connection.Execute(@"INSERT PIZZAS([NAME],[ID]) values (@NAME, @ID)",
                new { NAME = pizzaAggregate.Name, ID = pizzaAggregate.Id });

            foreach (var item in pizzaAggregate.Ingredients) {
                connection.Execute(@"INSERT PIZZA_HAS_INGREDIENTS([ID],[PIZZA_ID]) values (@ID, @PIZZAID)",
                new { ID = item.Id, PIZZAID = pizzaAggregate.Id });
            }
            
        }
        public PizzaRepository() {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }
        public void SaveIngredient(PizzaIngredient pizzaIngredient) {
            connection.Execute(@"INSERT INGREDIENTS([NAME],[ID]) values (@NAME, @ID)",
                new { NAME = pizzaIngredient.Name, ID = pizzaIngredient.Id });
        }
    }
}
