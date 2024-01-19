﻿using WebAPI_MinimalAPI.Controllers;

namespace WebAPI_MinimalAPI.Models.Repositories
{
    public class ShirtRepository
    {
        private static readonly List<Shirt> shirts = new List<Shirt>()
        {
           new Shirt {ShirtId=1, Brand = "V Brand", Color ="Yellow", Gender="women", Price = 30, Size=6 },
           new Shirt {ShirtId=2, Brand = "V Brand", Color ="Blue", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=3, Brand = "W Brand", Color ="Purple", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=4, Brand = "W Brand", Color ="Black", Gender="men", Price = 30, Size=10 },
           new Shirt {ShirtId=5, Brand = "Y Brand", Color ="White", Gender="women", Price = 10, Size = 6 }
        };

        public static List<Shirt> GetShirts() {
            return shirts;
        }

        public static bool ShirtExists(int id) {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByid(int id) {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByProps(string? brand, string? gender, string? color, int? size) {
            return shirts.FirstOrDefault(x => !string.IsNullOrWhiteSpace(brand) &&
                                               !string.IsNullOrWhiteSpace(x.Brand) &&
                                               x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                                               !string.IsNullOrWhiteSpace(gender) &&
                                               !string.IsNullOrWhiteSpace(x.Gender) &&
                                               x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                                               !string.IsNullOrWhiteSpace(color) &&
                                               !string.IsNullOrWhiteSpace(x.Color) &&
                                               x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                                               size.HasValue &&
                                               x.Size.HasValue &&
                                               x.Size.Value == size.Value);
        }

        public static void AddShirt(Shirt shirt) {
            int newId = shirts.Max(s => s.ShirtId) + 1;
            shirt.ShirtId = newId;

            shirts.Add(shirt);
        }
    }
}
