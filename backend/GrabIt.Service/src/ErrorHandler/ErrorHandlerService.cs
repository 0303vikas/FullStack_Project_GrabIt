namespace GrabIt.Service.ErrorHandler
{
    public class ErrorHandlerService : Exception
    {
        private string _message = string.Empty;
        private int _code;

        public ErrorHandlerService(string message, int code)
        {
            _message = message;
            _code = code;
        }

        public static ErrorHandlerService ExceptionBadRequest(string message)
        {
            return new ErrorHandlerService($"Bad Request: {message}", 400);
        }

        public static ErrorHandlerService ExceptionNotFound(string message)
        {
            return new ErrorHandlerService($"Not Found: {message}.", 404);
        }

        public static ErrorHandlerService ExceptionUnauthorized(string message)
        {
            return new ErrorHandlerService($"Unauthorized: {message}.", 401);
        }

        public static ErrorHandlerService ExceptionInternalServerError(string message)
        {
            return new ErrorHandlerService($"Internal Server Error: {message}.", 500);
        }

        public static ErrorHandlerService ExceptionArgumentNull(string message)
        {
            return new ErrorHandlerService($"Argument Null: {message}.", 400);
        }

        public static ErrorHandlerService ExceptionDuplicateData(string message)
        {
            return new ErrorHandlerService($"Duplicate data found: {message}.", 409);
        }
    }
}