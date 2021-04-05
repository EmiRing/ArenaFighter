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
        
        public Character(string characterName)
        {
            var fantasyNameSettings = new FantasyNameSettings(Classes.Warrior, Race.None, true, true, Gender.Male);
            IFantasyNameGenerator fantasyNameGenerator = FantasyNameGenerator.FromSettingsInfo(fantasyNameSettings);
            FantasyName[] names = fantasyNameGenerator.GetFantasyNames(1);

            CharacterName = characterName == null || characterName == "" ? names[0].FullName : characterName;

            Strength = rnd.Next(10, 18);
            Agility = rnd.Next(10, 18);
            MaxHealth = 100;
            Health = MaxHealth;
            SetDamage();
            SetHitChance();
            SetCritChance();
            SetDodgeChance();
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

        public double DodgeChance { get; private set; }

        public double Block { get; private set; }

        public double Speed { get; private set; }

        public bool IsPlayer { get; private set; }

        private void SetDamage() => Damage = Strength * 1.5;

        private void SetHitChance() => HitChance = 50 + Agility * 1.5;

        private void SetCritChance() => CritChance = (Agility + Strength) / 6.0;

        private void SetDodgeChance() => DodgeChance = 5 + Agility;

        private void SetBlock() => Block = Strength * 0.75;

        private void SetSpeed() => Speed = rnd.NextDouble();

        public void SetIsPlayer() => IsPlayer = true;

        public void SaveCharacter()
        {

        }
    }
}
