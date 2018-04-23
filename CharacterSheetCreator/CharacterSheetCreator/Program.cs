﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetCreator
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum SizeCategory
    {
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

    public enum Race
    {
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        Half_Elf,
        Half_Orc,
        Tiefling
    }

    public enum SubRace
    {
        Hill_Dwarf,
        Mountain_Dwarf,
        High_Elf,
        Wood_Elf,
        Dark_Elf,
        Lightfoot_Halfling,
        Stout_Halfling,
        Forest_Gnome,
        Rock_Gnome
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Display the menu:
            displayMenu();

            //Stops the command window from closing immediately
            Console.ReadKey();
        }

        private static void displayMenu()
        {
            int answer;

            Console.WriteLine("Welcome to my Dungeons & Dragons Character Sheet Creation tool!");

            do
            {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("\tPress 1: Create a new character.");
                Console.WriteLine("\tPress 2: View the list of characters that already exist.");

                answer = Convert.ToInt32(Console.ReadLine());

                if(answer == 1)
                {
                    Console.WriteLine("\nOkay then! Let's make a new character!");
                }
                else if(answer == 2)
                {
                    if(DnDCharacter.getNumOfCharacters() == 0)
                    {
                        Console.WriteLine("\nThere are currently no characters created!");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, but that is not a valid input. Please select either option 1 or option 2 from the main menu!\n");
                }
            }
            while ( (answer != 1) && (answer != 2) );
        }
    }

    public interface IMenu
    {
        void displayMenu(Race r);
    }


    abstract class DnDCharacter : IMenu
    {
        //Character Info/Stats
        private string name;
        private int age;
        private int level = 1;

        public int hpMax = 0;//Maximum hit points
        public int speed = 0;//Base walking speed
        public int str = 0;//Strength ability score
        public int dex = 0;//Dexterity ability score
        public int con = 0;//Constitution ability score
        public int inte = 0;//Intelligence ability score
        public int wis = 0;//Wisdom ability score
        public int cha = 0;//Charisma ability score

        public int strMod = 0;//Strength score modifier
        public int dexMod = 0;//Dexterity score modifier
        public int conMod = 0;//Constitution score modifier
        public int inteMod = 0;//Intelligence score modifier
        public int wisMod = 0;//Wisdom score modifier
        public int chaMod = 0;//Charisma score modifier

        private Gender sex;
        private SizeCategory size;
        private Race race;
        private SubRace subRace;

        public string languagesKnown = "";

        //Saving Throws:
        public bool strSave = false;
        public bool dexSave = false;
        public bool conSave = false;
        public bool inteSave = false;
        public bool wisSave = false;
        public bool chaSave = false;

        //Skill Proficiencies:
        public bool acrobatics = false;
        public bool animalHandling = false;
        public bool arcana = false;
        public bool athletics = false;
        public bool deception = false;
        public bool history = false;
        public bool insight = false;
        public bool intimidation = false;
        public bool investigation = false;
        public bool medicine = false;
        public bool nature = false;
        public bool perception = false;
        public bool performance = false;
        public bool persuasion = false;
        public bool religion = false;
        public bool sleightOfHand = false;
        public bool stealth = false;
        public bool survival = false;

        //Weapon Proficiencies:
        public bool simple = false;
        public bool martial = false;
        
        public bool simpleMelee = false;
        public bool simpleRanged = false;
        public bool martialMelee = false;
        public bool martialRanged = false;
        //Simple Melee Weapons
        public bool club = false;
        public bool dagger = false;
        public bool greatclub = false;
        public bool handaxe = false;
        public bool javelin = false;
        public bool lightHammer = false;
        public bool mace = false;
        public bool quarterstaff = false;
        public bool sickle = false;
        public bool spear = false;
        //Simple Ranged Weapons
        public bool lightCrossbow = false;
        public bool dart = false;
        public bool shortbow = false;
        public bool sling = false;
        //Martial Melee Weapons
        public bool battleaxe = false;
        public bool flail = false;
        public bool glaive = false;
        public bool greataxe = false;
        public bool greatsword = false;
        public bool halberd = false;
        public bool lance = false;
        public bool longsword = false;
        public bool maul = false;
        public bool morningstar = false;
        public bool pike = false;
        public bool rapier = false;
        public bool scimitar = false;
        public bool shortsword = false;
        public bool trident = false;
        public bool warPick = false;
        public bool warhammer = false;
        public bool whip = false;
        //Martial Ranged Weapons
        public bool blowgun = false;
        public bool handCrossbow = false;
        public bool heavyCrossbow = false;
        public bool longbow = false;
        public bool net = false;


        //Armour Proficiencies:
        public bool lightArmour = false;
        public bool mediumArmour = false;
        public bool heavyArmour = false;
        public bool shields = false;

        public static int numOfCharacters = 0;

        //DON'T LET THIS BE CALLED IF ANY NUMBER OTHER THAN THE RACE ONES ARE CHOSEN!!!!!!!!!!!!!!!
        public DnDCharacter(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore)
        {
            //Set the character's name and age:
            name = namae;
            age = anni;

            //Set the character's ability scores
            str = strScore;
            dex = dexScore;
            con = conScore;
            inte = inteScore;
            wis = wisScore;
            cha = chaScore;

            //What is the character's gender?
            if (morf == true)
            {
                sex = Gender.Male;
            }
            else if (morf == false)
            {
                sex = Gender.Female;
            }

            numOfCharacters++;//Increase the count of the number of characters

            //What race is the character?
            switch (selectedRace)
            {
                case 1:
                    race = Race.Dwarf;
                    con = con + 2;//Ability score increase
                    size = SizeCategory.Medium;
                    speed = 25;//Base walking speed
                    languagesKnown = "Common and Dwarvish";

                    displayMenu(race);//Determine sub-race
                    if(subRace == SubRace.Hill_Dwarf)
                    {
                        wis = wis + 1;
                        hpMax = hpMax + 1;
                    }
                    else if(subRace == SubRace.Mountain_Dwarf)
                    {
                        str = str + 2;
                        lightArmour = true;//Gain proficiency with light armour
                        mediumArmour = true;//Gain proficiency with medium armour
                    }
                    break;

                case 2:
                    race = Race.Elf;
                    dex = dex + 2;//Ability score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and Elvish";

                    perception = true;

                    displayMenu(race);//Determine sub-race
                    if(subRace == SubRace.High_Elf)
                    {
                        inte = inte + 1;//Ability score increase

                        //Weapon Proficiencies
                        longsword = true;
                        shortsword = true;
                        shortbow = true;
                        longbow = true;

                        //Extra Language(s)
                        languagesKnown = languagesKnown + " and one more of your choice";
                    }
                    else if(subRace == SubRace.Wood_Elf)
                    {
                        wis = wis + 1;//Ability score increase

                        //Weapon Proficiencies
                        longsword = true;
                        shortsword = true;
                        shortbow = true;
                        longbow = true;

                        speed = 35;//Increased base walking speed
                    }
                    else if(subRace == SubRace.Dark_Elf)
                    {
                        cha = cha + 1;//Ability score increase

                        //Weapon Proficiencies
                        rapier = true;
                        shortsword = true;
                        handCrossbow = true;
                    }
                    break;

                case 3:
                    race = Race.Halfling;
                    dex = dex + 2;//Ability score increase
                    size = SizeCategory.Small;
                    speed = 25;//Base walking speed
                    languagesKnown = "Common and Halfling";

                    displayMenu(race);//Determine sub-race
                    if(subRace == SubRace.Lightfoot_Halfling)
                    {
                        cha = cha + 1;
                    }
                    else if(subRace == SubRace.Stout_Halfling)
                    {
                        con = con + 1;
                    }
                    break;

                case 4:
                    race = Race.Human;
                    str = str + 1;//Strength score increase
                    dex = dex + 1;//Dexterity score increase
                    con = con + 1;//Constitution score increase
                    inte = inte + 1;//Intelligence score increase
                    wis = wis + 1;//Wisdom score increase
                    cha = cha + 1;//Charisma score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and one other of your choice";
                    break;

                case 5:
                    race = Race.Dragonborn;
                    str = str + 2;//Strength score increase
                    cha = cha + 1;//Charisma score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and Draconic";
                    break;

                case 6:
                    race = Race.Gnome;
                    inte = inte + 2;//Intelligence score increase
                    size = SizeCategory.Small;
                    speed = 25;//Base walking speed
                    languagesKnown = "Common and Gnomish";

                    displayMenu(race);//Determine sub-race
                    if(subRace == SubRace.Forest_Gnome)
                    {
                        dex = dex + 1;//Dexterity score increase
                    }
                    else if(subRace == SubRace.Rock_Gnome)
                    {
                        con = con + 1;//Constitution score increase
                    }
                    break;

                case 7:
                    race = Race.Half_Elf;
                    cha = cha + 2;//Charisma score increase
                    dex = dex + 1;//Dexterity score increase
                    inte = inte + 1;//Intelligence score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common, Elvish and one language of your choice";

                    //Skill Proficiencies:
                    arcana = true;
                    investigation = true;
                    break;

                case 8:
                    race = Race.Half_Orc;
                    str = str + 2;//Strength score increase
                    con = con + 1;//Constitution score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and Orc";

                    //Skill Proficiencies:
                    intimidation = true;
                    break;

                case 9:
                    race = Race.Tiefling;
                    inte = inte + 1;//Intelligence score increase
                    cha = cha + 2;//Charisma score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and Infernal";
                    break;
            }

            //Calculate the ability score modifiers
            strMod = calcModifier(str);
            dexMod = calcModifier(dex);
            conMod = calcModifier(con);
            inteMod = calcModifier(inte);
            wisMod = calcModifier(wis);
            chaMod = calcModifier(cha);

            //Set the character's proficiencies
            setWandAProf();
        }

        //Get the current number of characters
        public static int getNumOfCharacters()
        {
            return numOfCharacters;
        }

        //Calculate the ability score modifiers
        public int calcModifier(int abilityScore)
        {
            int abilityScore_Modifier = 0;

            int tempScore = abilityScore;

            if (tempScore > 10)
            {
                if ((tempScore % 2) == 1)//If it's an odd number
                {
                    tempScore = tempScore - 1;//Reduce tempScore by 1 so it divides evenly by 2
                }

                if (tempScore == 10)
                {
                    abilityScore_Modifier = 0;
                }
                else
                {
                    abilityScore_Modifier = (tempScore - 10) / 2;
                }
            }
            else if (tempScore < 10)
            {
                if ((tempScore % 2) == 0)//If it's an even number
                {
                    tempScore = tempScore + 1;
                }

                abilityScore_Modifier = (11 - tempScore) / (-2);
            }
            else if (tempScore == 10)
            {
                abilityScore_Modifier = 0;
            }

            return abilityScore_Modifier;
        }

        //Set weapon and armour proficiencies
        public void setWandAProf()
        {
            //If you're proficient with simple weapons
            if (simple == true)
            {
                simpleMelee = true;
                simpleRanged = true;
            }

            //If you're proficient with martial weapons
            if (martial == true)
            {
                martialMelee = true;
                martialRanged = true;
            }

            //If you're proficient with simple melee weapons
            if (simpleMelee == true)
            {
                //Simple Melee Weapons
                club = true;
                dagger = true;
                greatclub = true;
                handaxe = true;
                javelin = true;
                lightHammer = true;
                mace = true;
                quarterstaff = true;
                sickle = true;
                spear = true;
            }

            //If you're proficient with simple ranged weapons
            if (simpleRanged == true)
            {
                //Simple Ranged Weapons
                lightCrossbow = true;
                dart = true;
                shortbow = true;
                sling = true;
            }

            //If you're proficient with martial melee weapons
            if (martialMelee == true)
            {
                //Martial Melee Weapons
                battleaxe = true;
                flail = true;
                glaive = true;
                greataxe = true;
                greatsword = true;
                halberd = true;
                lance = true;
                longsword = true;
                maul = true;
                morningstar = true;
                pike = true;
                rapier = true;
                scimitar = true;
                shortsword = true;
                trident = true;
                warPick = true;
                warhammer = true;
                whip = true;
            }

            //If you're proficient with martial ranged weapons
            if (martialRanged == true)
            {
                //Martial Ranged Weapons
                blowgun = true;
                handCrossbow = true;
                heavyCrossbow = true;
                longbow = true;
                net = true;
            }
        }

        //Implement the displayMenu() method inherited from the IMenu Interface
        public void displayMenu(Race r)
        {
            int answer = 0;

            Console.WriteLine("You are a {0}.", r);

            if (r == Race.Dwarf)
            {
                do
                {
                    Console.WriteLine("Are you a Hill Dwarf or a Mountain Dwarf?");
                    Console.WriteLine("\tPress 1: I am a Hill Dwarf.");
                    Console.WriteLine("\tPress 2: I am a Mountain Dwarf.");

                    answer = Convert.ToInt32(Console.ReadLine());

                    //Assign the subRace
                    if (answer == 1)
                    {
                        subRace = SubRace.Hill_Dwarf;
                    }
                    else if (answer == 2)
                    {
                        subRace = SubRace.Mountain_Dwarf;
                    }

                    //Inform the user of incorrect input
                    if ((answer != 1) && (answer != 2))
                    {
                        Console.WriteLine("\nThat is not a sub-race of Dwarf!\n");
                    }
                }
                while ((answer != 1) && (answer != 2));
            }
            else if (r == Race.Elf)
            {
                do
                {
                    Console.WriteLine("Are you a High Elf, Wood Elf or Dark Elf(Drow)?");
                    Console.WriteLine("\tPress 1: I am a High Elf.");
                    Console.WriteLine("\tPress 2: I am a Wood Elf.");
                    Console.WriteLine("\tPress 3: I am a Dark Elf.");

                    answer = Convert.ToInt32(Console.ReadLine());

                    //Assign the subRace
                    if(answer == 1)
                    {
                        subRace = SubRace.High_Elf;
                    }
                    else if(answer == 2)
                    {
                        subRace = SubRace.Wood_Elf;
                    }
                    else if(answer == 3)
                    {
                        subRace = SubRace.Dark_Elf;
                    }

                    //Inform the user of incorrect input
                    if ((answer != 1) && (answer != 2) && (answer != 3))
                    {
                        Console.WriteLine("\nThat is not a sub-race of Elf!\n");
                    }
                }
                while ( (answer != 1) && (answer != 2) && (answer != 3) );
            }
            else if (r == Race.Halfling)
            {
                do
                {
                    Console.WriteLine("Are you a Lightfoot Halfling or a Stout Halfling?");
                    Console.WriteLine("\tPress 1: I am a Lightfoot Halfling.");
                    Console.WriteLine("\tPress 2: I am a Stout Halfling.");

                    answer = Convert.ToInt32(Console.ReadLine());

                    //Assign the subRace
                    if (answer == 1)
                    {
                        subRace = SubRace.Lightfoot_Halfling;
                    }
                    else if (answer == 2)
                    {
                        subRace = SubRace.Stout_Halfling;
                    }

                    //Inform the user of incorrect input
                    if ((answer != 1) && (answer != 2))
                    {
                        Console.WriteLine("\nThat is not a sub-race of Halfling!\n");
                    }
                }
                while ((answer != 1) && (answer != 2));
            }
            else if (r == Race.Gnome)
            {
                do
                {
                    Console.WriteLine("Are you a Forest Gnome or a Rock Gnome?");
                    Console.WriteLine("\tPress 1: I am a Forest Gnome.");
                    Console.WriteLine("\tPress 2: I am a Rock Gnome.");

                    answer = Convert.ToInt32(Console.ReadLine());

                    //Assign the subRace
                    if (answer == 1)
                    {
                        subRace = SubRace.Forest_Gnome;
                    }
                    else if (answer == 2)
                    {
                        subRace = SubRace.Rock_Gnome;
                    }

                    //Inform the user of incorrect input
                    if ((answer != 1) && (answer != 2))
                    {
                        Console.WriteLine("\nThat is not a sub-race of Gnome!\n");
                    }
                }
                while ((answer != 1) && (answer != 2));
            }

        }

        public abstract int hpCalc();

    }


    //DnD CLASSES:
    //----------------------------------------------
    //Stuff specific to Barbarians
    class Barbarian : DnDCharacter
    {
         public Barbarian(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            strSave = true;
            conSave = true;

            //Weapon Proficiencies
            simple = true;
            martial = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            shields = true;

            //Skill Proficiencies
            athletics = true;
            intimidation = true;
        }

        public override int hpCalc()
        {
            return 12 + conMod;
        }
    }


    //Stuff specific to Bards
    class Bard : DnDCharacter
    {
        public Bard(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            dexSave = true;//Proficient in Dexterity Saving Throws
            chaSave = true;//Proficient in Charisma Saving Throws

            //Weapon Proficiencies
            simple = true;
            handCrossbow = true;
            longsword = true;
            rapier = true;
            shortsword = true;

            //Armour Proficiencies
            lightArmour = true;

            //Skill Proficiencies
            history = true;
            performance = true;
            persuasion = true;

        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Clerics
    class Cleric : DnDCharacter
    {
        public Cleric(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            wisSave = true;
            chaSave = true;

            //Weapon Proficiencies
            simple = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            shields = true;

            //Skill Proficiencies
            medicine = true;
            religion = true;
        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Druids
    class Druid : DnDCharacter
    {
        public Druid(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            inteSave = true;
            wisSave = true;

            //Weapon Proficiencies
            club = true;
            dagger = true;
            dart = true;
            javelin = true;
            mace = true;
            quarterstaff = true;
            scimitar = true;
            sickle = true;
            sling = true;
            spear = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            shields = true;

            //Sill Proficiencies
            animalHandling = true;
            nature = true;
        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Fighters
    class Fighter : DnDCharacter
    {
        public Fighter(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            strSave = true;
            conSave = true;

            //Weapon Proficiencies
            simple = true;
            martial = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            heavyArmour = true;
            shields = true;

            //Skill Proficiencies
            acrobatics = true;
            athletics = true;
        }

        public override int hpCalc()
        {
            return 10 + conMod;
        }
    }

    //Stuff specific to Monks
    class Monk : DnDCharacter
    {
        public Monk(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            strSave = true;
            dexSave = true;

            //Weapon Proficiencies
            simple = true;
            shortsword = true;

            //Armour Proficiencies: NONE

            //Skill Proficiencies
            acrobatics = true;
            insight = true;
        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Paladins
    class Paladin : DnDCharacter
    {
        public Paladin(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            wisSave = true;
            chaSave = true;

            //Weapon Proficiencies
            simple = true;
            martial = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            heavyArmour = true;
            shields = true;

            //Skill Proficiencies
            insight = true;
            religion = true;
        }

        public override int hpCalc()
        {
            return 10 + conMod;
        }
    }

    //Stuff specific to Rangers
    class Ranger : DnDCharacter
    {
        public Ranger(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            strSave = true;
            dexSave = true;

            //Weapon Proficiencies
            simple = true;
            martial = true;

            //Armour Proficiencies
            lightArmour = true;
            mediumArmour = true;
            shields = true;

            //Skill Proficiencies
            animalHandling = true;
            perception = true;
            survival = true;
        }

        public override int hpCalc()
        {
            return 10 + conMod;
        }
    }

    //Stuff specific to Rogues
    class Rogue : DnDCharacter
    {
        public Rogue(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            dexSave = true;
            inteSave = true;

            //Weapon Proficiencies
            simple = true;
            handCrossbow = true;
            longsword = true;
            rapier = true;
            shortsword = true;

            //Armour Proficiencies
            lightArmour = true;

            //Skill Proficiencies
            acrobatics = true;
            investigation = true;
            sleightOfHand = true;
            stealth = true;
        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Sorcerers
    class Sorcerer : DnDCharacter
    {
        public Sorcerer(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            conSave = true;
            chaSave = true;

            //Weapon Proficiencies
            dagger = true;
            dart = true;
            sling = true;
            quarterstaff = true;
            lightCrossbow = true;

            //Armour Proficiencies: NONE

            //Skill Proficiencies
            arcana = true;
            religion = true;
        }

        public override int hpCalc()
        {
            return 6 + conMod;
        }
    }

    //Stuff specific to Warlocks
    class Warlock : DnDCharacter
    {
        public Warlock(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            wisSave = true;
            chaSave = true;

            //Weapon Proficiencies
            simple = true;

            //Armour Proficiencies
            lightArmour = true;

            //Skill Proficiences
            arcana = true;
            investigation = true;
        }

        public override int hpCalc()
        {
            return 8 + conMod;
        }
    }

    //Stuff specific to Wizards
    class Wizard : DnDCharacter
    {
        public Wizard(string namae, int anni, bool morf, int selectedRace, int strScore, int dexScore, int conScore, int inteScore, int wisScore, int chaScore) : base(namae, anni, morf, selectedRace, strScore, dexScore, conScore, inteScore, wisScore, chaScore)
        {
            hpMax = hpCalc();

            //Saving Throw Proficiencies
            inteSave = true;
            wisSave = true;

            //Weapon Proficiencies
            dagger = true;
            dart = true;
            sling = true;
            quarterstaff = true;
            lightCrossbow = true;

            //Skill Proficiencies
            arcana = true;
            history = true;
        }

        public override int hpCalc()
        {
            return 6 + conMod;
        }
    }
}
