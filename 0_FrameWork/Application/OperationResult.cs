namespace _0_FrameWork.Application
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSucceeded = false;
        }

        public bool IsSucceeded { get; set; }
        public string Message { get; set; }

        public OperationResult Succeeded(string message = "عملیات با موفق انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }

    public class OperationResult<T>
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
        public T Data { get; set; }

        public OperationResult<T> Succeeded(T date, string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            Data = date;
            return this;
        }

        public OperationResult<T> Failed(string message,T data=default)
        {
            IsSucceeded = false;
            Message = message;
            Data = data;
            return this;
        }
    }
}