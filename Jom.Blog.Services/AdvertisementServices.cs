﻿using Jom.Blog.IRepository.Base;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Jom.Blog.Services.BASE;

namespace Jom.Blog.Services
{
    public class AdvertisementServices : BaseServices<Advertisement>, IAdvertisementServices
    {
        IBaseRepository<Advertisement> _dal;
        public AdvertisementServices(IBaseRepository<Advertisement> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        public void ReturnExp()
        {

            int a = 1;
            int b = 0;

            int c = a / b;
        }

        //public IAdvertisementRepository dal = new AdvertisementRepository();
        //public int Sum(int i, int j)
        //{
        //    return base.Sum(i, j);

        //}


        //public int Add(Advertisement model)
        //{
        //    return base.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    return base.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return base.Query(whereExpression);

        //}

        //public bool Update(Advertisement model)
        //{
        //    return base.Update(model);
        //}

    }
}
