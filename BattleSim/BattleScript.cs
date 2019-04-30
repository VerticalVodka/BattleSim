using System;
using System.Collections.Generic;
using System.Linq;
using BattleSim.Model;

namespace BattleSim
{
    public static class BattleScript
    {
        public static string Run(IList<Ship> atkShips, IList<Ship> defShips,
            IList<Technology> atkTech, IList<Technology> defTech)
        {
            string output = "Fighting report\n\n";

            int turnNumber = 0;

            foreach (var atkShip in atkShips)
            {
                atkShip.ApplyTech(atkTech);
            }

            foreach (var defShip in defShips)
            {
                defShip.ApplyTech(defTech);
            }

            /***** INIT FIXED VALUES (Don"t change during fight) *****/
            var rocketTotalDef = defShips.Select(ship => ship.Rocket * ship.Amount).Sum();
            var rocketTotalAtk = atkShips.Select(ship => ship.Rocket * ship.Amount).Sum();

            for (int i = 0; i < 15; i++)
            {
                output += atkShips[i].Name + ": "+atkShips[i].Amount + " vs "+ defShips[i].Amount + "\n";

            }

            /****** ROCKET COMBAT **********/
            var sizeTotalDef = defShips.Select(ship=>ship.Size*ship.Amount).Sum();
            var sizeTotalAtk = atkShips.Select(ship => ship.Size*ship.Amount).Sum();

            output += "\nRocket Round\n";

            for (var i = 0; i < atkShips.Count; i++)
            {
                atkShips[i].DamageTaken += rocketTotalDef * atkShips[i].PercentageSize(sizeTotalAtk);
                defShips[i].DamageTaken += rocketTotalAtk * defShips[i].PercentageSize(sizeTotalDef);
            }
            for (int i = 0; i < 15; i++)
            {
                output += atkShips[i].Name + ": " + atkShips[i].Amount + " vs " + defShips[i].Amount + "\n";
            }

            while (turnNumber < 15)
            {
                /****** DEBUT COMBAT **********/
                var damageTotalDef = defShips.Select(ship => ship.Damage * ship.Amount).Sum();
                var precisionTotalDef = defShips.Select(ship => ship.Aim * ship.Amount).Sum();
                sizeTotalDef = defShips.Select(ship => ship.Size * ship.Amount).Sum();
                var shipCountTotalDef = defShips.Select(ship => ship.Amount).Sum();

                var damageTotalAtk = atkShips.Select(ship => ship.Damage * ship.Amount).Sum();
                var precisionTotalAtk = atkShips.Select(ship => ship.Aim * ship.Amount).Sum();
                sizeTotalAtk = atkShips.Select(ship => ship.Size * ship.Amount).Sum();
                var shipCountTotalAtk = atkShips.Select(ship => ship.Amount).Sum();

                if (shipCountTotalAtk < 0) shipCountTotalAtk = 0;
                if (shipCountTotalDef < 0) shipCountTotalDef = 0;

                if (shipCountTotalAtk <= 0 || shipCountTotalDef <= 0)
                {
                    break;
                }
                else
                {
                    for (var i = 0; i < 15; i++)
                    {
                        if (atkShips[i].IsAlive())
                        {
                            //calculating dodgeFactor
                            var baseFactor = 1 - atkShips[i].Dodge / 100;
                            var movabilityFactor = 1.2 / (1 + 0.5 * Math.Pow(0.9032, atkShips[i].Amount - 1));
                            var squadronSizeFactor =
                                2 - 1.2 / (1 + 0.5 * Math.Pow(0.7953, sizeTotalAtk / atkShips[i].Size - 1));
                            var precisionPerSquadronFactor =
                                2 / (1 + 1.5 * Math.Pow(0.9221, precisionTotalDef / atkShips[i].Size)
                                );
                            var dodgeFactorThisRound =
                                baseFactor * movabilityFactor * squadronSizeFactor * precisionPerSquadronFactor;
                            var damageThisRound =
                                (dodgeFactorThisRound * (damageTotalDef * atkShips[i].PercentageSize(sizeTotalAtk))) -
                                atkShips[i].Shield * atkShips[i].Amount;

                            if (damageThisRound < 0) damageThisRound = 0; //healing not allowed
                            atkShips[i].DamageTaken += (float) damageThisRound;

                        }

                        if (defShips[i].IsAlive())
                        {
                            //calculating dodgeFactor
                            var baseFactor = 1 - defShips[i].Dodge / 100;
                            var movabilityFactor = 1.2 / (1 + 0.5 * Math.Pow(0.9032, defShips[i].Amount - 1));
                            var squadronSizeFactor =
                                2 - 1.2 / (1 + 0.5 * Math.Pow(0.7953, sizeTotalAtk / defShips[i].Size - 1));
                            var precisionPerSquadronFactor =
                                2 / (1 + 1.5 * Math.Pow(0.9221, precisionTotalAtk / defShips[i].Size)
                                );
                            var dodgeFactorThisRound =
                                baseFactor * movabilityFactor * squadronSizeFactor * precisionPerSquadronFactor;
                            var damageThisRound =
                                (dodgeFactorThisRound * (damageTotalAtk * defShips[i].PercentageSize(sizeTotalDef))) -
                                defShips[i].Shield * defShips[i].Amount;

                            if (damageThisRound < 0) damageThisRound = 0; //healing not allowed
                            defShips[i].DamageTaken += (float) damageThisRound;

                        }
                    }
                    
                    turnNumber++;
                    output += "\nRound " + turnNumber + "\n";
                    for (int i = 0; i < 15; i++)
                    {
                        output += atkShips[i].Name + ": " + atkShips[i].Amount + " vs " + defShips[i].Amount + "\n";
                    }
                }
            }

            return output;
        }
    }
}