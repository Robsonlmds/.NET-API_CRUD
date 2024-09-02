using WebApi.Dto.Between;
namespace WebApi.Dto.Car
{
    public class CarEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public BetweenDTO Staff { get; set; }


    }
}
