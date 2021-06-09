﻿using SqlSugar;
using System;
using System.Collections.Generic;

namespace Jom.Blog.Model.Models
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class sysUserInfo : sysUserInfoRoot<int>
    {
        public sysUserInfo() { }

        public sysUserInfo(string loginName, string loginPWD)
        {
            uLoginName = loginName;
            uLoginPWD = loginPWD;
            uRealName = uLoginName;
            uStatus = 0;
            uCreateTime = DateTime.Now;
            uUpdateTime = DateTime.Now;
            uLastErrTime = DateTime.Now;
            uErrorCount = 0;
            name = "";

        }

        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uLoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uLoginPWD { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uRealName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int uStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 2000, IsNullable = true)]
        public string uRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime uCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime uUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///最后登录时间 
        /// </summary>
        public DateTime uLastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///错误次数 
        /// </summary>
        public int uErrorCount { get; set; }



        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string name { get; set; }

        // 性别
        [SugarColumn(IsNullable = true)]
        public int sex { get; set; } = 0;
        // 年龄
        [SugarColumn(IsNullable = true)]
        public int age { get; set; }
        // 生日
        [SugarColumn(IsNullable = true)]
        public DateTime birth { get; set; } = DateTime.Now;
        // 地址
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string addr { get; set; }

        [SugarColumn(IsNullable = true)]
        public bool tdIsDelete { get; set; }


        [SugarColumn(IsIgnore = true)]
        public List<string> RoleNames { get; set; }

    }
}
