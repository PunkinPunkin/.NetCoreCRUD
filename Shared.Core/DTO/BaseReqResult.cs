using System.Runtime.Serialization;
namespace Shared
{
    /// <summary>
    /// 基本回傳物件
    /// </summary>
    [DataContract]
    public class BaseReqResult
    {
        /// <summary>
        /// Return Code 物件
        /// </summary>
        [DataMember]
        public RetCode RetCode { get; set; }
    }
}
