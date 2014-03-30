using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCServer.Models
{
    public abstract class PersistentEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int ID { get; set; }
        public void Update()
        {
            this.Updated = DateTime.Now;
        }
    }
}
