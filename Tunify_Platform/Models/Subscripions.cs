using System.ComponentModel.DataAnnotations;

namespace Tunify_Platform.Models
{
    public class Subscripion
    {
        [Key]
        public int SubscripionsId { get; set; }

        public string Subscripions_Type { get; set; }

        public decimal Price { get; set; }

        public ICollection<User> Users { get; set; }


    }
}
