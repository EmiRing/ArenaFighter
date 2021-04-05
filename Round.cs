using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    static class Round
    {
        
        public static void AttackRound(Character attacker, Character defender, BattleLogger newlog, ref int roundNr)
        {

            Random rnd = new Random();
            

            double tryToHit = rnd.NextDouble() * 100;
            double hitLimit = attacker.CritChance + attacker.HitChance;
            double damageSpread = attacker.Damage*((rnd.NextDouble() - 0.5) / 2);
            double damageDone = attacker.Damage + damageSpread;
            
            if (tryToHit > hitLimit)
            {
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)} missed!!! How unfortunate!!");
                damageDone = 0;
                newlog.logRound(roundNr, attacker.CharacterName, damageDone, defender.CharacterName, defender.Health);
                return;
            }
            if (tryToHit <= attacker.CritChance)
            {
                double criticalDamageDone = Math.Round((Double)damageDone * 1.25, 2);
                defender.Health = defender.Health - criticalDamageDone < 0 ?
                    0 : Math.Round((Double)(defender.Health - criticalDamageDone),2);
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)}" +
                    $" critically hit {(attacker.IsPlayer == true ? defender.CharacterName : "you")}, dealing {criticalDamageDone} damage");
                newlog.logRound(roundNr, attacker.CharacterName, damageDone, defender.CharacterName, defender.Health);
                return;
            }
            damageDone = Math.Round((Double)damageDone - defender.Block, 2);
            defender.Health = defender.Health - damageDone < 0 ? 0 : Math.Round((Double)(defender.Health - damageDone), 2);

            Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)}" +
                $" hit {(attacker.IsPlayer == true ? defender.CharacterName : "you")}, dealing {damageDone} damage ");
            newlog.logRound(roundNr, attacker.CharacterName, damageDone, defender.CharacterName, defender.Health);



        }

        private static void UpdateLog()
        {

        }
    }
}
