using System.Net;

namespace ArticlesStructureChecking.Exceptions
{
    public class BadRequestException : ZammeExceptionBase
    {
        public BadRequestException(string error) : base(error)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
