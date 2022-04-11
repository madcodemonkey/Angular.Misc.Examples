using ACME.Models;
using ACME.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACME.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateLookupController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateLookupController(IStateService stateService)
        {
            _stateService = stateService;
        }

        // GET: api/<StateLookupController>
        [HttpGet]
        public IEnumerable<LookupItem> Get()
        {
            return _stateService.GetAll();
        }

        // GET api/<StateLookupController>/5
        [HttpGet("{id}")]
        public LookupItem Get(int id)
        {
            return _stateService.GetById(id);
        }

        // POST api/<StateLookupController>
        [HttpPost]
        public void Post([FromBody] LookupItem item)
        {
            _stateService.Add(item);
        }

        // PUT api/<StateLookupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LookupItem item)
        {
            _stateService.Update(item);
        }

        // DELETE api/<StateLookupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var state = _stateService.GetById(id);
            if (state != null)
                _stateService.Delete(state);
        }
    }
}
