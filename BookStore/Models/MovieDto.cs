using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public byte GenreId { get; set; }
        [Required]
        [Range(1, 20)]
        public short NumberInStock { get; set; }
        public DateTime? ReleaseDate { get; set; }
       
    }
}