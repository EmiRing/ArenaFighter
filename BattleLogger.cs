using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class BattleLogger
    {
        List<RoundLogger> rounds = new List<RoundLogger>();
        //string timestamp;
        string filename;
        string filePath;
        static private int counter = 1;

        public BattleLogger()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "battleLogs");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            //timestamp = DateTime.Now.ToString("yyMMddHHmmss");
            filename = $"battleLog{counter++}.log";
            filePath = Path.Combine(path,filename);
            
        }

        public void logRound(string round, string attackerName, string attackerDamage, string defenderName, string defenderHealth)
        {
            rounds.Add(new RoundLogger() 
            { 
                Round = round,
                AttackerName = attackerName, 
                AttackerDamage = attackerDamage, 
                DefenderName = defenderName, 
                DefenderHealth = defenderHealth 
            });
        }

        public async Task WriteLog()
        {
            using StreamWriter file = new(filePath, append:true);

            foreach (RoundLogger round in rounds)
            {
                await file.WriteLineAsync(round.SaveOutput());
            }
        }


    }
}
