using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.TaskScheduler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    /// <summary>
    /// 定时任务
    /// </summary>
    [ApiDescriptionSettings("Business", Name = "Job", Order = 100)]
    public class SpareTimeJobService : IDynamicApiController
    {
        /// <summary>
        /// 初始化一个简单任务
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string InitJob(string jobName = "jobName")
        {
            Console.WriteLine("简单任务初始化");

            SpareTime.Do(1000, (t, i) =>
            {
                Console.WriteLine($"{t.WorkerName} -{t.Description} - {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {i}");
            }, jobName, "模拟测试任务");

            return jobName;
        }

        /// <summary>
        /// 初始化一个简单任务，创建一个新的作用域进行数据库操作或解析服务
        /// </summary>
        /// <param name="jobName"></param>
        public void InitScopedJob(string jobName = "jobName")
        {
            SpareTime.Do(1000, (timer, count) =>
            {
                // 如果作用域中对数据库有任何变更操作，需手动调用 SaveChanges 或带 Now 结尾的方法。
                Scoped.Create((_, scope) =>
                {
                    var services = scope.ServiceProvider;

                    // 获取数据库上下文
                    var dbContext = Db.GetDbContext(services);
                    Console.WriteLine($"Scoped 中数据库提供者：{dbContext.Database.ProviderName}");

                    // 获取仓储
                    //var respository = Db.GetRepository<Person>(services);

                    // 解析其他服务
                    //var otherService = services.GetService<XXX>();
                    //var otherService2 = App.GetService<XXX>(services);

                });

                // 也可以使用 Scoped.CreateUow(handler) 代替。
                // Scoped.CreateUow((_, scope) => { });

            }, jobName);
        }

        /// <summary>
        /// 初始化一个 Cron 表达式任务，5秒执行一次
        /// </summary>
        /// <param name="cron"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string InitCronJob([FromBody] string cron = "*/5 * * * * *", string jobName = "cronName")
        {
            Console.WriteLine("Cron 任务初始化");

            SpareTime.Do(cron, (t, i) =>
            {
                Console.WriteLine($"{t.WorkerName} -{t.Description} - {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {i}");
            }, jobName, "模拟测试任务");

            return jobName;
        }

        /// <summary>
        /// 开始一个简单任务
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string StartJob(string jobName = "jobName")
        {
            Console.WriteLine("任务开始");
            SpareTime.Start(jobName);

            return jobName;
        }

        /// <summary>
        /// 停止一个简单任务
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string StopJob(string jobName = "jobName")
        {
            Console.WriteLine("任务停止");
            SpareTime.Stop(jobName);

            return jobName;
        }

        /// <summary>
        /// 取消一个简单任务
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string CancelJob(string jobName = "jobName")
        {
            Console.WriteLine("任务取消");
            SpareTime.Cancel(jobName);

            return jobName;
        }

        /// <summary>
        /// 获取所有任务信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetWorkers()
        {
            return SpareTime.GetWorkers().ToList().Select(u => new
            {
                u.WorkerName,
                Status = u.Status.ToString(),
                u.Description,
                Type = u.Type.ToString(),
                ExecuteType = u.ExecuteType.ToString()
            });
        }

        /// <summary>
        /// 串行执行任务
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string InitSerialJob(string jobName = "serialJob")
        {
            Console.WriteLine("串行执行任务");

            SpareTime.Do(1000, (t, i) =>
            {
                Thread.Sleep(5000); // 模拟执行耗时任务
                Console.WriteLine($"{t.WorkerName} -{t.Description} - {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {i}");
            }, jobName, "模拟测试任务", executeType: SpareTimeExecuteTypes.Serial);

            return jobName;
        }

        /// <summary>
        /// 测试异常任务
        /// </summary>
        public void TestExceptionWorker()
        {
            SpareTime.Do(1000, (t, c) =>
            {
                // 判断是否有异常
                if (t.Exception.Any())
                {
                    Console.WriteLine(t.Exception.Values.LastOrDefault()?.Message);
                }

                // 执行第三次抛异常
                if (c > 5)
                {
                    throw Oops.Oh("抛异常" + c);
                }
                else
                {
                    Console.WriteLine($"{t.WorkerName} -{t.Description} - {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {c}");
                }
            }, "exceptionJob");
        }

        /// <summary>
        /// 测试只执行一次
        /// </summary>
        public void DoOnce()
        {
            SpareTime.DoOnce(5000, (t, c) =>
            {
                Console.WriteLine("测试执行一次");
            });
        }

        /// <summary>
        /// 测试模拟后台执行
        /// </summary>
        public void DoIt()
        {
            SpareTime.DoIt(() =>
            {
                Console.WriteLine("测试模拟后台执行一次");
            },100);
        }
    }
}
