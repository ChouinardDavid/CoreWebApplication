using CoreWebApplication.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApplication.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int restaurantId);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant); 
        Restaurant Delete(int id);
        int GetCountOfRestaurants();

        int Commit();
    }
}
