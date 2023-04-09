using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProjetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }
        //GET, POST, PUT, PATCH, DELETE

        [HttpGet("")]
        // IActionResult retorna 200,400,500

        public IActionResult GET()
        {
           List<PersonModel> person = new List<PersonModel>();
            person.Add(new PersonModel(1, "Pedro"));
            person.Add(new PersonModel(2, "Marcos"));
            person.Add(new PersonModel(3, "Ernesto"));
            person.Add(new PersonModel(4, "Maria"));

            return Ok(person);
        }

        [HttpGet("{id}")]
        public IActionResult GET(int id)
        {
            List<PersonModel> person = new List<PersonModel>();
            person.Add(new PersonModel(1, "Pedro"));
            person.Add(new PersonModel(2, "Marcos"));
            person.Add(new PersonModel(3, "Ernesto"));
            person.Add(new PersonModel(4, "Maria"));

            var resposta = person.FirstOrDefault(i => i.Id == id);
            return Ok(resposta);
        }
        //From Route
        [HttpDelete()]
        //From query utilizado com mais parametros dentro da requisição 
        public IActionResult DELETE([FromQuery] int id)
        {
            if (id == 0)
                return BadRequest("Este id não pode ser usado");
            //Lógica
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonModel model)
        {
            model.Id = 10;
            //return Created("Get/", model.Id);//201
            return StatusCode(StatusCodes.Status201Created, model.Id);
            //O Back End gera um Id próprio (JSON somente nome)
        }


        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id , [FromBody] PersonModel model)
        {
            if (id == 0)
            {
                return BadRequest("Este id não pode ser utilizado");
            }

            return Ok(model);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Update2([FromRoute] int id, [FromBody] PersonModel model)
        {
            if (id == 0)
            {
                return BadRequest("Este id não pode ser utilizado");
            }

            return Ok(model);
        }
    }
}