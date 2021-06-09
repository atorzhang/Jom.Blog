using Jom.Blog.IRepository.Base;
using Jom.Blog.Model.IDS4DbModels;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.IServices
{
    public class ApplicationUserServices : BaseServices<ApplicationUser>, IApplicationUserServices
    {

        IBaseRepository<ApplicationUser> _dal;
        public ApplicationUserServices(IBaseRepository<ApplicationUser> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}