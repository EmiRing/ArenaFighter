using System;



namespace ArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.Write("Enter your name: ");
            string input = Console.ReadLine();
            Character player = new Character(input);
            player.SetIsPlayer();
            Console.WriteLine("Your name is: {0}", player.CharacterName);

            Battle newBattle = new Battle(player);


            newBattle.EngageBattle();
            


            
        }
    }
}
