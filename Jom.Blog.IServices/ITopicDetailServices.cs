using Jom.Blog.IServices.BASE;
using Jom.Blog.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{
    public interface ITopicDetailServices : IBaseServices<TopicDetail>
    {
        Task<List<TopicDetail>> GetTopicDetails();
    }
}
