using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class AdvertType
    {
        public int Id { get; set; }
        
        public string Type { get; set; }
    }
}