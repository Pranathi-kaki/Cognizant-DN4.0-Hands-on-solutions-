using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 1. Get the exception
            var exception = context.Exception;

            // 2. Write it to a log file (you can change path if needed)
            File.AppendAllText("exception_log.txt",
                $"[{DateTime.Now}] Exception: {exception.Message}{Environment.NewLine}");

            // 3. Set the result as Internal Server Error
            context.Result = new ObjectResult("Something went wrong!")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
