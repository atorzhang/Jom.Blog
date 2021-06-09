using Jom.Blog.Services.BASE;
using Jom.Blog.Model.Models;
using Jom.Blog.IRepository;
using Jom.Blog.IServices;
using Jom.Blog.IRepository.Base;

namespace Jom.Blog.Services
{	
	/// <summary>
	/// ModulePermissionServices
	/// </summary>	
	public class ModulePermissionServices : BaseServices<ModulePermission>, IModulePermissionServices
    {

        IBaseRepository<ModulePermission> _dal;
        public ModulePermissionServices(IBaseRepository<ModulePermission> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
