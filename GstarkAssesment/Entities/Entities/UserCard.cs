using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserCard
    {
        public int IDUserCard { get; set; }
        public long CardNumber { get; set; }
        public decimal Balance { get; set; }
        public bool Blocked { get; set; }
        public int LoginAttempts { get; set; }
    }
}