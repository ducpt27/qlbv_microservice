using System;

namespace VeXe.Dto.Response
{
    public class BaseResp
    {
        public int Code { get; set; }
        
        public string Message { get; set; }
        public Object Data { get; set; }

        public BaseResp()
        {

        }

        public BaseResp(int code, String message)
        {
            this.Code = code;
            this.Message = message;
        }

        public BaseResp(int code, String message, Object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public BaseResp(Object data)
        {
            this.Code = 0;
            this.Message = "";
            this.Data = data;
        }
    }
}