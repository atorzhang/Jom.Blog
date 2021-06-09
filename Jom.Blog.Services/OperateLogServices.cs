using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.Services
{
    public partial class OperateLogServices : BaseServices<OperateLog>, IOperateLogServices
    {
        IBaseRepository<OperateLog> _dal;
        public OperateLogServices(IBaseRepository<OperateLog> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
