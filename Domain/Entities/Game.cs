using Domain.Entities.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Game: BaseEntity
    {
        public Guid homeTeamId { get; set; }
        public Guid awayTeamId { get; set; }
        public Guid WeekId { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }


        public Week Week { get; set; }
    }
}
