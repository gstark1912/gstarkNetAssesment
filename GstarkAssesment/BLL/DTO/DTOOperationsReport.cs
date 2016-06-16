using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DTOOperationsReport
    {
        public List<Operation> results { get; set; }
        public UserCard UserCard { get; set; }
    }
}
