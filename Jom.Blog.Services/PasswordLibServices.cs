using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.Services
{
    public partial class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
        IBaseRepository<PasswordLib> _dal;
        public PasswordLibServices(IBaseRepository<PasswordLib> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
