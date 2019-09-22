using Newtonsoft.Json;

namespace CompanySelf.Api.Core
{
    public class ErrorResponse
    {
        public string Message
        {
            get;
            set;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}