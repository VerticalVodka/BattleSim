using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim.Model
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public float BaseValue { get; set; }

        public TechnologyValues.ShipStat[] AffectingStats { get; set; }

        public Technology(int id)
        {
            Id = id;
            Name = TechnologyValues.Name[id];
            Level = 0;
            AffectingStats = TechnologyValues.AffectingStats[id];
            BaseValue = TechnologyValues.Increase(id);
        }

        public float Increase()
        {
            return (float) Math.Pow(1 + BaseValue, Level) - 1;
        }
    }
}
