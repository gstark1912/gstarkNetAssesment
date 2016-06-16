using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DTOLoginResult
    {
        public bool Sucess { get; set; }
        public long CardNumber { get; set; }
        public bool Blocked { get; set; }
        public string Message { get; set; }
    }
}
