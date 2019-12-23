using System;
using System.Runtime.Serialization;

namespace Shared
{
    /// <summary>
    /// 請求參數資料傳輸物件
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReqCode
    {
        /// <summary>
        /// 請求流水號(由系統自動抓取)
        /// </summary>
        [DataMember]
        public int Seq { get; set; }

        /// <summary>
        /// 相關請求流水號(由系統自動抓取)
        /// </summary>
        [DataMember]
        public int? PreSeq { get; set; }

        /// <summary>
        /// 服務方法的名稱(由系統自動抓取)
        /// </summary>
        [DataMember]
        public string FunName { get; set; }

        /// <summary>
        /// 應用系統名稱
        /// </summary>
        [DataMember]
        public string AppName { get; set; }

        /// <summary>
        /// 應用系統版本
        /// </summary>
        [DataMember]
        public string AppVersion { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [DataMember]
        public string UserID { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        [DataMember]
        public string UserPwd { get; set; }
    }
}
