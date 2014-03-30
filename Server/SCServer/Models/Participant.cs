using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SCServer.Models
{
    public enum ParticipantStatus
    {
        Disabled,
        Enabled
    }
    public class Participant : PersistentEntity
    {
        private ParticipantStatus _status;
        private Image _image;
        private string _firstName;
        private string _lastName;
       
        public Participant(string firstName, string lastName)
        {
            this._status = ParticipantStatus.Disabled;            
            this._firstName = firstName;
            this._lastName = lastName;
            this.Logs = new List<ParticipantActivityLog>();
            this.Created = DateTime.Now;
            this.IsValid = false;            
        }
        
        public ParticipantStatus Status
        {
            get { return this._status; }
            set
            {
                this._status = value;
                this.Update();
            }
        }

        public bool IsValid { get; set; }        
        public Image Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
                this.Update();
            }
        }
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this._firstName = value;
                this.Update();
            }
        }
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this._lastName = value;
                this.Update();
            }
        }
        public List<ParticipantActivityLog> Logs { get; set; }
    }
}
