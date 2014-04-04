using SCServer.Models;
using SCServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Specs.Configuration
{
    [Trait("Participant", "Invalid Participant Configuration Received")]
    public class Participant_InvalidConfigurationRecieved
    {
        ParticipantRegistrationResult _resultFirstNameIsMissing;
        ParticipantRegistrationResult _resultLastNameIsMissing;
        public Participant_InvalidConfigurationRecieved()
        {
            this._resultFirstNameIsMissing = new ParticipantRepository().InsertParticipant(new Participant("", "anka"));
            this._resultLastNameIsMissing = new ParticipantRepository().InsertParticipant(new Participant("kalle", ""));
        }
        [Fact(DisplayName = "Participant with first name empty")]
        public void ExceptionThrownWithEmptyFirstName()
        {            
            Assert.False(this._resultFirstNameIsMissing.Succeful);
        }
        [Fact(DisplayName = "Participant with last name empty")]
        public void ExceptionThrownWithEmptyLastName()
        {
            Assert.False(this._resultLastNameIsMissing.Succeful);
        }
        [Fact(DisplayName = "Show Message why the participant is not added")]
        public void ShowMessage()
        {
            Assert.Equal("Name is not submittet for the participant", this._resultLastNameIsMissing.Message);
            Assert.Equal("Name is not submittet for the participant", this._resultFirstNameIsMissing.Message);
        }
    }
}
