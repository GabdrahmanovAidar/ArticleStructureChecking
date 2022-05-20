using System.Net;

namespace ArticlesStructureChecking.Exceptions
{
    public sealed class NotFoundException : ZammeExceptionBase
    {
        public NotFoundException(string error) : base(error)
        {
        }
        public NotFoundException(string method, string responseText) : base(method, responseText)
        {
        }
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
