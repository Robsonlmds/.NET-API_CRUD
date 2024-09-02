using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<CarModel> Cars { get; set; }
    }
}
