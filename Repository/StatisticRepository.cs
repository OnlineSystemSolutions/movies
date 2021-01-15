using MovieAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public class StatisticRepository: baseRepository
    {
        public IEnumerable<MovieStatistic> Get()
        {
            return localiseMoveData();
        }
    }
}
