using DAL.Entities;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FluentApiModelMappingToDatabase.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public ProductController(AppDbContext context)
        {
            _Context = context;
        }
        
        [HttpGet("Get")]
        public IEnumerable<Product> Get()
        {
            return _Context.products.ToList();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _Context.products.Find(id);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                _Context.products.Add(model);
                _Context.SaveChanges();
                return CreatedAtAction("Post", model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute] int id, [FromBody] Product model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();
                _Context.products.Update(model);
                _Context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                Product model = _Context.products.Find(id);
                if (model != null)
                {
                    _Context.products.Remove(model);
                    _Context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
