using System.Runtime.Serialization;

namespace Shared
{
    /// <summary>
    /// 常使用的Reason Code
    /// </summary>
    [DataContract]
    public enum CommonCode
    {
        /// <summary>
        /// 請求成功
        /// </summary>
        [EnumMember]
        OK = 0,
        /// <summary>
        /// 帳號不存在
        /// </summary>
        [EnumMember]
        AccountNotExist = 1,
        /// <summary>
        /// 密碼不正確
        /// </summary>
        [EnumMember]
        PasswordError = 2,
        /// <summary>
        /// 沒有 {0} 權限
        /// </summary>
        [EnumMember]
        NoAuthority = 3,
        /// <summary>
        /// {0} 不可為空
        /// </summary>
        [EnumMember]
        Empty = 4,
        /// <summary>
        /// 查詢不到 {0} 資料
        /// </summary>
        [EnumMember]
        NoData = 5,
        /// <summary>
        /// 新增 {0} 資料失敗
        /// </summary>
        [EnumMember]
        InsertDataFail = 6,
        /// <summary>
        /// 修改 {0} 資料失敗
        /// </summary>
        [EnumMember]
        UpdateDataFail = 7,
        /// <summary>
        /// 刪除 {0} 資料失敗
        /// </summary>
        [EnumMember]
        DeleteDataFail = 8,
        /// <summary>
        /// {0} 資料未維護完全
        /// </summary>
        [EnumMember]
        DataLoss = 9,
        /// <summary>
        /// 檢查錯誤
        /// </summary>
        [EnumMember]
        CheckError = 10,
        /// <summary>
        /// 沒有要變更資料
        /// </summary>
        [EnumMember]
        NotChangeData = 11,
        /// <summary>
        /// {0} 必須為空
        /// </summary>
        [EnumMember]
        NeedEmpty = 12,
        /// <summary>
        /// {0} 為不支援動作
        /// </summary>
        [EnumMember]
        NotSupport = 13,
        /// <summary>
        /// {0} 序號被鎖定
        /// </summary>
        [EnumMember]
        SNHold = 14,
        /// <summary>
        /// 傳入參數錯誤
        /// </summary>
        [EnumMember]
        ParameterError = 15,
        /// <summary>
        /// 檔案不存在 {0}
        /// </summary>
        [EnumMember]
        FileNotExist = 16,
        /// <summary>
        /// 應用程式已更版，請重新啓動。
        /// </summary>
        [EnumMember]
        AppVersionUpdate = 17,
        /// <summary>
        /// {0} 資料庫程序 {1} 執行錯誤。
        /// </summary>
        [EnumMember]
        RunProcedureError = 18,
        /// <summary>
        /// 伺服機內容錯誤 : {0}
        /// </summary>
        [EnumMember]
        Fail = 99999,
    }
}
