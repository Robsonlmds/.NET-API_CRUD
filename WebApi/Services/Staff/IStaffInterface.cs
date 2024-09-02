using WebApi.Dto.Staff;
using WebApi.Models;

namespace WebApi.Services.Staff
{
    public interface IStaffInterface 
    {
        Task<ResponseModel<List<StaffModel>>> ListarStaffs ();
        Task<ResponseModel<StaffModel>> BuscarStaffPorId (Guid idStaff);
        Task<ResponseModel<StaffModel>> BuscarStaffPorIdCarro (Guid idStaff);
        Task<ResponseModel<List<StaffModel>>> CriarStaff (StaffAddDTO staffAddDTO);
        Task<ResponseModel<List<StaffModel>>> EditarStaff (StaffEditDTO staffEditDTO);
        Task<ResponseModel<List<StaffModel>>> DeletarStaff (Guid idStaff);
    }
}
    