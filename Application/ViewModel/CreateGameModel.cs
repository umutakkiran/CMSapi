using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CreateGameModel
    {
        public Guid WeekId { get; set; }
        public Guid homeTeamId { get; set; }
        public Guid awayTeamId { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
