using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreinamentoApi.Data;
using TreinamentoApi.Models;

namespace TreinamentoApi.Controller
{
    [Controller]
    [Route("api/controller")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext dc;

        public PersonController(DataContext dc)
        {
            this.dc = dc;
        }

        [HttpGet("oi")]
        public string oi()
        {
            return "Thiago jose da silva";
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Person p)
        {
            dc.person.Add(p);
            await dc.SaveChangesAsync();
            //return Ok("Cadastro realizado!");
            return Created("url para pesquisa", p);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var data = await dc.person.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            Person p = dc.person.Find(id);
            return p;
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Person p)
        {
            dc.person.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = GetById(id);

            if (p == null) {
                return BadRequest();
            }
            else
            {
                dc.person.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }

}
