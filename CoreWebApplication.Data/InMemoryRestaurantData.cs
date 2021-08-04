using AutoFixture;
using CoreWebApplication.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApplication.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        private readonly IFixture _fixture = new Fixture();

        public InMemoryRestaurantData()
        {
            //restaurants = _fixture.Build<Restaurant>().CreateMany(3);
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "David", Location = "Québec", Cuisine = CuisineType.Italian },
                new Restaurant{ Id = 2, Name = "Mireille", Location = "Chicoutimi", Cuisine = CuisineType.Français },
                new Restaurant{ Id = 3, Name = "Camille", Location = "Mont-Châtel", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        { 
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return null;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
