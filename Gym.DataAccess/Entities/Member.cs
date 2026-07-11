using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Entities
{
    public class Member : User
    {
        public string? Phone {  get; set; }

        public DateTime JoinDate { get; set; }

        // Health Record 

        // ICollection<Bookings>

        //ICollection<MemberShips>
    }
}
