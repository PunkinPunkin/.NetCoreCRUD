using System.Runtime.Serialization;

namespace Shared
{
    /// <summary>
    /// 語言型態
    /// </summary>
    /// <remarks>
    ///     參考 : https://msdn.microsoft.com/zh-tw/library/system.globalization.cultureinfo(v=vs.90).aspx
    /// </remarks>
    [DataContract]
    public enum LangType
    {
        /// <summary>
        /// 英文
        /// </summary>
        [EnumMember]
        en = 0x0009,
        /// <summary>
        /// 中文 (簡體)
        /// </summary>
        [EnumMember]
        zh_Hans = 0x0004,
        /// <summary>
        /// 中文 (繁體)
        /// </summary>
        [EnumMember]
        zh_Hant = 0x7C04,
    }
}
