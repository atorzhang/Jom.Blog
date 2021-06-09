using Jom.Blog.Common;
using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jom.Blog.Services
{
    public class TopicServices: BaseServices<Topic>, ITopicServices
    {

        IBaseRepository<Topic> _dal;
        public TopicServices(IBaseRepository<Topic> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        /// <summary>
        /// 获取开Bug专题分类（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 60)]
        public async Task<List<Topic>> GetTopics()
        {
            return await base.Query(a => !a.tIsDelete && a.tSectendDetail == "tbug");
        }

    }
}
