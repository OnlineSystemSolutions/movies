namespace MovieAPI.Model
{
    public class MetaData
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }
        public int Id { get; internal set; }
        public string Language { get; internal set; }
    }
}
