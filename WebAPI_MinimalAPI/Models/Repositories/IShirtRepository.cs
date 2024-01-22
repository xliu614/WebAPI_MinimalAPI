namespace WebAPI_MinimalAPI.Models.Repositories
{
    public interface IShirtRepository
    {
        public List<Shirt> GetShirts();
        bool ShirtExists(int id);
        public Shirt? GetShirtByid(int id);
    }
}
