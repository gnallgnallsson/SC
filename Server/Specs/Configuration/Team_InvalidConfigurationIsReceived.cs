using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Specs.Configuration
{
    [Trait("Team", "Invalid Team configuration is received")]
    public class Team_InvalidConfigurationIsReceived
    {
        [Fact(DisplayName = "Team Configuration is denied")]
        public void TeamIsDenied()
        {
            throw new NotImplementedException("implement me");
        }

        [Fact(DisplayName = "Show message why the team configuration is denied")]
        public void ShowDeniedMessage()
        {
            throw new NotImplementedException("Implement me");
        }
    }
}
