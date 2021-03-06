namespace TimeManager.API.Data.Response
{
    public interface IResponse<T>
    {
        public T Data { get; set; }
        public ApiException Exception { get; set; }
    }
}
