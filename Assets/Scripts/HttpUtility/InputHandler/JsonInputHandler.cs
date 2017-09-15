using Newtonsoft.Json;
using System.Text;
using UnityEngine;

namespace HttpUtility
{
    public class JsonInputHandler : IInputHandler
    {
        public byte[] HandleInputToRawData(object[] parameters)
        {
            var json = JsonConvert.SerializeObject(parameters, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Debug.Log(json);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
