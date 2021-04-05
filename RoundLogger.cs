using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class RoundLogger
    {
        public int Round { get; set; }

        public string AttackerName { get; set; }

        public double AttackerDamage { get; set; }

        public string DefenderName { get; set; }

        public double DefenderHealth { get; set; }

        public string SaveOutput()
        {
            string outputToSave = $"{Round},{AttackerName},{AttackerDamage},{DefenderName},{DefenderHealth}";

            return outputToSave;
        }


    }
}
