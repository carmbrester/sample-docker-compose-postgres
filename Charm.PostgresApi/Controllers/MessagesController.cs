using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Charm.PostgresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        // GET: api/<MessagesController>
        [HttpGet]
        public string Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection("User ID=user;Password=pwd;Host=postgres;Port=5432;Database=my_db;"))
            {
                try
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM public.messages";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        var greeting = reader.GetString(reader.GetOrdinal("greeting"));
                        var target = reader.GetString(reader.GetOrdinal("target"));

                        return $"{greeting}, {target}!";
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
