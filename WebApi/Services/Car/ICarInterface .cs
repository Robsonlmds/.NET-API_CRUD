using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Car;
using WebApi.Models;

namespace WebApi.Services.Car
{
    public interface ICarInterface 
    {
        Task<ResponseModel<List<CarModel>>> ListarCar ();
        Task<ResponseModel<CarModel>> BuscarCarPorId (Guid idCar);
        Task<ResponseModel<List<CarModel>>> BuscarCarPorIdStaff(Guid idCar);
        Task<IActionResult> CriarCar (CarAddDTO carAddDTO);
        Task<ResponseModel<List<CarModel>>> EditarCar (CarEditDTO carEditDTO);
        Task<ResponseModel<List<CarModel>>> DeletarCar (Guid idCar);
    }
}
    