using System;
using RPGKit.FantasyNameGenerator;
using RPGKit.FantasyNameGenerator.Generators;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    class Character
    {
        Random rnd = new Random();
        double _difficulty = 1;
        
        public Character(string characterName)
        {
            try
            {
                var fantasyNameSettings = new FantasyNameSettings(Classes.Warrior, Race.None, true, true, Gender.Male);
                IFantasyNameGenerator fantasyNameGenerator = FantasyNameGenerator.FromSettingsInfo(fantasyNameSettings);
                FantasyName[] names = fantasyNameGenerator.GetFantasyNames(1);
                CharacterName = characterName == null || characterName == "" ? names[0].FullName : characterName;
            }
            catch 
            {

                CharacterName = characterName == null || characterName == "" ? "Crash Bandicoot" : characterName;
            }

           
            Strength = rnd.Next(10, 18);
            Agility = rnd.Next(10, 18);
            MaxHealth = 100;
            Health = MaxHealth;
            SetDamage();
            SetHitChance();
            SetCritChance();
            SetBlock();
            SetSpeed();
        }

        public Character(string characterName, int difficulty)
        {
            try
            {
                var fantasyNameSettings = new FantasyNameSettings(Classes.Warrior, Race.None, true, true, Gender.Male);
                IFantasyNameGenerator fantasyNameGenerator = FantasyNameGenerator.FromSettingsInfo(fantasyNameSettings);
                FantasyName[] names = fantasyNameGenerator.GetFantasyNames(1);
                CharacterName = characterName == null || characterName == "" ? names[0].FullName : characterName;
            }
            catch 
            {

                CharacterName = characterName == null || characterName == "" ? "Grim Stekspade" : characterName;
            }

            _difficulty = difficulty / 3.0;
            Strength = rnd.Next(10, 18);
            Agility = rnd.Next(10, 18);
            MaxHealth =  Convert.ToInt32(100 * _difficulty);
            Health = MaxHealth;
            SetDamage();
            SetHitChance();
            SetCritChance();
            SetBlock();
            SetSpeed();
        }

        public string CharacterName { get; }
       
        public int Strength { get; private set; }
                
        public int Agility { get; private set; }

        public int MaxHealth { get; private set; }

        public double Health { get; set; }
        
        public double Damage { get; private set; }

        public double HitChance { get; private set; }

        public double CritChance { get; private set; }

        public double Block { get; private set; }

        public double Speed { get; private set; }

        public bool IsPlayer { get; private set; }

        private void SetDamage() => Damage = Strength * 1.5;

        private void SetHitChance() => HitChance = 54 + Agility * 1.5;

        private void SetCritChance() => CritChance = (Agility + Strength) / 6.0;

        private void SetBlock() => Block = Strength * 0.75;

        private void SetSpeed() => Speed = rnd.NextDouble();

        public void SetIsPlayer() => IsPlayer = true;

        public void DisplayCharacterData()
        {

            Console.WriteLine($"{(IsPlayer ? "Player" : "Opponent")} name: {CharacterName}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Strength:   {Strength}");
            Console.WriteLine($"Agility:    {Agility}");
            Console.WriteLine($"Health:     {Health}");
            Console.WriteLine("------------------------------------------");
        }
    }
}
