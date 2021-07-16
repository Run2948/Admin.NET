using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    public interface ISysVisLogService
    {
        Task ClearVisLog();

        Task<dynamic> QueryVisLogPageList([FromQuery] VisLogPageInput input);
    }
}