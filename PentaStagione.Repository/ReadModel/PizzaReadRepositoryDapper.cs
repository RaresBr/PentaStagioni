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
    public class PizzaReadRepositoryDapper : IPizzaReadRepository {
        private readonly string _tableName;

        internal IDbConnection Connection {
            get {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
            }
        }

        public PizzaDto GetById(int pizzaId) {
            Pizza pizza = new Pizza();

            using (IDbConnection cn = Connection) {
                cn.Open();
                pizza = cn.Query<Pizza>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = pizzaId }).SingleOrDefault();
            }

            PizzaDto pizzaDto = new PizzaDto();
            pizzaDto.Name = pizza.Name;
            return pizzaDto;
        }

        public PizzaReadRepositoryDapper(string tableName) {
            _tableName = tableName;
        }


    }
}
