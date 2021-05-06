using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() { 
                new Restaurant { Id = 1, Name = "Errett's Pizza", Location = "Louisiana", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "La Caretta", Location = "Hammond", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 3, Name = "Taste of India", Location = "India", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}