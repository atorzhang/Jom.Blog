﻿using Jom.Blog.Common;
using Jom.Blog.Common.LogHelper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Jom.Blog.Middlewares
{
    /// <summary>
    /// 中间件
    /// 记录IP请求数据
    /// </summary>
    public class IPLogMildd
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public IPLogMildd(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (Appsettings.app("Middleware", "IPLog", "Enabled").ObjToBool())
            {
                // 过滤，只有接口
                if (context.Request.Path.Value.Contains("api"))
                {
                    context.Request.EnableBuffering();

                    try
                    {
                        // 存储请求数据
                        var request = context.Request;
                        var requestInfo = JsonConvert.SerializeObject(new RequestInfo()
                        {
                            Ip = GetClientIP(context),
                            Url = request.Path.ObjToString().TrimEnd('/').ToLower(),
                            Datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Date = DateTime.Now.ToString("yyyy-MM-dd"),
                            Week = GetWeek(),
                        });

                        if (!string.IsNullOrEmpty(requestInfo))
                        {
                            // 自定义log输出
                            Parallel.For(0, 1, e =>
                            {
                                LogLock.OutSql2Log("RequestIpInfoLog", new string[] { requestInfo + "," }, false);
                            });

                            // 这种方案也行，用的是Serilog
                            //SerilogServer.WriteLog("RequestIpInfoLog", new string[] { requestInfo + "," }, false);

                            request.Body.Position = 0;
                        }

                        await _next(context);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }

        private string GetWeek()
        {
            string week = string.Empty;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    week = "周一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "周二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "周三";
                    break;
                case DayOfWeek.Thursday:
                    week = "周四";
                    break;
                case DayOfWeek.Friday:
                    week = "周五";
                    break;
                case DayOfWeek.Saturday:
                    week = "周六";
                    break;
                case DayOfWeek.Sunday:
                    week = "周日";
                    break;
                default:
                    week = "N/A";
                    break;
            }
            return week;
        }

        public static string GetClientIP(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].ObjToString();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ObjToString();
            }
            return ip;
        }

    }
}

