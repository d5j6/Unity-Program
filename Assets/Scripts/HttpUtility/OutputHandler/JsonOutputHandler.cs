using Newtonsoft.Json;

namespace HttpUtility
{
    public class JsonOutputHandler<TResult> : IOutputHandler<TResult>
    {
        public TResult ConvertOutput(string responseText)
        {
            if (typeof(TResult) == typeof(string))
            {
                object o = responseText;
                return (TResult)o;
            }
            return JsonConvert.DeserializeObject<TResult>(responseText);
        }
    }

}
