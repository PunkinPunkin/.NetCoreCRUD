using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class ApUser
    {
        public ApUser()
        {
            LoginRecords = new HashSet<LoginRecord>();
        }

        public int Id { get; set; }
        public string Account { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual string FullName
        {
            get { return LastName + FirstName; }
        }

        public virtual ICollection<LoginRecord> LoginRecords { get; set; }
    }
}
