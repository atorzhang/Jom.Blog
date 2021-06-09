﻿using System;

namespace Jom.Blog.Model
{
    /// <summary>
    /// Tibug 博文
    /// </summary>
    public class TopicDetailRoot<Tkey> : RootEntityTkey<Tkey> where Tkey : IEquatable<Tkey>
    {
        public Tkey TopicId { get; set; }
    }
}
