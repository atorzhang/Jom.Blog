using Jom.Blog.IServices.BASE;
using Jom.Blog.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{
    public interface ITopicServices : IBaseServices<Topic>
    {
        Task<List<Topic>> GetTopics();
    }
}
