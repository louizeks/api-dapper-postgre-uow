using ExemploDapperPostgreUow.Entidades;
using ExemploDapperPostgreUow.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ExemploDapperPostgreUow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervejaController : ControllerBase
    {
        readonly ICervejaServico _cervejaServico;

        public CervejaController(ICervejaServico cervejaServico)
        {
            _cervejaServico = cervejaServico;
        }     
      
        [HttpGet]
        [ProducesResponseType(typeof(Cerveja), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Cerveja>> Get()
        {
            var cervejas = _cervejaServico.ListarTodas();
            if (cervejas == null)
                return NotFound();

            return Ok(cervejas.ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cerveja), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cerveja> Get(int id)
        {
            var cerveja = _cervejaServico.ListarPorId(id);
            if (cerveja == null)
                return NotFound();

            return Ok(cerveja);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cerveja), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cerveja> Post([FromBody] Cerveja cerveja)
        {
            if (cerveja == null)
                return BadRequest();

            cerveja = _cervejaServico.Incluir(cerveja);

            return CreatedAtAction(nameof(Get), new { id = cerveja.Id }, cerveja);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cerveja), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] Cerveja cerveja)
        {
            if (cerveja == null)
                return BadRequest();

            _cervejaServico.Alterar(cerveja);

            return Ok(cerveja);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cerveja), StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _cervejaServico.Excluir(id);
            return Ok();
        }
    }
}
