using System;

namespace VeXe.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"{name} không tìm thấy: {key}")
        {
        }
    }
}