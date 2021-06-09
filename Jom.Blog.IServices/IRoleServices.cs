using Jom.Blog.IServices.BASE;
using Jom.Blog.Model.Models;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
    public interface IRoleServices :IBaseServices<Role>
	{
        Task<Role> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);

    }
}
