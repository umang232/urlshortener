namespace URLSHORTENERAPI.Models
{
    public class Url{
        public int Id {get; set;}
        public string LongURL {get; set;}
        public string ShortURL {get; set;}
        public DateTime CreatedAt {get; set;}

    }
}