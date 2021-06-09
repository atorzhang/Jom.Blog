using Jom.Blog.Common;
using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;
using System.Linq;
using System.Threading.Tasks;

namespace Jom.Blog.Services
{
    /// <summary>
    /// RoleServices
    /// </summary>	
    public class RoleServices : BaseServices<Role>, IRoleServices
    {

        IBaseRepository<Role> _dal;
        public RoleServices(IBaseRepository<Role> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="roleName"></param>
       /// <returns></returns>
        public async Task<Role> SaveRole(string roleName)
        {
            Role role = new Role(roleName);
            Role model = new Role();
            var userList = await base.Query(a => a.Name == role.Name && a.Enabled);
            if (userList.Count > 0)
            {
                model = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.Add(role);
                model = await base.QueryById(id);
            }

            return model;

        }

        [Caching(AbsoluteExpiration = 30)]
        public async Task<string> GetRoleNameByRid(int rid)
        {
            return ((await base.QueryById(rid))?.Name);
        }
    }
}
