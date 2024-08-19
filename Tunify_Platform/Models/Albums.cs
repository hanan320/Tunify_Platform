using System.ComponentModel.DataAnnotations;

namespace Tunify_Platform.Models
{
    
    public class Album
    {
        [Key]
        public int Albums_Id { get; set; }

        public int Artist_Id { get; set; }
        public Artist Artist { get; set; }

        public string Album_Name { get; set; }
        public string Release_Date { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
