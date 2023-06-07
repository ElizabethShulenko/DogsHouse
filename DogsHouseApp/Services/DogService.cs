using DogsHouse.Db.Entities;
using DogsHouse.Db.Repository;

namespace DogsHouseApp.Services
{
    public class DogService : IDogService
    {
        private readonly IRepository<Dog> _repository;

        public DogService(IRepository<Dog> repository)
        {
            _repository = repository;
        }

        public async Task AddDogAsync(string name, string color, double tailLength, double weight)
        {
            var dog = new Dog() { Name = name, Color = color, TailLength = tailLength, Weight = weight };

            await _repository.AddAsync(dog);
        }
        public async Task<IEnumerable<Dog>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result;
        }

        public IEnumerable<Dog> GetDogsByPage(IEnumerable<Dog> dogs, int pageNumber, int pageSize)
        {
            var result = dogs.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return result;
        }

        public IEnumerable<Dog> Sort(IEnumerable<Dog> dogs, string attribute, string order)
        {
            var isDesc = order == "desc";

            Func<Dog, object> keySelector = null;

            switch (attribute.ToLower())
            {
                case "name":
                    keySelector = new Func<Dog, string>(m => m.Name);
                    break;
                case "color":
                    keySelector = new Func<Dog, string>(m => m.Color);
                    break;
                case "tail length":
                    keySelector = new Func<Dog, object>(m => m.TailLength);
                    break;
                case "weight":
                    keySelector = new Func<Dog, object>(m => m.Weight);
                    break;
                default:
                    break;
            }

            if (keySelector != null)
            {
                dogs = isDesc 
                    ? dogs.OrderByDescending(keySelector)
                    : dogs.OrderBy(keySelector);
            }

            return dogs;
        }
    }
}
