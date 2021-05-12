using System;

namespace VeXe.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"không tìm thấy {name} : {key}")
        {
        }
    }
}