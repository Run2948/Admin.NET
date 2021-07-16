using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    public interface ISysOnlineUserService
    {
        Task<dynamic> List();
    }
}