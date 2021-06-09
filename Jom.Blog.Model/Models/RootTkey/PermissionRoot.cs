﻿using SqlSugar;
using System;
using System.Collections.Generic;

namespace Jom.Blog.Model
{
    /// <summary>
    /// 路由菜单表
    /// </summary>
    public class PermissionRoot<Tkey> : RootEntityTkey<Tkey> where Tkey : IEquatable<Tkey>
    {

        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        public Tkey Pid { get; set; }

        /// <summary>
        /// 接口api
        /// </summary>
        public Tkey Mid { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<Tkey> PidArr { get; set; }

    }
}
