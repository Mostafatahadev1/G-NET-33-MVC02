using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class MemberShip : BaseEntity
    {
        public DateTime  StartDate { get; set; }    

        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        public int PlanId { get; set; }

        public Plan Plan { get; set; } = null;

    }
}
