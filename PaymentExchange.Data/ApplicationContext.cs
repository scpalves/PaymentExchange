using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentExchange.Data
{
    public partial class ApplicationContext
    {
        public string Username { get; set; }
        public string SystemId { get; set; }

        public const string SYSTEM_USER_NAME = "Sistema";

        public string UserDomainName
        {
            get
            {
                var splitter = this.Username.Split(new char[] { '\\' });

                if (splitter.Length > 1)
                    return splitter[1];

                return this.Username;
            }
        }

        public ApplicationContext(string systemId)
        {
            this.Username = ApplicationContext.SYSTEM_USER_NAME;
            this.SystemId = systemId;
        }

        public ApplicationContext(string username, string systemId)
        {
            this.Username = username;
            this.SystemId = systemId;
        }
    }
}

