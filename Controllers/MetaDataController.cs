using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model;
using MovieAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    public class MetaDataController: Controller
    {
        private readonly MetaDataRepository repository;

        public MetaDataController()
        {
            this.repository = new MetaDataRepository();
        }

        [HttpGet("{movieId}")]
        public IEnumerable<MetaData> Get([FromRoute] int movieId)
        {
            return this.repository.Get(movieId);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MetaData entity)
        {
            this.repository.Insert(entity);
            return Ok();
        }
    }
}
