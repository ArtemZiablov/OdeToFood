using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return 
                from r in _db.Restaurants 
                orderby r.Name
                select r;
        }

        public Restaurant Get(int id)
        {
            return _db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            var entry = _db.Entry(restaurant);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurantToDelete = _db.Restaurants.Find(id);
            if (restaurantToDelete != null) _db.Restaurants.Remove(restaurantToDelete);
            _db.SaveChanges();
        }
    }
}