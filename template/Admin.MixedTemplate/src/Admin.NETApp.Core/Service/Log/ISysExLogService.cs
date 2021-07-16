using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    public interface ISysExLogService
    {
        Task ClearExLog();

        Task<dynamic> QueryExLogPageList([FromQuery] ExLogPageInput input);
    }
}