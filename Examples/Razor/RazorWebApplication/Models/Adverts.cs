using System;

namespace RazorWebApplication.Models
{
    public class Adverts
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }
        
        public string Name { get; set; }

        public String Type { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public decimal Price { get; set; }        
        
        public string PriceRubText => FormatPrice(this.Price, "Rub");

        public string PriceDolText => FormatPrice(this.Price/80, "$");

        private static string FormatPrice(decimal price, string postfix)
        {
            return $"{price:0.##} {postfix}";
        }
    }
}