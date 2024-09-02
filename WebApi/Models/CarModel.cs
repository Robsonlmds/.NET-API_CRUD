using System.Runtime.InteropServices.Marshalling;

namespace WebApi.Models
{
    public class CarModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid StaffId { get; set; }
        public StaffModel Staff { get; set; }

    }
}
