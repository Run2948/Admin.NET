using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    public interface ISysEnumDataService
    {
        Task<dynamic> GetEnumDataList([FromQuery] EnumDataInput input);

        Task<dynamic> GetEnumDataListByField([FromQuery] QueryEnumDataInput input);
    }
}