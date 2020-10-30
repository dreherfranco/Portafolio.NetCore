using Model.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("posts")]
    public class Post : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int User_Id { get; set; }
        [NotMapped]
        public User User { get; set; }
        public int Category_Id { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        
    }
}
