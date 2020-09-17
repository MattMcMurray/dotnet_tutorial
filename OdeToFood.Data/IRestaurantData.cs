using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Winnipeg", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Clay Oven", Location = "Winnipeg", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "La Carnita", Location = "Winnipeg", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 4, Name = "T.R. McCoy's", Location = "Wasagaming", Cuisine = CuisineType.None }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
