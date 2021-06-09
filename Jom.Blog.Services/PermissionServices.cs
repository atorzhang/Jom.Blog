using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.Services
{
    /// <summary>
    /// PermissionServices
    /// </summary>	
    public class PermissionServices : BaseServices<Permission>, IPermissionServices
    {

        IBaseRepository<Permission> _dal;
        public PermissionServices(IBaseRepository<Permission> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
