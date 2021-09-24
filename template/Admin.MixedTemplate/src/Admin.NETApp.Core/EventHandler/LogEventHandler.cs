using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.EventBridge;

namespace Admin.NETApp.Core
{
    /// <summary>
    /// 日志订阅处理
    /// </summary>
    [EventHandler]
    public class LogEventHandler : IEventHandler
    {
        private readonly IRepository<SysLogOp> _sysLogOpRep;
        private readonly IRepository<SysLogEx> _sysLogExRep;
        private readonly IRepository<SysLogVis> _sysLogVisRep;
        public LogEventHandler(IRepository<SysLogVis> sysLogVisRep, IRepository<SysLogOp> sysLogOpRep, IRepository<SysLogEx> sysLogExRep)
        {
            _sysLogVisRep = sysLogVisRep;
            _sysLogOpRep = sysLogOpRep;
            _sysLogExRep = sysLogExRep;
        }

        [EventMessage]
        public void CreateOpLog(EventMessage eventMessage)
        {
            SysLogOp log = (SysLogOp)eventMessage.Payload;
            _sysLogOpRep.InsertNow(log);
        }

        [EventMessage]
        public void CreateExLog(EventMessage eventMessage)
        {
            SysLogEx log = (SysLogEx)eventMessage.Payload;
            _sysLogExRep.InsertNow(log);
        }

        [EventMessage]
        public void CreateVisLog(EventMessage eventMessage)
        {
            SysLogVis log = (SysLogVis)eventMessage.Payload;
            _sysLogVisRep.InsertNow(log);

        }
    }
}