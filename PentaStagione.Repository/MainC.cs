using Dapper;
using Oracle.DataAccess.Client;
using PentaStagione.Domain;
using PentaStagione.Repository.Contracts;
using PentaStagione.Repository.Contracts.ReadModel;
using PentaStagione.Repository.ReadModel;
using PetnaStagione.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaStagione.Repository {
    public class MainC {
        static int Main(string[] args) {
            var readRepo = new PizzaReadRepository();
            PizzaDto pizzaDto = readRepo.GetById("id12");
            //Console.WriteLine(pizzaDto.Name);

            List<PizzaDto> allPizzas = readRepo.GetPizzas();
            foreach (var item in allPizzas) {
                Console.WriteLine(item.Name);

            }
            var writeRepo = new PizzaRepository();
            
            
            //writeRepo.Save(pizza);
            PizzaService service = new PizzaService(writeRepo, readRepo);
            service.Save(pizzaDto);
            Console.WriteLine(service.GetById("id12").Name);


            var pingredient = new PizzaIngredient("meat");
            service.SaveIngredient(pingredient);

            Pizza pizza = new Pizza();
            pizza.Name = "fullPizza";
            pizza.AddIngredient(pingredient);

            writeRepo.Save(pizza);
            return 0;
        }
    }
}
