using Jom.Blog.IServices.BASE;
using Jom.Blog.Model;
using Jom.Blog.Model.Models;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{
    public partial interface IGuestbookServices : IBaseServices<Guestbook>
    {
        Task<MessageModel<string>> TestTranInRepository();
        Task<bool> TestTranInRepositoryAOP();
    }
}
