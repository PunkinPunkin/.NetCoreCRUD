using System;
using System.Runtime.Serialization;
namespace Shared
{
    /// <summary>
    /// 附加訊息
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
        /// 建構元
        /// </summary>
        public Message()
        {
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// 建構元
        /// </summary>
        /// <param name="type">訊息型態</param>
        /// <param name="msg">訊息</param>
        public Message(MsgType type, string msg)
        {
            Type = type;
            MessageText = msg;
            CreateDate = DateTime.Now;
        }
       
        /// <summary>
        /// 訊息型態
        /// </summary>
        [DataMember]
        public MsgType Type { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        [DataMember]
        public string MessageText { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }
    }
}
