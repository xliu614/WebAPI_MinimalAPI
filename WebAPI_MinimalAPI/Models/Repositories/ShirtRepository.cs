﻿using WebAPI_MinimalAPI.Controllers;
using WebAPI_MinimalAPI.Data;

namespace WebAPI_MinimalAPI.Models.Repositories
{
    public class ShirtRepository:IShirtRepository
    {
        private readonly ApplicationDbContext _context;
        public ShirtRepository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;   
        }
        private static readonly List<Shirt> shirts = new List<Shirt>()
        {
           new Shirt {ShirtId=1, Brand = "V Brand", Color ="Yellow", Gender="women", Price = 30, Size=6 },
           new Shirt {ShirtId=2, Brand = "V Brand", Color ="Blue", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=3, Brand = "W Brand", Color ="Purple", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=4, Brand = "W Brand", Color ="Black", Gender="men", Price = 30, Size=10 },
           new Shirt {ShirtId=5, Brand = "Y Brand", Color ="White", Gender="women", Price = 10, Size = 6 }
        };

        public List<Shirt> GetShirts() {
            return _context.Shirts.ToList();
        }

        public bool ShirtExists(int id) {
            var shirt = _context.Shirts.Find(id);
            if (shirt == null)
                return false;
            return true;
        }

        public Shirt? GetShirtByid(int id) {
            return _context.Shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public Shirt? GetShirtByProps(string? brand, string? gender, string? color, int? size) {
            return _context.Shirts.FirstOrDefault(x =>  !string.IsNullOrWhiteSpace(brand) &&
                                               !string.IsNullOrWhiteSpace(x.Brand) &&
                                               x.Brand.ToLower() == brand.ToLower() &&
                                               !string.IsNullOrWhiteSpace(gender) &&
                                               !string.IsNullOrWhiteSpace(x.Gender) &&
                                               x.Gender.ToLower() == gender.ToLower() &&
                                               !string.IsNullOrWhiteSpace(color) &&
                                               !string.IsNullOrWhiteSpace(x.Color) &&
                                               x.Color.ToLower() == color.ToLower() &&
                                               size.HasValue &&
                                               x.Size.HasValue &&
                                               x.Size.Value == size.Value);
        }

        public void AddShirt(Shirt shirt) {
            _context.Shirts.Add(shirt);
            _context.SaveChanges();
        }

        public void UpdateShirt(Shirt shirtForUpdate, Shirt shirt) {
                shirtForUpdate.Brand = shirt.Brand;
                shirtForUpdate.Price = shirt.Price;
                shirtForUpdate.Size = shirt.Size;
                shirtForUpdate.Color = shirt.Color;
                shirtForUpdate.Gender = shirt.Gender;
                _context.SaveChanges();          
        }

        public void RemoveShirt(int shirtId) {
            var shirt = GetShirtByid(shirtId);
            if (shirt != null) {
                shirts.Remove(shirt);
            }
        }
    }
}
