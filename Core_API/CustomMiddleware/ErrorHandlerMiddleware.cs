namespace Core_API.CustomMiddleware
{
    /// <summary>
    /// Class that contains logic for Handling Errors
    /// 1. This class MUST be Constructor Injected using the RequestDelegate
    /// 2. Thetre MUST be an InvokeAsync() method which will contain the logic 
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ErrorHandlerMiddleware(RequestDelegate request)
        {
            _requestDelegate = request;
        }

        /// <summary>
        /// Since this is used for Exception Handling
        /// use try..catch... block
        /// If the error to be logged into database or into file or want to send Email to 
        /// App Adming then this method can accept other parameters
        /// e.g. InvokeAsync(HttpContext context, DbContext ctx, EmailService emailServ, SMSService sms)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // If no exception the continue with next middleware in the HTTP Pipeline
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                // Handler Error and Return response
                //1. Set the Response Status code
                context.Response.StatusCode = 500;
                 
                // 2. Read the Error Message
                var errorMessage = ex.Message;
                // 3. Well Organize the Error Details
                var errorInfo = new { StatusCode = context.Response.StatusCode, ErrorMessage= errorMessage };
                // 4. Write the Response
                await context.Response.WriteAsJsonAsync(errorInfo);
            }
        }
    }


    /// <summary>
    /// An Extension class that contains an extension method to Register the Muddlware into the pipeline
    /// </summary>

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        { 
            builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
