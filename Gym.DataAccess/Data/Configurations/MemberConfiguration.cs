using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Data.Configurations
{
    public class MemberConfiguration : 
        UserConfiguration<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder) 
        {
               base.Configure(builder);

            // Configuration related TO "Member "

            builder.Property(p => p.Phone)
                .HasMaxLength(1000);
        }
    }
}
