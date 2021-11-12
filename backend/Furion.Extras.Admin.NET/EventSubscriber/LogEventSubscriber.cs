using System;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;
using Furion.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace Furion.Extras.Admin.NET
{
    public class LogEventSubscriber : IEventSubscriber
    {
        public IServiceProvider Services { get; }

        public LogEventSubscriber(IServiceProvider services)
        {
            Services = services;
        }

        [EventSubscribe("Create:OpLog")]
        public async Task CreateOpLog(EventHandlerExecutingContext context)
        {
            using var scope = Services.CreateScope();
            var _repository = scope.ServiceProvider.GetRequiredService<IRepository<SysLogOp>>();
            var log = (SysLogOp)context.Source.Payload;
            await _repository.InsertNowAsync(log);
        }

        [EventSubscribe("Create:ExLog")]
        public async Task CreateExLog(EventHandlerExecutingContext context)
        {
            using var scope = Services.CreateScope();
            var _repository = scope.ServiceProvider.GetRequiredService<IRepository<SysLogEx>>();
            var log = (SysLogEx)context.Source.Payload;
            await _repository.InsertNowAsync(log);
        }

        [EventSubscribe("Create:VisLog")]
        public async Task CreateVisLog(EventHandlerExecutingContext context)
        {
            using var scope = Services.CreateScope();
            var _repository = scope.ServiceProvider.GetRequiredService<IRepository<SysLogVis>>();
            var log = (SysLogVis)context.Source.Payload;
            await _repository.InsertNowAsync(log);
        }
    }
}