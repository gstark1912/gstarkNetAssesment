using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Operation
    {
        public Operation()
        {
            this.Date = DateTime.Now;
        }
        public int IDOperation { get; set; }
        public int IDOperationCode { get; set; }
        public int IDCard { get; set; }
        public decimal? Amount { get; set; }

        public DateTime Date{ get; set; }

        [ForeignKey("IDCard")]
        public virtual UserCard UserCard { get; set; }

        [ForeignKey("IDOperationCode")]
        public virtual OperationCode OperationCode { get; set; }
    }
}
