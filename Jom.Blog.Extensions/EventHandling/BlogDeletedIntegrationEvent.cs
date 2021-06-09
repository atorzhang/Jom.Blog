﻿namespace Jom.Blog.EventBus.EventHandling
{
    public class BlogDeletedIntegrationEvent : IntegrationEvent
    {
        public string BlogId { get; private set; }

        public BlogDeletedIntegrationEvent(string blogid)
            => BlogId = blogid;
    }
}
