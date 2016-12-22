namespace OfficeBoard.Services
{
    using Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            this.OfficeBoardContext = new OfficeBoardContext();
        }

        public OfficeBoardContext OfficeBoardContext { get; set; }
    }
}