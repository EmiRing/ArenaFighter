using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    static class Round
    {
        
        public static void AttackRound(Character attacker, Character defender)
        {

            Random rnd = new Random();

            double tryToHit = rnd.NextDouble() * 100;
            double hitLimit = attacker.CritChance + attacker.HitChance;
            double damageDone = attacker.Damage * (1+(rnd.NextDouble()-0.5)/2);
            
            if (tryToHit > hitLimit)
            {
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)} missed!!! How unfortunate!!");
                return;
            }
            if (tryToHit <= attacker.CritChance)
            {
                defender.Health = defender.Health - damageDone < 0 ? 0 
            }
            
           /* if (tryToHit <= attacker.CritChance)
            {
                damageDone = damageDone * (rnd.NextDouble() + 1) * 1.25;
                defender.Health = defender.Health - damageDone < 0 ? 0 : defender.Health - damageDone;
                
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)} critically hit {(attacker.IsPlayer == true ? defender.CharacterName : "you")}, dealing {damageDone} damage");
            }
            else if (tryToHit <= hitLimit)
            {
                damageDone = damageDone - defender.Block;
                defender.Health = defender.Health - damageDone < 0 ? 0 : defender.Health - damageDone;
                
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)} hit {(attacker.IsPlayer == true ? defender.CharacterName : "you")}, dealing {damageDone} damage ");
            }
            else
            {
                Console.WriteLine($"{(attacker.IsPlayer == true ? "You" : attacker.CharacterName)} missed!!! How unfortunate!!");
            }
*/
        }
    }
}
