namespace WebAPI_MinimalAPI.Models.Repositories
{
    public interface IShirtRepository
    {
        public List<Shirt> GetShirts();
        bool ShirtExists(int id);
        public Shirt? GetShirtByid(int id);
        public Shirt? GetShirtByProps(string? brand, string? gender, string? color, int? size);
        public void AddShirt(Shirt shirt);
        public void UpdateShirt(Shirt shirtForUpdate, Shirt shirt);
    }
}
