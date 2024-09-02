using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace WebApi.Dto.Staff
{
    public class StaffEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
