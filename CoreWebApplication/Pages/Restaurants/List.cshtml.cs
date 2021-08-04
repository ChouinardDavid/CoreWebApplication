using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApplication.Core;
using CoreWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CoreWebApplication.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private IConfiguration Config { get; set; }
        public IEnumerable<Restaurant> restaurants { get; set; }
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData)
        {
            this.Config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            this.Message = this.Config["Message"];
            restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}