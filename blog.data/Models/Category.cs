using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.data.Models
{
    public class Category
    {
        [Key]
        public  int Id { get; set; }
        [Required(ErrorMessage ="isim alanı gereklidir")]
        
        public string Name { get; set; }   
        public virtual ICollection<Post> Posts { get;}
    }
}
