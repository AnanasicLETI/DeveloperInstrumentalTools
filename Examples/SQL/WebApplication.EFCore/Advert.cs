using System;

namespace WebApplication.EFCore
{
    public class Advert
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }
        
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public decimal Price { get; set; }
    }
}