using System;
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

namespace PentaStagione.Repository  {
    class PizzaRepositoryDapper : IPizzaRepository {
        private readonly string _tableName;

        internal IDbConnection Connection {
            get {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
            }
        }
        public void Save(Pizza pizzaAggregate) {
            using (IDbConnection cn = Connection) {
                
                cn.Open();
                cn.Insert(pizzaAggregate);
            }
        }
    }
}
