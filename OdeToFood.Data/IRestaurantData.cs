using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData: IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Errett's Pizza", Location = "Hammond, Louisiana", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name = "La Caretta", Location = "Amite, Louisiana", Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 1, Name = "Taste of India", Location = "Chicago, Illinois", Cuisine = CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}