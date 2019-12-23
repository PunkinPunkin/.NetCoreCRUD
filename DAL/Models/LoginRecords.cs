using System;

namespace DAL.Models
{
    public partial class LoginRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? Result { get; set; }
        public string System { get; set; }
        public string Comment { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDate { get; set; } = DateTime.Now;

        public virtual ApUser User { get; set; }
    }
}
