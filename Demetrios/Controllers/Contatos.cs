using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demetrios.Models;
using Demetrios.Services.Interfaces;
using Demetrios.Validation;

namespace Demetrios.Controllers
{
    [Route("Contatos")]
    public class ContatosController : Controller
    {
        private readonly IContatoPostService _contatoPostService;

        public ContatosController(IContatoPostService contatoPostService)
        {
            this._contatoPostService = contatoPostService;
        }

        [HttpPost("ContatoCreate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]ContatoPost contatoPost)
        {
            if (contatoPost.IsValid(out IEnumerable<string> errors))
            {
                var result = await _contatoPostService.Create(contatoPost);

                return CreatedAtAction(
                    nameof(GetAllByUserAccountId), 
                    new { id = result.Nome }, result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost("ContatoCreateLote")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void CreateLote()
        {
            for (int a = 0; a < 50; a++)
            {
                ContatoPost contatoPost = new ContatoPost { Id = a.ToString(),
                                                            Nome = "Nome" + a.ToString(),
                                                            Canal = "Canal" + a.ToString(),
                                                            Valor = "valor" + a.ToString(),
                                                            Obs = "Obs" + a.ToString()
                };

                _contatoPostService.Create(contatoPost);
            }
        }

        [HttpPut("ContatoUpdate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody]ContatoPost contatoPost)
        {
            if (contatoPost.IsValid(out IEnumerable<string> errors))
            {
                var result = await _contatoPostService.Update(contatoPost);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll(int? pageNumber, int? pageSize)
        {
            var result = _contatoPostService.GetAll(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllByUserAccountId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var result = _contatoPostService.GetAllByUserAccountId(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var result = await _contatoPostService.Delete(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

