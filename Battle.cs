using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Battle
    {
        Character _player;
        Character _opponent;
        static int difficulty = 1;
        public Battle(Character player)
        {
            _player = player;
            _opponent = new Character(null, difficulty);
            _opponent.DisplayCharacterData();
            difficulty++;
        }
        
        public bool EngageBattle()
        {
            
            BattleLogger newlog = new BattleLogger();
            int roundNr = 1;
            Random rnd = new Random();
            bool bothAreAlive = true;
            bool isAlive = true;

            while (bothAreAlive)
            {
                
                double playerSpeed = _player.Speed * (rnd.NextDouble() - 0.5);
                double opponentSpeed = _opponent.Speed * (rnd.NextDouble() - 0.5);
                bool playerAttack = playerSpeed >= opponentSpeed ? true : false;

                Console.WriteLine($"Round {roundNr}");
                if (playerAttack)
                {
                    Round.AttackRound(_player, _opponent, newlog, ref roundNr);
                    
                }
                else 
                {
                    Round.AttackRound(_opponent, _player, newlog, ref roundNr);
                    
                }

                

                if (_player.Health <= 0)
                {
                    Console.WriteLine("You are dead!");
                    isAlive = false;

                    _ = newlog.WriteLog();
                    
                    return isAlive;
                    
                }
                if (_opponent.Health <= 0)
                {
                    Console.WriteLine("Your opponent is dead!");
                    
                    _ = newlog.WriteLog();
                    
                    return isAlive;
                }
                
                Console.WriteLine($"Your health is: {_player.Health}");
                Console.WriteLine($"The opponent health is: {_opponent.Health}");
                roundNr++;

                
                Console.ReadKey();
            }
            
            return isAlive;
        }

       
    }
}
