using System;
using System.Linq;
using System.Linq.Expressions;

namespace BattleSim.Model
{
    public static class TechnologyValues
    {
        private const int AMOUNT_TECHS = 27;

        public enum ShipStat
        {
            HP,
            Shield,
            Damage,
            Rocket,
            Size,
            Aim,
            Dodge
        }

        public static readonly string[] Name = new string[]
        {
            "Ship Structure",
            "Energy",
            "Weapon Systems",
            "AI",
            "Analyze",
            "Standard Alloy",
            "Energy Shield",
            "Laser Cannon",
            "Nuclear Missile",
            "Decoy Flares",
            "Nano Structure",
            "Electron Shield",
            "Electric Cannon",
            "Hologram",
            "Maneuvering Lure",
            "Plasma Structure",
            "Plasma Shield",
            "Plasma Cannon",
            "Antimatter Torpedo",
            "Post Combustion",
            "Galladium Surface",
            "Antigravic Shield",
            "Doom Ray",
            "Intrusion",
            "Quantum Gyroscope",
            "Esoteric Void",
            "PROBE SKILL"
        };

        public static readonly ShipStat[][] AffectingStats = new ShipStat[AMOUNT_TECHS][]
        {
            new ShipStat[]{ShipStat.HP},
            new ShipStat[]{ShipStat.Shield},
            new ShipStat[]{ShipStat.Damage},
            new ShipStat[]{ShipStat.Aim, ShipStat.Rocket},
            new ShipStat[]{ShipStat.Dodge},
            new ShipStat[]{ShipStat.HP},
            new ShipStat[]{ShipStat.Shield},
            new ShipStat[]{ShipStat.Damage},
            new ShipStat[]{ShipStat.Rocket},
            new ShipStat[]{ShipStat.Dodge},
            new ShipStat[]{ShipStat.HP},
            new ShipStat[]{ShipStat.Shield},
            new ShipStat[]{ShipStat.Damage},
            new ShipStat[]{ShipStat.Size},
            new ShipStat[]{ShipStat.Dodge},
            new ShipStat[]{ShipStat.HP},
            new ShipStat[]{ShipStat.Shield},
            new ShipStat[]{ShipStat.Damage},
            new ShipStat[]{ShipStat.Rocket},
            new ShipStat[]{ShipStat.Dodge},
            new ShipStat[]{ShipStat.HP},
            new ShipStat[]{ShipStat.Shield},
            new ShipStat[]{ShipStat.Damage},
            new ShipStat[]{ShipStat.Size},
            new ShipStat[]{ShipStat.Dodge},
            new ShipStat[]{ShipStat.Damage, ShipStat.HP, ShipStat.Shield},
            new ShipStat[]{},
        };

        public static float Increase(int id)
        {
            if (id == 26) return 0;
            if (id == 25) return 0.2f;
            if (id == 3) return 0.02f;
            if (AffectingStats[id].Contains(ShipStat.Dodge)) return 0.01f;
            return 0.05f;
        }
    }
}