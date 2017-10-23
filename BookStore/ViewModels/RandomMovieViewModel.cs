using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}