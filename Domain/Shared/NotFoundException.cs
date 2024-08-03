namespace API.Middlewares.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Code;
        public string Message;

        private NotFoundException(string errorCode, string message)
        {
            Code = errorCode;
            Message = message;
        }

        public static void Throw(string errorCode, string message)
        {
            throw new NotFoundException(errorCode, message);
        }
    }
}
