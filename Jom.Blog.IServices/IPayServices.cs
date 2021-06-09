﻿
using Jom.Blog.IServices.BASE;
using Jom.Blog.Model;
using Jom.Blog.Model.ViewModels;
using System.Threading.Tasks;

namespace Jom.Blog.IServices
{
    /// <summary>
    /// IPayServices
    /// </summary>	
    public interface IPayServices : IBaseServices<RootEntityTkey<int>>
    {
        /// <summary>
        /// 被扫支付
        /// </summary>
        /// <returns></returns>
        Task<MessageModel<PayReturnResultModel>> Pay(PayNeedModel payModel);
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="payModel"></param>
        /// <returns></returns>
        Task<MessageModel<PayRefundReturnResultModel>> PayRefund(PayRefundNeedModel payModel);
        /// <summary>
        /// 轮询查询
        /// </summary>
        /// <param name="payModel"></param>
        /// <param name="times">轮询次数</param>
        /// <returns></returns>
        Task<MessageModel<PayReturnResultModel>> PayCheck(PayNeedModel payModel,int times);
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="strSrc">参数</param>
        /// <param name="sign">签名</param>
        /// <param name="pubKey">公钥</param>
        /// <returns></returns>
        bool NotifyCheck(string strSrc, string sign, string pubKey);

    }
}
