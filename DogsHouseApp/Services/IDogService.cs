using DogsHouse.Db.Entities;

namespace DogsHouseApp.Services
{
    public interface IDogService
    {
        public Task AddDogAsync(string name, string color, double tailLength, double weight);
        public Task<IEnumerable<Dog>> GetAllAsync();
        public IEnumerable<Dog> Sort(IEnumerable<Dog> dogs, string attribute, string order);
        public IEnumerable<Dog> GetDogsByPage(IEnumerable<Dog> dogs, int pageNumber, int pageSize);
    }
}
