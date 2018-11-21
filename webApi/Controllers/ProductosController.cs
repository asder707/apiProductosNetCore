using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Modelos;

using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {

        private readonly DbProducto dbProducto;

        public ProductosController(DbProducto dbProducto)
        {
            this.dbProducto = dbProducto;
        }
        
        //[HttpGet]
        //[Route("api/v1/[controller]/getTest")]
        //public IActionResult GetTest()
        //{
        //    return Ok("Hola desde [controller]");
        //}

        [HttpGet]
        public IActionResult get()
        {
            return Ok(this.dbProducto.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            var result = this.dbProducto.Create(producto);

            if (result == null)
            {
                return BadRequest($"No fue posible crear al producto {producto.codProducto}.");
            }
            return Ok(result);
        }

        [HttpDelete("{codProducto}")]
        public IActionResult Delete(int codProducto)
        {
            var result = this.dbProducto.Delete(codProducto);
            if (result == null)
            {
                return BadRequest($"No fue posible eliminar al producto {codProducto}.");
            }

            return Ok(result);
        }

        [HttpGet("{codProducto}")]
        public IActionResult Get(int codProducto)
        {
            var producto = this.dbProducto.GetByCodProducto(codProducto);

            if (producto == null)
            {
                return BadRequest($"El producto {codProducto} no se encuentra registrado.");
            }

            return Ok(producto);
        }


    }
}
