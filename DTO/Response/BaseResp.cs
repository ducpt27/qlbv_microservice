using System;
using Newtonsoft.Json;

namespace VeXe.Dto.Response
{
    public class BaseResp
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Object Data { get; set; }

        public BaseResp()
        {
        }

        public BaseResp(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public BaseResp(int code, string message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public BaseResp(object data)
        {
            this.Code = 0;
            this.Message = "";
            this.Data = data;
        }
    }
}