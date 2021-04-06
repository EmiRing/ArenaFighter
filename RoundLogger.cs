using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class RoundLogger
    {
        public RoundLogger()
        {

        }

        public RoundLogger(string round, string attackerName, string attackerDamage, string defenderName, string defenderHealth)
        {
            Round = round;
            AttackerName = attackerName;
            AttackerDamage = attackerDamage;
            DefenderName = defenderName;
            DefenderHealth = defenderHealth;
        }

        public string Round { get; set; }

        public string AttackerName { get; set; }

        public string AttackerDamage { get; set; }

        public string DefenderName { get; set; }

        public string DefenderHealth { get; set; }

        public string SaveOutput()
        {
            string outputToSave = $"{Round},{AttackerName},{AttackerDamage},{DefenderName},{DefenderHealth}";

            return outputToSave;
        }

        public void PrintOutput()
        {
            Console.WriteLine($"Round {Round}: {AttackerName} dealt {AttackerDamage} to {DefenderName}, leaving {DefenderHealth} health left.");

        }
    }
}
