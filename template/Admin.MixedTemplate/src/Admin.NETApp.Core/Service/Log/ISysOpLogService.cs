using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    public interface ISysOpLogService
    {
        Task ClearOpLog();

        Task<dynamic> QueryOpLogPageList([FromQuery] OpLogPageInput input);
    }
}