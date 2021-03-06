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
    public class AdultController : ControllerBase
    {
        private IAdultService adultService;

        public AdultController(IAdultService adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try{
                IList<Adult> adults = await adultService.GetAdultsAsync();
                return Ok(adults);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAdults([FromBody]Adult adult)
        {
            try{
                await adultService.AddAdultsAsync(adult);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAdults([FromRoute]int  id)
        {
            try{
                await adultService.DeleteAdultsAsync(id);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAdults([FromBody]Adult adult, [FromRoute] int id)
        {
            try{
                await adultService.UpdateAdultsAsync(adult);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
