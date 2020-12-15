using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudComputing.Context;
using CloudComputing.Model;
using CloudComputing.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CloudComputing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public CounterController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: api/Counter/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Counter>> GetCounter(int id)
        {
            try
            {
                var counter = await _repoWrapper.Counter.GetCounter(id);

                if (counter == null)
                {
                    Console.WriteLine($"Study with id: {id} has not been found in the database.");
                    return NotFound();
                }

                return counter;

            } catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // POST: api/Counter/increment
        [HttpPost]
        [Route("increment")]
        public async Task<ActionResult<string>> IncrementCounter()
        {
            try
            {
                // for now I'm incrementing always the first counter in db
                 var counter = await _repoWrapper.Counter.GetCounter(1);

                if (counter == null)
                {
                    // if it hasn't been created, then create one
                    counter = new Counter();
                    // initial increment
                    counter.Number = 1;
                    _repoWrapper.Counter.Create(counter);
                    _repoWrapper.Save();

                } else
                {
                    counter.Number++;
                    _repoWrapper.Save();
                }

                return Ok(counter);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong inside IncrementCounter action: {e.Message}");
                return StatusCode(404, e.Message);
            }
			//return Ok("Ok!");

        }
        
    }
}
