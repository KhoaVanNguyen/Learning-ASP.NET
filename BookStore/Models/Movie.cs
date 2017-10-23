using System.ComponentModel.DataAnnotations;
using System;
namespace BookStore.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
        public short NumberInStock { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

    }
}