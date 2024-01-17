using WebAPI_MinimalAPI.Controllers;

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

        public static bool ShirtExists(int id) {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtByid(int id) {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }
    }
}
