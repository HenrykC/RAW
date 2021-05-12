namespace ShowCase.Exceptions.Handler
{
    public interface IError
    {
        int Code { get; set; }
        string Message { get; set; }
    }
}