﻿using Jom.Blog.Common;
using Jom.Blog.Common.Helper;
using Jom.Blog.Common.LogHelper;
using Jom.Blog.Hubs;
using Jom.Blog.IServices;
using Jom.Blog.Middlewares;
using Jom.Blog.Model;
using Jom.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jom.Blog.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class MonitorController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IWebHostEnvironment _env;
        private readonly IApplicationUserServices _applicationUserServices;
        private readonly ILogger<MonitorController> _logger;

        public MonitorController(IHubContext<ChatHub> hubContext, IWebHostEnvironment env, IApplicationUserServices applicationUserServices, ILogger<MonitorController> logger)
        {
            _hubContext = hubContext;
            _env = env;
            _applicationUserServices = applicationUserServices;
            _logger = logger;
        }

        /// <summary>
        /// 服务器配置信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public MessageModel<ServerViewModel> Server()
        {
            return new MessageModel<ServerViewModel>()
            {
                msg = "获取成功",
                success = true,
                response = new ServerViewModel()
                {
                    EnvironmentName = _env.EnvironmentName,
                    OSArchitecture = RuntimeInformation.OSArchitecture.ObjToString(),
                    ContentRootPath = _env.ContentRootPath,
                    WebRootPath = _env.WebRootPath,
                    FrameworkDescription = RuntimeInformation.FrameworkDescription,
                    MemoryFootprint = (Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + " MB",
                    WorkingTime = DateHelper.TimeSubTract(DateTime.Now, Process.GetCurrentProcess().StartTime)
                }
            };
        }


        /// <summary>
        /// SignalR send data
        /// </summary>
        /// <returns></returns>
        // GET: api/Logs
        [HttpGet]
        public MessageModel<List<LogInfo>> Get()
        {

            _hubContext.Clients.All.SendAsync("ReceiveUpdate", LogLock.GetLogData()).Wait();

            return new MessageModel<List<LogInfo>>()
            {
                msg = "获取成功",
                success = true,
                response = null
            };
        }



        [HttpGet]
        public MessageModel<RequestApiWeekView> GetRequestApiinfoByWeek()
        {
            return new MessageModel<RequestApiWeekView>()
            {
                msg = "获取成功",
                success = true,
                response = LogLock.RequestApiinfoByWeek()
            };
        }

        [HttpGet]
        public MessageModel<AccessApiDateView> GetAccessApiByDate()
        {
            return new MessageModel<AccessApiDateView>()
            {
                msg = "获取成功",
                success = true,
                response = LogLock.AccessApiByDate()
            };
        }

        [HttpGet]
        public MessageModel<AccessApiDateView> GetAccessApiByHour()
        {
            return new MessageModel<AccessApiDateView>()
            {
                msg = "获取成功",
                success = true,
                response = LogLock.AccessApiByHour()
            };
        }

        [HttpGet]
        public MessageModel<WelcomeInitData> GetActiveUsers([FromServices]IWebHostEnvironment environment)
        {
            var accessLogsToday = JsonConvert.DeserializeObject<List<UserAccessModel>>("[" + LogLock.ReadLog(
                Path.Combine(environment.ContentRootPath, "Log"), "RecordAccessLogs_", Encoding.UTF8, ReadType.PrefixLatest
                ) + "]")
                .Where(d => d.BeginTime.ObjToDate() >= DateTime.Today);

            var Logs = accessLogsToday.OrderByDescending(d => d.BeginTime).Take(50).ToList();

            var errorCountToday = LogLock.GetLogData().Where(d => d.Import == 9).Count();

            accessLogsToday = accessLogsToday.Where(d => d.User != "").ToList();

            var activeUsers = (from n in accessLogsToday
                               group n by new { n.User } into g
                               select new ActiveUserVM
                               {
                                   user = g.Key.User,
                                   count = g.Count(),
                               }).ToList();

            int activeUsersCount = activeUsers.Count;
            activeUsers = activeUsers.OrderByDescending(d => d.count).Take(10).ToList();

            return new MessageModel<WelcomeInitData>()
            {
                msg = "获取成功",
                success = true,
                response = new WelcomeInitData()
                {
                    activeUsers = activeUsers,
                    activeUserCount = activeUsersCount,
                    errorCount = errorCountToday,
                    logs = Logs
                }
            };
        }

        [HttpGet]
        public async Task<MessageModel<AccessApiDateView>> GetIds4Users()
        {
            List<ApiDate> apiDates = new List<ApiDate>();

            if (Appsettings.app(new string[] { "MutiDBEnabled" }).ObjToBool())
            {
                var users = await _applicationUserServices.Query(d => d.tdIsDelete == false);

                apiDates = (from n in users
                            group n by new { n.birth.Date } into g
                            select new ApiDate
                            {
                                date = g.Key?.Date.ToString("yyyy-MM-dd"),
                                count = g.Count(),
                            }).ToList();

                apiDates = apiDates.OrderByDescending(d => d.date).Take(30).ToList();
            }


            if (apiDates.Count == 0)
            {
                apiDates.Add(new ApiDate()
                {
                    date = "没数据,或未开启相应接口服务",
                    count = 0
                });
            }
            return new MessageModel<AccessApiDateView>()
            {
                msg = "获取成功",
                success = true,
                response = new AccessApiDateView
                {
                    columns = new string[] { "date", "count" },
                    rows = apiDates.OrderBy(d => d.date).ToList(),
                }
            };
        }

    }

    public class WelcomeInitData
    {
        public List<ActiveUserVM> activeUsers { get; set; }
        public int activeUserCount { get; set; }
        public List<UserAccessModel> logs { get; set; }
        public int errorCount { get; set; }
    }

}
