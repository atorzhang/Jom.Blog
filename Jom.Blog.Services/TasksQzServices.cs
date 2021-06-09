using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.Services
{
    public partial class TasksQzServices : BaseServices<TasksQz>, ITasksQzServices
    {
        IBaseRepository<TasksQz> _dal;
        public TasksQzServices(IBaseRepository<TasksQz> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
                    