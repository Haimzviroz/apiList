using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvcList.Models;

namespace apiList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly List<recipesList> _recipeService;

        public RecipeController()
        {
            _recipeService = new List<recipesList>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<recipesList>> GetAll()
        {
            return Ok(_recipeService);
        }

        [HttpGet("{id}")]
        public ActionResult<recipesList> GetById(int id)
        {
            var recipe = _recipeService[id];
            if (recipe == null)
                return NotFound();
            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult<recipesList> Create(recipesList recipe)
        {
            recipe.id = _recipeService.Count > 0 ? _recipeService.Max(r => r.id) + 1 : 1;
            _recipeService.Add(recipe);
            return CreatedAtAction(nameof(GetById), new { id = recipe.id }, recipe);
         
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, recipesList recipe)
        {
            if (id != recipe.id)
                return BadRequest();

            var existingRecipe = _recipeService.FirstOrDefault(r => r.id == id);
            if (existingRecipe == null)
                return NotFound();

            existingRecipe.name = recipe.name;
            existingRecipe.operations = recipe.operations;
            existingRecipe.components = recipe.components;

            return NoContent();
        
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var recipe = _recipeService.FirstOrDefault(r => r.id == id);
            if (recipe == null)
                return NotFound();

            _recipeService.Remove(recipe);
            return NoContent();
        }
    }
}