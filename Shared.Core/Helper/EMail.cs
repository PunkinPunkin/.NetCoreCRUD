using System.Net.Mail;
using System.Text;

namespace Shared.Helper
{
    public class EMail
    {
        #region 欄位
        private MailMessage _mail;
        private const string _from = "Project@wisedata.com.tw";
        private const string _host = "10.168.188.3";
        private const int _port = 25;
        private const string _userName = "Project";
        private const string _password = "ProJ5505990";
        private const string _domain = "";
        private const string _admin = "bang@wiseinfo.com.tw";
        #endregion

        #region 建構
        public EMail()
        {
            _mail = new MailMessage();
            _mail.From = new MailAddress(_from);
            _mail.IsBodyHtml = true;
        }

        public EMail(string subject)
        {
            _mail = new MailMessage();
            _mail.From = new MailAddress(_from);
            _mail.IsBodyHtml = true;
            _mail.Subject = subject;
        }

        public EMail(string to, string subject)
        {
            _mail = new MailMessage(_from, to);
            _mail.IsBodyHtml = true;
            _mail.Subject = subject;            
        }

        public EMail(string to, string subject, string body)
        {
            _mail = new MailMessage(_from, to, subject, body);
            _mail.IsBodyHtml = true;
        }
        #endregion

        #region 屬性
        public MailAddressCollection To { get { return _mail.To; } }
        public MailAddressCollection Bcc { get { return _mail.Bcc; } }
        public MailAddressCollection CC { get { return _mail.CC; } }
        public string Admin { get { return _admin; } }        

        public bool IsBodyHtml
        {
            get { return _mail.IsBodyHtml; }
            set { _mail.IsBodyHtml = value; }
        }

        public MailPriority Priority
        {
            get { return _mail.Priority; }
            set { _mail.Priority = value; }
        }

        public string Subject
        {
            get { return _mail.Subject; }
            set { _mail.Subject = value; }
        }

        public string Body {
            get { return _mail.Body; }
            set { _mail.Body = value; }
        }

        public AttachmentCollection Attachments
        {
            get { return _mail.Attachments; }
        }

        public Encoding BodyEncoding
        {
            get { return _mail.BodyEncoding; }
            set { _mail.BodyEncoding = value; }
        }
        #endregion

        #region 方法
        public void Write(string msg)
        {
            this.Body += msg;
        }

        public void WriteLine(string msg)
        {
            if (this.IsBodyHtml)
            {
                this.Body += string.Format("{0}</br>", msg);
            }
            else
            {
                this.Body += string.Format("{0}\n\r", msg);
            }
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient(_host, _port);            
            smtp.Credentials = new System.Net.NetworkCredential(_userName, _password);
            smtp.Send(_mail);
        }
        #endregion
    }
}
