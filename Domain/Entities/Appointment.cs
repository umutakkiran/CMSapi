using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public string AppointmentType { get; set; }
        public DateTime Date { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
        public string title { get; set; }
        public Boolean? draggable { get; set; }
    }
}
