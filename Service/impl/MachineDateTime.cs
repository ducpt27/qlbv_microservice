using System;
using AspNetCoreSpa.Common;

namespace VeXe.Service.impl
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
