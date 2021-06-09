using Jom.Blog.Common;
using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jom.Blog.Services
{
    public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
        IBaseRepository<TopicDetail> _dal;
        public TopicDetailServices(IBaseRepository<TopicDetail> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        /// <summary>
        /// 获取开Bug数据（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<TopicDetail>> GetTopicDetails()
        {
            return await base.Query(a => !a.tdIsDelete && a.tdSectendDetail == "tbug");
        }
    }
}
