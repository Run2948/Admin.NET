using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Core.Service
{
    public interface ISysSmsService
    {
        Task<dynamic> QuerySmsPageList([FromQuery] SmsPageInput input);
    }
}
