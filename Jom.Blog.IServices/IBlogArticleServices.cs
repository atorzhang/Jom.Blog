using Jom.Blog.IServices.BASE;
using Jom.Blog.Model.Models;
using Jom.Blog.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{
    public interface IBlogArticleServices :IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(int id);

    }

}
