using System.Runtime.Serialization;
namespace Shared
{
    /// <summary>
    /// 基本請求參數
    /// </summary>
    [DataContract]
    public class BaseReqInParm
    {
        /// <summary>
        /// Request Code
        /// </summary>
        [DataMember]
        public ReqCode ReqCode { get; set; }

        /// <summary>
        /// 套用至方法時，指定在物件還原序列化 (Deserialization) 後立即呼叫該方法。
        /// </summary>
        /// <param name="c">描述指定之序列化資料流的來源和目的端，並提供額外的呼叫端定義內容。</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext c)
        {
            ReqCode = (ReqCode == null ? new ReqCode() : ReqCode);
        }
    }
}
