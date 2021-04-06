using System;



namespace ArenaFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader.DeleteFiles();
            Console.WriteLine("Welcome to this little game.");
            Console.Write("Please enter your name or one will be given to you: ");
            string input = Console.ReadLine();
            Character player = new Character(input);
            player.SetIsPlayer();

            if (input == "") Console.WriteLine("You were given the name: {0}", player.CharacterName);
            player.DisplayCharacterData();

            bool playerIsAlive = true;
            while (playerIsAlive)
            {

                Battle EngageBattle = new Battle(player);

                playerIsAlive = EngageBattle.EngageBattle();

                if (!playerIsAlive)
                {
                    Console.WriteLine("You died. Game over!");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("You survived the battle!");
                Console.Write("Do you want to Fight again Y/N:");
                string fightAgain = Console.ReadLine();
                if (!(fightAgain == "Y" || fightAgain == "y")) break;

                Console.WriteLine("------------------------------------------------");
            }

            FileReader.GetFiles();
            

            
        }
    }
}
