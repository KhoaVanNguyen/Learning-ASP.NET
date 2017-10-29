using System.ComponentModel.DataAnnotations;
using System;
namespace BookStore.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        [Required]
        [Range(1,20)]
        public short NumberInStock { get; set; }

     
        public DateTime? ReleaseDate { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

    }
}