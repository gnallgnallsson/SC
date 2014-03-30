using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Specs.Configuration
{
    [Trait("Team Tests", "Team is receive without a name")]
    public class Team_EmptyName
    {
        [Fact(DisplayName = "Team configuration consider invalid")]
        public void TeamConfigruationInvalie()
        {
            throw new NotImplementedException("Implement me");
        }
        [Fact(DisplayName = "A message is returned")]
        public void MessageIsReturned()
        {
            throw new NotImplementedException("Implement me");
        }

    }
}
