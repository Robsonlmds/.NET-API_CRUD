using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Car;
using WebApi.Models;
using WebApi.Services.Car;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarInterface _carInterface;
        public CarController (ICarInterface carInterface)
        {
            _carInterface = carInterface;
        }


        [HttpGet("ListarCar")]
        public async Task<ActionResult<ResponseModel<List<CarModel>>>> ListarCar()
        {
            var cars = await _carInterface.ListarCar();
            return Ok(cars);
        }


        [HttpGet("BuscarCarPorId/{idCar}")]
        public async Task<ActionResult<ResponseModel<CarModel>>> BuscarCarPorId (Guid idCar)
        {
            var car = await _carInterface.BuscarCarPorId (idCar);
            return Ok(car);
        }


        [HttpGet("BuscarCarPorIdStaff/{IdStaff}")]
        public async Task<ActionResult<ResponseModel<CarModel>>> BuscarCarPorIdStaff(Guid IdStaff)
        {
            var car = await _carInterface.BuscarCarPorIdStaff(IdStaff);
            return Ok(car);
        }

        [HttpPost("CriarCar")]
        public async Task<ActionResult<ResponseModel<CarModel>>> CriarCar (CarAddDTO carModel)
        {
            var car = await _carInterface.CriarCar(carModel);
            return Ok(car);
        }

        [HttpPut("EditarCar")]
        public async Task<ActionResult<ResponseModel<List<CarModel>>>> EditarCar (CarEditDTO CarEditDTO)
        {
            var car = await _carInterface.EditarCar (CarEditDTO);
            return Ok(car);
        }

        [HttpDelete("DeletarCar")]
        public async Task<ActionResult<ResponseModel<List<CarModel>>>> DeletarCar (Guid IdCar)
        {
            var car = await _carInterface.DeletarCar (IdCar);
            return Ok(car);
        }
    }
}
