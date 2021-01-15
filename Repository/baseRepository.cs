using ExcelDataReader;
using MovieAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public class baseRepository
    {
        public List<MetaData> localiseMetaData()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var response = new List<MetaData>();
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "MovieAPI.Data.metadata.csv"; 
            string[] names = assembly.GetManifestResourceNames();

            Stream outputPdfStream = new System.IO.MemoryStream();

            using (Stream embedded = assembly.GetManifestResourceStream(fileName))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(embedded))
                {
                    do
                    {
                        var ignore = true;
                        int result = 0;
                        while (reader.Read())
                        {
                            if (!ignore)
                            {
                                var entity = new MetaData()
                                {
                                    Id = ConvertInt(reader.GetString(0)),
                                    MovieId = ConvertInt(reader.GetString(1)),
                                    Title = reader.GetString(2),
                                    Language = reader.GetString(3),
                                    Duration = reader.GetString(4),
                                    Year = ConvertInt(reader.GetString(5))
                                };

                                response.Add(entity);
                            }
                            ignore = false;
                        }
                    } while (reader.NextResult());
                }
            }

            // constraint metadata with all data
            var validReponse = response.Where(x => x.MovieId > 0 && 
                                                    String.IsNullOrEmpty(x.Title) && 
                                                    String.IsNullOrEmpty(x.Language) && 
                                                    String.IsNullOrEmpty(x.Duration) && x.MovieId > 0);

            // group data by highest id by language
            var maxes = validReponse.GroupBy(x => x.Language,     
                         x => x.Id,   
                         (key, values) => values.Max()).ToList();

            return validReponse.Where(x => maxes.Contains(x.Id)).ToList();


        }

        public List<MovieStatistic> localiseMoveData()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var response = new List<MovieStatistic>();
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "MovieAPI.Data.stats.csv";

            Stream outputPdfStream = new System.IO.MemoryStream();

            using (Stream embedded = assembly.GetManifestResourceStream(fileName))
            {
                using (var reader = ExcelReaderFactory.CreateReader(embedded))
                {
                    do
                    {
                        var ignore = true;
                        int result = 0;
                        while (reader.Read())
                        {
                            if (!ignore)
                            {
                                var entity = new MovieStatistic()
                                {
                                    MovieId = ConvertInt(reader.GetString(0)),
                                    AverageWatchDuratiuonS = ConvertInt(reader.GetString(1)),
                                };
                                response.Add(entity);
                            }
                            ignore = false;
                            
                        }
                    } while (reader.NextResult());
                }
            }

            response.OrderBy(x => x.Watches).OrderByDescending(x => x.ReleaseYear);
            return response;
        }

        private int ConvertInt(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return Convert.ToInt32(value); 
            }

            throw new Exception("numeric data is null");
        }
    }
}
