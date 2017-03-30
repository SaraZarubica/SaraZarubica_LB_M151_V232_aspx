using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaraZarubica_LB_M151_V232.Models
{
    public class VmHighScoreGvItem
    {
        public int Id { get; set; }
        public int Rang { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int GameDuration { get; set; } // as sec
        public DateTime MomentOfGame { get; set; }

        public double WeightedPoints { get; set; }
    }
}