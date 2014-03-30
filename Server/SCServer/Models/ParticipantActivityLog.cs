using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCServer.Models
{
    public class ParticipantActivityLog : PersistentEntity
    {
        private string _header;
        private string _body;
        public ParticipantActivityLog()
        {
            this.Created = DateTime.Now;
            this._header = string.Empty;
            this._body = string.Empty;
        }
        public int ParticipantID { get; set; }        
        public string Header
        {
            get
            {
                return this._header;
            }
            set
            {
                this._header = value;
                this.Update();
            }
        }
        public string Body { get; set; }
    }
}
