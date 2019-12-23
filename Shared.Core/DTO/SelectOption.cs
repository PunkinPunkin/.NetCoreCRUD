using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared.DTO
{
    [DataContract]
    public class SelectOption
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}
