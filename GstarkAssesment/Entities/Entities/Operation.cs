using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Operation
    {
        public int IDOperation { get; set; }
        public int IDOperationCode { get; set; }
        public int IDCard { get; set; }
        public decimal? Amount { get; set; }

        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}
