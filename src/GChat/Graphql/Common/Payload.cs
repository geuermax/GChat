using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Common
{
    public class Payload
    {
        public IReadOnlyList<UserError>? Errors { get; }


        public Payload(IReadOnlyList<UserError>? errors = null)
        {
            this.Errors = errors;
        }
    }
}
