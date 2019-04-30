using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlzEx.Standard;

namespace BattleSim.Model
{
    public class Ship
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public float Health { get; set; }
        public float Shield { get; set; }
        public float Damage { get; set; }
        public float Size { get; set; }
        public float Aim { get; set; }
        public float Dodge { get; set; }
        public float Rocket { get; set; }
        public int Amount { get; set; }

        private float damageTaken;

        public float DamageTaken
        {
            get { return damageTaken; }
            set
            {
                damageTaken = value;
                if (damageTaken >= Health && Amount > 0)
                {
                    int losses = (int) Math.Round(damageTaken / Health);
                    Amount = Math.Max(Amount - losses, 0);
                    damageTaken -= Health * losses;
                }
            }
        }

        public Ship(int id)
        {
            Id = id;
            Amount = 0;
            Name = ShipValues.Names[id];
            Health = ShipValues.BaseHP[id];
            Damage = ShipValues.BaseDamage[id];
            Shield = ShipValues.BaseShield[id];
            Rocket = ShipValues.BaseRocket[id];
            Aim = ShipValues.BaseAim[id];
            Dodge = ShipValues.BaseDodge[id];
            Size = ShipValues.BaseSize[id];
        }

        public bool IsAlive()
        {
            return Amount >= 0;
        }

        public float PercentageSize(float totalSize)
        {
            return Size * Amount / totalSize;
        }

        public void ApplyTech(IList<Technology> techs)
        {
            float hpIncrease = 1;
            float shieldIncrease = 1;
            float damageIncrease = 1;
            float rocketIncrease = 1;
            float sizeIncrease = 1;
            float aimIncrease = 1;
            float dodgeIncrease = 1;
            foreach (var tech in techs)
            {
                if (Id == 10 && tech.Id == 26)
                {
                    Health += 30 * tech.Level;
                    Damage += tech.Level;
                    Size += (float) Math.Floor((double)tech.Level / 15);
                }
                else if (ShipValues.ShipsAffected[Id].Contains(tech.Id))
                {
                    foreach (var techAffectingStat in tech.AffectingStats)
                    {
                        switch (techAffectingStat)
                        {
                            case TechnologyValues.ShipStat.HP:
                                hpIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Shield:
                                shieldIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Damage:
                                damageIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Rocket:
                                rocketIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Size:
                                sizeIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Aim:
                                aimIncrease += tech.Increase();
                                break;
                            case TechnologyValues.ShipStat.Dodge:
                                dodgeIncrease += tech.Increase();
                                break;
                        }
                    }
                }
            }

            Health *= hpIncrease;
            Shield *= shieldIncrease;
            Damage *= damageIncrease;
            Rocket *= rocketIncrease;
            Size *= sizeIncrease;
            Aim *= aimIncrease;
            Dodge *= dodgeIncrease;
        }
    }
}