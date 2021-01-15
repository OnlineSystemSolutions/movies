using MovieAPI.Data;
using MovieAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public class MetaDataRepository : baseRepository
    {
        public IEnumerable<MetaData> Get(int movieId)
        {
            var result = localiseMetaData();

            return result.Where(x => x.MovieId == movieId);
        }

        public void Insert(MetaData entity)
        {
            TempDB.MetaDatas.Add(entity);
        }
    }
}
