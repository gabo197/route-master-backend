namespace RouteMaster.API.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; set; } = null!;
        public T Resource { get; set; } = default!;

        public BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
