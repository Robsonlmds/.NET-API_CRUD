using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Staff;
using WebApi.Models;


namespace WebApi.Services.Staff
{
    public class StaffService : IStaffInterface
    {
        private readonly ApplicationDbContext _context;
        public StaffService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<StaffModel>> BuscarStaffPorId(Guid idStaff)
        {
            ResponseModel<StaffModel> resposta = new ResponseModel<StaffModel>();
            try
            {

                var staff = await _context.Staffs.FirstOrDefaultAsync(staffBanco => staffBanco.Id == idStaff);

                if (staff == null)
                {
                    resposta.Mensagem = "Nenhum Registro foi emcontrado!";
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

        public async Task<ResponseModel<StaffModel>> BuscarStaffPorIdCarro(Guid idCar)  
        {
            ResponseModel<StaffModel> resposta = new ResponseModel<StaffModel>();
            try
            {
                var carro = await _context.Cars
                    .Include(a => a.Staff)
                    .FirstOrDefaultAsync(carroBanco => carroBanco.Id == idCar);

                if (carro == null)
                {
                    resposta.Mensagem = "Nenhum registo Localizado!";
                    return resposta;
                }

                resposta.Dados = carro.Staff;
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

        public async Task<ResponseModel<List<StaffModel>>> CriarStaff(StaffAddDTO staffAddDTO)
        {
            ResponseModel<List<StaffModel>> resposta = new ResponseModel<List<StaffModel>>();

            try
            {
                var staff = new StaffModel()
                {
                    Name = staffAddDTO.Name,
                    Address = staffAddDTO.Address
                };

                _context.Add(staff);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Staffs.ToListAsync();
                resposta.Mensagem = "Staff Criada!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StaffModel>>> DeletarStaff(Guid idStaff)
        {
            ResponseModel<List<StaffModel>> resposta = new ResponseModel<List<StaffModel>>();

            try
            {
                var staff = await _context.Staffs
                    .FirstOrDefaultAsync(staffBanco => staffBanco.Id == idStaff);

                if (staff == null)
                {

                    resposta.Mensagem = "Staff não existe!";
                    return resposta;
                }

                _context.Remove(staff);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Staffs.ToListAsync();
                resposta.Mensagem = "Staff DELETADA";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StaffModel>>> EditarStaff(StaffEditDTO staffEditDTO)
        {
            ResponseModel<List<StaffModel>> resposta = new ResponseModel<List<StaffModel>>();

            try
            {
                var staff = await _context.Staffs
                    .FirstOrDefaultAsync(staffBanco => staffBanco.Id == staffEditDTO.Id);

                if (staff == null)
                {
                    resposta.Mensagem = " Staff não existe! ";
                    return resposta;
                }

                staff.Name = staffEditDTO.Name;
                staff.Address = staffEditDTO.Address;

                _context.Update(staff);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Staffs.ToListAsync();
                resposta.Mensagem = "Staff Editada";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StaffModel>>> ListarStaffs()
        {
            ResponseModel<List<StaffModel>> resposta = new ResponseModel<List<StaffModel>>();
            try
            {
                var staff = _context.Staffs.ToList();
                resposta.Dados = staff;
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
