using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model;
using MovieAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {
            this.repository = new StatisticRepository();
        }

        public StatisticRepository repository { get; }

        [HttpGet("stats")]
        public IEnumerable<MovieStatistic> Get()
        {
            return repository.Get();
        }

    }
}
