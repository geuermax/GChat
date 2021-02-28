using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Common
{
    public class UserError
    {
        public string Message { get; }
        public string Code { get; }

        public UserError(string message, string code)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
