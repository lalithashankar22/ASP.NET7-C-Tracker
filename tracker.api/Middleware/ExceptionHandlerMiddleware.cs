using System.Net;

namespace tracker.api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> log;

        public RequestDelegate ReqstDeligate { get; }

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> log , RequestDelegate ReqstDeligate)
        {
           this.log = log;
            this.ReqstDeligate = ReqstDeligate;
        }

        public async Task InvokeAsync(HttpContext httpContex)
        {
            try
            {
                await ReqstDeligate(httpContex);
            }
            catch (Exception ex)
            {
                var errorID = Guid.NewGuid();
                //log exception
                log.LogError(ex,$"{errorID} : {ex.Message}");

                // return a custom error response 
                var error = new
                {
                    ID = errorID,
                    errorMessage ="Invalid call"
                };

                httpContex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContex.Response.ContentType = "application/json";  
               await  httpContex.Response.WriteAsJsonAsync(error);
            }

        }
    }
}
