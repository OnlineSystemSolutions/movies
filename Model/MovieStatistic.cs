using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Model
{
    public class MovieStatistic
    {
        public int MovieId { get; set;  }
        public string Title { get; set; }
        public int AverageWatchDuratiuonS { get; set; }
        public int Watches { get; set; }
        public int ReleaseYear { get; set; }
    }
}
