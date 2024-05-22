using System;
namespace URLSHORTENERAPI.Helper{
    public static class UrlShortener
    {
        private static readonly string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random random = new Random();

        public static string GenerateShortUrl()
        {
            char[] shortUrl = new char[8];
            for (int i = 0; i < shortUrl.Length; i++)
            {
                shortUrl[i] = characters[random.Next(characters.Length)];
            }
            return new string(shortUrl);
        }
    }
}
