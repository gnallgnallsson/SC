using SCServer.Models;

namespace SCServer.Services
{
    /// <summary>
    /// Class that are returned when a participant is registrated in the system
    /// </summary>
    public class ParticipantRegistrationResult
    {
        public Participant Participant { get; set; }
        public string Message { get; set; }
        public bool Succeful { get; set; }
    }

    public class ParticipantRepository
    {
        /// <summary>
        /// Validate if a participant is valid and can be inserted in the system
        /// </summary>
        /// <param name="participant">The participant to be checked, will have its IsValid property updated</param>
        /// <returns>The participant</returns>
        protected virtual Participant ValidateParticipant(Participant participant)
        {
            participant.IsValid = !(string.IsNullOrEmpty(participant.FirstName) || string.IsNullOrEmpty(participant.LastName));
            return participant;
        }

        /// <summary>
        /// Creates a participant
        /// </summary>
        /// <param name="firstName">First name of the participant</param>
        /// <param name="lastName">Last name of the participant</param>
        /// <returns>A participant if the participant is valid, null otherwise</returns>
        protected virtual Participant ValidateAndUpdateParticipantLog(Participant participant)
        {
            participant = this.ValidateParticipant(participant);
            if (participant.IsValid)
            {
                participant.Status = ParticipantStatus.Enabled;
                participant.Logs.Add(new ParticipantActivityLog() { Header = "AddParticipant", Body = string.Format("Participant with name {0} {1} is added", participant.FirstName, participant.LastName) });
            }
            else
            {
                participant.Status = ParticipantStatus.Disabled;
            }
            return participant;
        }
        /// <summary>
        /// Insert a new participant, inteface to the user
        /// </summary>
        /// <param name="participant">The participant that should be inserted into the system</param>        
        /// <returns>A result containing: the participant, if it was succes and a message to the user</returns>
        public ParticipantRegistrationResult InsertParticipant(Participant participant)
        {
            participant = this.ValidateAndUpdateParticipantLog(participant);
            ParticipantRegistrationResult result = new ParticipantRegistrationResult();
            result.Participant = participant;
            result.Message = participant.IsValid ? Properties.Resources.SuccedToAddParticipantResultMessage : Properties.Resources.FailedToAddParticipantResultMessage;
            result.Succeful = participant.IsValid;

            return result;
        }
    }
}
