namespace GrabIt.Service.ErrorHandler
{
    public class ErrorHandlerService : Exception
    {
        public string Message;
        public int StatusCode;

        public ErrorHandlerService(string message, int code)
        {
            Message = message;
            StatusCode = code;
        }

        public static ErrorHandlerService ExceptionBadRequest(string message = "Check request data.")
        {
            return new ErrorHandlerService($"Bad Request: {message}", 400);
        }

        public static ErrorHandlerService ExceptionNotFound(string message = "Entity was not found.")
        {
            return new ErrorHandlerService($"Not Found: {message}.", 404);
        }

        public static ErrorHandlerService ExceptionUnauthorized(string message = "User is not authorized.")
        {
            return new ErrorHandlerService($"Unauthorized: {message}.", 401);
        }

        public static ErrorHandlerService ExceptionInternalServerError(string message = "Something went wrong.")
        {
            return new ErrorHandlerService($"Internal Server Error: {message}.", 500);
        }

        public static ErrorHandlerService ExceptionArgumentNull(string message = "Argument can't be null.")
        {
            return new ErrorHandlerService($"Argument Null: {message}.", 400);
        }

        public static ErrorHandlerService ExceptionDuplicateData(string message = "Datat already exists.")
        {
            return new ErrorHandlerService($"Duplicate data found: {message}.", 409);
        }

        public static ErrorHandlerService ExceptionInvalidData(string message = "Data not valid.")
        {
            return new ErrorHandlerService($"Invalid data: {message}.", 400);
        }
    }
}