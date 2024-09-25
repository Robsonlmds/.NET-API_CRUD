using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Staff;
using WebApi.Models;
using WebApi.Services.Staff;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IStaffInterface _staffInterface;
        public StaffController (IStaffInterface staffInterface) 
        {
            _staffInterface = staffInterface;
        }


        [HttpGet("ListarStaff")]
        public async Task<ActionResult<ResponseModel<List<StaffModel>>>> ListarStaffs()
        {
            var staffs = await _staffInterface.ListarStaffs();
            return Ok(staffs);   
        }   


        [HttpGet("BuscarStaffPorId/{idStaff}")]
        public async Task<ActionResult<ResponseModel<StaffModel>>> BuscarStaffPorId (Guid idStaff)
        {
            var staff = await _staffInterface.BuscarStaffPorId (idStaff);
            return Ok(staff);   
        }


        [HttpGet("BuscarStaffPorIdCarro/{idCar}")]
        public async Task<ActionResult<ResponseModel<StaffModel>>> BuscarStaffPorIdCarro (Guid idCar)
        {
            var staff = await _staffInterface.BuscarStaffPorIdCarro (idCar);
            return Ok(staff);
        }

        [HttpPost("CriarStaff")]
        public async Task<ActionResult<ResponseModel<StaffModel>>> CriarStaff (StaffAddDTO staffAddDTO)
        {
           var staff = await _staffInterface.CriarStaff (staffAddDTO);
           return Ok(staff); 
        }

        [HttpPut("EditarStaff")]
        public async Task<ActionResult<ResponseModel<List<StaffModel>>>> EditarStaff (StaffEditDTO staffEditDTO)
        {
            var staff = await _staffInterface.EditarStaff (staffEditDTO);
            return Ok(staff);
        }

        [HttpDelete("DeletarStaff/{IdStaff}")]
        public async Task<ActionResult<ResponseModel<List<StaffModel>>>> DeletarStaff (Guid IdStaff)
        {
            var staff = await _staffInterface.DeletarStaff (IdStaff);
            return Ok(staff);
        }

    }
}
 