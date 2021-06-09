using Jom.Blog.IServices.BASE;
using Jom.Blog.Model.Models;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserRoleServices :IBaseServices<UserRole>
	{

        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}

