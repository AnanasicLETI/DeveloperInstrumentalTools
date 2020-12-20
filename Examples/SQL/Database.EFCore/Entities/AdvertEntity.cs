using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Advert")]
    public class AdvertEntity
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }
        
        public string Name { get; set; }

        public AdvertType Type { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public decimal Price { get; set; }
    }
}