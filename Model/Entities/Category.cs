using Model.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("categories")]
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ICollection<Post> Posts { get; set; }
    }
}
