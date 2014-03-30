using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Xunit;
using SCServer.Services;
using SCServer.Models;

namespace Specs.Configuration
{  
    [Trait("Participant", "Valid Participant Configuration Received")]
    public class Participant_ValidConfigurationReceived
    {
        private ParticipantRepository _registrator;
        private ParticipantRegistrationResult _result;
        public Participant_ValidConfigurationReceived()
        {
            _registrator = new ParticipantRepository();
            _result = _registrator.InsertParticipant(new Participant("kalle", "anka"));
        }

        
        [Fact(DisplayName = "Validate the Participant")]
        public void ValidateParticipant()
        {
            Assert.True(this._result.Participant.IsValid);            
        }

        [Fact(DisplayName="A participant is added to the system")]
        public void ValidParticipantIsAddedToSystem()
        {            
            Assert.Equal(true, _result.Succeful);            
            Assert.NotNull(this._result.Participant.Created);
            
        }        
       
        [Fact(DisplayName = "A participant is enabled in the system")]
        public void ParticipantIsEnabledInTheSystem()
        {
            Assert.Equal(ParticipantStatus.Enabled, this._result.Participant.Status);
        }
        [Fact(DisplayName= "Log entry created when adding a participant")]
        public void AddLoggEntryWhenParticipantIsAdded()
        {
            Assert.Equal(1, this._result.Participant.Logs.Count);
        }
        [Fact(DisplayName="A confirmation message is shown to the user")]
        public void MessageIsProvidedForTheUser()
        {
            Assert.NotNull(_result.Message);
            Assert.Equal("Success", _result.Message);
        }
    }
}
