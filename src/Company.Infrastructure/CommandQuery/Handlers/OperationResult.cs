namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public class OperationResult : IResult
    {
        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}