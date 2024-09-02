using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WebApi.Data;
using WebApi.Dto.Car;
using WebApi.Dto.Staff;
using WebApi.Models;

namespace WebApi.Services.Car
{
    public class CarService : ICarInterface
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CarModel>> BuscarCarPorId (Guid idCar)
        {
            ResponseModel<CarModel> resposta = new ResponseModel<CarModel>();

            try
            {
                var car = await _context.Cars.Include(a => a.Staff)
                    .FirstOrDefaultAsync(carBanco => carBanco.Id == idCar);

                if (car == null)
                {
                    resposta.Mensagem = "Nenhum Registro foi emcontrado!";
                    return resposta;
                }

                resposta.Dados = car;
                resposta.Mensagem = "Carro foi Localizado!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CarModel>>> BuscarCarPorIdStaff(Guid idStaff)
        {
            ResponseModel<List<CarModel>> resposta = new ResponseModel<List<CarModel>> ();
            try
            {
                var staff = await _context.Cars
                    .Include(a => a.Staff)
                    .Where(staffBanco => staffBanco.Staff.Id == idStaff)
                    .ToListAsync();

                if (staff == null)
                {
                    resposta.Mensagem = "Nenhum registo Localizado!";
                    return resposta;
                }

                resposta.Dados = staff;
                resposta.Mensagem = "Staff Localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CarModel>>> CriarCar(CarAddDTO carAddDTO)
        {
            ResponseModel<List<CarModel>> resposta = new ResponseModel<List<CarModel>>();

            try
            {
                var staff = await _context.Staffs
                    .FirstOrDefaultAsync(staffBanco => staffBanco.Id == carAddDTO.Staff.Id);

                if(staff == null)
                {
                    resposta.Mensagem = "Nenhum carro foi criado!";
                    return resposta;
                }

                var car = new CarModel()
                {
                    Name = carAddDTO.Name,
                    Staff = staff,
                };

                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cars
                    .Include(a => a.Staff).ToListAsync();

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CarModel>>> DeletarCar(Guid idCar)
        {
            ResponseModel<List<CarModel>> resposta = new ResponseModel<List<CarModel>>();

            try
            {
                var car = await _context.Cars.FirstOrDefaultAsync(carBanco => carBanco.Id == idCar);

                if (car == null)
                {
                    resposta.Mensagem = "Este carro não existe!";
                    return resposta;
                }

                _context.Remove(car);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cars.ToListAsync();
                resposta.Mensagem = "Carro DELETADO";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CarModel>>> EditarCar(CarEditDTO carEditDTO)
        {
            ResponseModel<List<CarModel>> resposta = new ResponseModel<List<CarModel>>();

            try
            {

                var carro = await _context.Cars
                    .Include(a => a.Staff)
                    .FirstOrDefaultAsync(CarBanco => CarBanco.Id == carEditDTO.Id);

                var staff = await _context.Staffs
                    .FirstOrDefaultAsync(staffBanco => staffBanco.Id == carEditDTO.Staff.Id);

                if (carro == null)
                {
                    resposta.Mensagem = "Nenhum carro foi localizado!";
                    return resposta;
                }

                if (staff == null)
                {
                    resposta.Mensagem = "Nenhuma staff foi localizada!";
                    return resposta;
                }

                carro.Name = carEditDTO.Name;
                carro.Staff = staff;    

                _context.Cars.Add(carro);   
                await _context.SaveChangesAsync();  

                resposta.Dados = await _context.Cars.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CarModel>>> ListarCar()
        {
            ResponseModel<List<CarModel>> resposta = new ResponseModel<List<CarModel>>();
            try
            {
                var carros = await _context.Cars.Include(a => a.Staff).ToListAsync();

                resposta.Dados = carros;
                resposta.Mensagem = "Todos os dados foram coletados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
