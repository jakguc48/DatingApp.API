﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    //GET http://localhost:5000/api/values - pierwsza czesc nazwy kontrolera czyli values leci na koniec taka konwencja
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        //Inject data content here - odwołujemy się do utworzonego przez nas contextu + ctrl + . i initializujemy z _
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        //zastępujemy ActionResult IActionResultem zeby moc uzyskac http responeses
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public IActionResult GetValues()
        {
            //pobieramy z contekstu
            var values = _context.Values.ToList();

            //zwracamy http response
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
