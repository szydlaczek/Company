namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public interface IResult
    {
        bool Succeeded { get; set; }
        object Data { get; set; }
        string Message { get; set; }
    }
}