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
        public Battle(Character player)
        {
            _player = player;
            _opponent = new Character(null);
            
        }
        
        public void EngageBattle()
        {
            int roundNr = 1;
            Random rnd = new Random();
            while (_player.Health > 0 && _opponent.Health > 0)
            {
                
                double playerRoundSpeed = _player.Speed * (rnd.NextDouble() - 0.5);
                double opponentRoundSpeed = _opponent.Speed * (rnd.NextDouble() - 0.5);
                
                Console.WriteLine($"Round {roundNr}");
                if (playerRoundSpeed >= opponentRoundSpeed)
                {
                    Round.AttackRound(_player, _opponent);
                    Round.AttackRound(_opponent, _player);
                }
                else 
                {
                    Round.AttackRound(_opponent, _player);
                    Round.AttackRound(_player, _opponent);
                }

                Console.WriteLine(_player.Health <= 0 ? "You are dead!" : $"Your health is: {_player.Health}");
                Console.WriteLine(_opponent.Health <= 0 ? "You opponent is dead" : $"The opponent health is: {_opponent.Health}");
                roundNr++;

                
                Console.ReadKey();
            }

        }

    }
}
