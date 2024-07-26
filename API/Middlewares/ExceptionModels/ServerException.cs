namespace API.Middlewares.Exceptions
{
    public class ServerException : Exception
    {
        public string Code;
        public string Message;

        public ServerException(string errorCode, string message)
        {
            Code = errorCode;
            Message = message;
        }

        public static void Throw(string errorCode, string message)
        {
            throw new ServerException(errorCode, message);
        }
    }
}
