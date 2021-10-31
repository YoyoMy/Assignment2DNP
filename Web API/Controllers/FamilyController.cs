using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileData;
using Model;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyService familyService;

        public FamilyController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try{
                IList<Family> family = await familyService.GetFamilies();
                return Ok(family);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFamily([FromBody]Family family)
        {
            try{
                await familyService.AddFamily(family);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFamily([FromRoute]int  id)
        {
            try{
                await familyService.RemoveFamily(id);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAdults([FromBody]Family family, [FromRoute] int id)
        {
            try{
                await familyService.EditFamily(family);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
