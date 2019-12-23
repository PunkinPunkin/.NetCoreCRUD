using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Shared
{
    /// <summary>
    /// 回傳訊息
    /// </summary>
    [Serializable]
    [DataContract]
    public class RetCode
    {
        /// <summary>
        /// 呼叫的 Webservice 目前的環境
        /// </summary>
        [DataMember]
        public int TableTotalRow { get; set; }

        /// <summary>
        /// 呼叫的 Webservice 目前的環境
        /// </summary>
        [DataMember]
        public string Environment { get; set; }

        /// <summary>
        /// 服務方法的編號(由系統自動抓取)
        /// </summary>
        [DataMember]
        public int? FunId { get; set; }

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
        /// 呼叫的 Webservice 方法名稱(由系統自動抓取)。
        /// </summary>
        [DataMember]
        public string FunName { get; set; }

        [DataMember]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 針對 Return Code 的回傳訊息。
        /// </summary>
        [DataMember]
        public string MessageText { get; set; }

        private List<Message> _msgSequence;
        /// <summary>
        /// 額外回傳訊息集合，用於補充回傳訊息的不足。
        /// </summary>
        [DataMember]
        public List<Message> MsgSequence
        {
            get
            {
                if (_msgSequence == null)
                    _msgSequence = new List<Message>();

                return _msgSequence;
            }
            set
            {
                _msgSequence = value;
            }
        }

        public bool IsOK
        {
            get
            {
                if (int.TryParse(ReturnCode, out int retCode))
                    return retCode == (int)CommonCode.OK ? true : false;
                else
                    return false;
            }
        }

        public bool IsNoData
        {
            get
            {
                if (int.TryParse(ReturnCode, out int retCode))
                    return retCode == (int)CommonCode.NoData ? true : false;
                else
                    return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", this.ReturnCode, this.MessageText);
        }
    }
}
