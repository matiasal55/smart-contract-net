using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IServicioContrato _servicio;

        public ContratoController(IServicioContrato servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Contrato
        [HttpGet("set")]
        public async Task<ActionResult<BigInteger>> SetNumero()
        {
            return await _servicio.SetearNumero();
        }
        
        [HttpGet("get")]
        public async Task<ActionResult<BigInteger>> GetNumero()
        {
            return await _servicio.ObtenerNumero();
        }

        // GET: api/Contrato/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contrato
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
