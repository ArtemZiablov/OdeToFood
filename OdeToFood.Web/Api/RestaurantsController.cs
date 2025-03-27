using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        public IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}