using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;

namespace GChat
{
    [ExtendObjectType(Name = "Query")]
    [Authorize]
    public class TestQuery
    {
        public string GetTest() => "test";
    }
}
