using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        NA,
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
            //Variable to record user's menu selection
            int answer = 0;
            //List for storing the characters
            List<DnDCharacter> characterList = new List<DnDCharacter>();

            Console.WriteLine("Welcome to my Dungeons & Dragons Character Sheet Creation tool!");

            do
            {
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("\tPress 1: Create a new character.");
                Console.WriteLine("\tPress 2: View the list of characters that already exist.");//Or created this session
                Console.WriteLine("\tPress 3: Close the application.");

                answer = Convert.ToInt32(Console.ReadLine());

                if(answer == 1)
                {
                    Console.WriteLine("\nOkay then! Let's make a new character!");
                    createCharacter(characterList);
                    writeToFile(characterList);
                    answer = 0;//Reser the value of answer to 0 so the main menu reappears
                }
                else if(answer == 2)
                {
                    if(DnDCharacter.getNumOfCharacters() > 0)
                    {
                        foreach(DnDCharacter character in characterList)
                        {
                            Console.WriteLine("Name: ");
                        }
                    }
                    else if(DnDCharacter.getNumOfCharacters() == 0)
                    {
                        Console.WriteLine("\nThere are currently no characters created!");
                    }

                    answer = 0;//Reset the value of answer to 0 so the main menu reappears
                }
                else if(answer == 3)
                {
                    //Thank the user for using the application
                    Console.WriteLine("Thank you for using my Dungeons & Dragons Character Sheet Creation tool!");
                    Console.WriteLine("See ya! :)");

                    Environment.Exit(0);//Close the application (Works for Console Applications)
                    //Application.Exit() works for Windows Forms based applications
                }
                else
                {
                    Console.WriteLine("Sorry, but that is not a valid input. Please select either option 1 or option 2 from the main menu!\n");
                }
            }
            while ( (answer != 1) && (answer != 2) && (answer != 3) );
        }

        private static void writeToFile(List<DnDCharacter> characterList)
        {
            StreamWriter sw;

            foreach (DnDCharacter c in characterList)
            {
                using (sw = new StreamWriter("CharacterStorage/" + c.name + ".txt"))
                {
                    //Inform user that file writing is taking place
                    Console.WriteLine("\nAdding {0} to the file!\n", c.name);

                    sw.Write("Name: " + c.name);//Write the name to the file
                    sw.Write("\tAge: " + c.age + " years old");//Write the age to the file
                    sw.WriteLine("\tRace: " + c.race);//Write the race to the file
                    sw.Write("Sub-Race: " + c.subRace);//Write the sub-race to the file
                    sw.Write("\tClass: " + c.characterClass + " Lvl " + c.level);//Character's class
                    sw.Write("\tSex: " + c.sex);//Character's gender
                    sw.WriteLine("\tSize: " + c.size);//Character's size

                    sw.WriteLine();

                    sw.WriteLine("\nMax. HP: " + c.hpMax);
                    //Ability scores and modifiers
                    sw.WriteLine("Strength:     " + c.str + "\tMod: " + c.strMod);
                    sw.WriteLine("Dexterity:    " + c.dex + "\tMod: " + c.dexMod);
                    sw.WriteLine("Constitution: " + c.con + "\tMod: " + c.conMod);
                    sw.WriteLine("Intelligence: " + c.inte + "\tMod: " + c.inteMod);
                    sw.WriteLine("Wisdom:       " + c.wis + "\tMod: " + c.wisMod);
                    sw.WriteLine("Charisma:     " + c.cha + "\tMod: " + c.chaMod);

                    sw.WriteLine();

                    //Languages Known
                    sw.WriteLine("\n{0} knows {1}.", c.name, c.languagesKnown);

                    sw.WriteLine();

                    //Saving Throw Proficiencies
                    sw.WriteLine("Saving Throw Proficiencies:");
                    sw.WriteLine("                                  Proficient:");
                    sw.WriteLine("Strength Saving Throws                 " + c.strSave);
                    sw.WriteLine("Dexterity Saving Throws                " + c.dexSave);
                    sw.WriteLine("Constitution Saving Throws             " + c.conSave);
                    sw.WriteLine("Intelligence Saving Throws             " + c.inteSave);
                    sw.WriteLine("Wisdom Saving Throws                   " + c.wisSave);
                    sw.WriteLine("Charisma Saving Throws                 " + c.chaSave);

                    sw.WriteLine();

                    //Skill Proficiencies
                    sw.WriteLine("Skill Proficiencies:");
                    sw.WriteLine("                      Proficient:");
                    sw.WriteLine("Acrobatics                 " + c.acrobatics);
                    sw.WriteLine("Animal Handling            " + c.animalHandling);
                    sw.WriteLine("Arcana                     " + c.arcana);
                    sw.WriteLine("Athletics                  " + c.athletics);
                    sw.WriteLine("Deception                  " + c.deception);
                    sw.WriteLine("History                    " + c.history);
                    sw.WriteLine("Insight                    " + c.insight);
                    sw.WriteLine("Intimidation               " + c.intimidation);
                    sw.WriteLine("Investigation              " + c.investigation);
                    sw.WriteLine("Medicine                   " + c.medicine);
                    sw.WriteLine("Nature                     " + c.nature);
                    sw.WriteLine("Perception                 " + c.perception);
                    sw.WriteLine("Performance                " + c.performance);
                    sw.WriteLine("Persuasion                 " + c.persuasion);
                    sw.WriteLine("Religion                   " + c.religion);
                    sw.WriteLine("Sleight of Hand            " + c.sleightOfHand);
                    sw.WriteLine("Stealth                    " + c.stealth);
                    sw.WriteLine("Survival                   " + c.survival);

                    sw.WriteLine();

                    //Weapon Proficiencies
                    sw.WriteLine("Weapon Proficiencies:");
                    sw.WriteLine("                      Proficient:");
                    sw.WriteLine("Club                       " + c.club);
                    sw.WriteLine("Dagger                     " + c.dagger);
                    sw.WriteLine("Greatclub                  " + c.greatclub);
                    sw.WriteLine("Handaxe                    " + c.handaxe);
                    sw.WriteLine("Javelin                    " + c.javelin);
                    sw.WriteLine("Light Hammer               " + c.lightHammer);
                    sw.WriteLine("Mace                       " + c.mace);
                    sw.WriteLine("Quarterstaff               " + c.quarterstaff);
                    sw.WriteLine("Sickle                     " + c.sickle);
                    sw.WriteLine("Spear                      " + c.spear);
                    sw.WriteLine("Light Crossbow             " + c.lightCrossbow);
                    sw.WriteLine("Dart                       " + c.dart);
                    sw.WriteLine("Shortbow                   " + c.shortbow);
                    sw.WriteLine("Sling                      " + c.sling);
                    sw.WriteLine("Battleaxe                  " + c.battleaxe);
                    sw.WriteLine("Flail                      " + c.flail);
                    sw.WriteLine("Glaive                     " + c.glaive);
                    sw.WriteLine("Greataxe                   " + c.greataxe);
                    sw.WriteLine("Greatsword                 " + c.greatsword);
                    sw.WriteLine("Halberd                    " + c.halberd);
                    sw.WriteLine("Lance                      " + c.lance);
                    sw.WriteLine("Longsword                  " + c.longsword);
                    sw.WriteLine("Maul                       " + c.maul);
                    sw.WriteLine("Morningstar                " + c.morningstar);
                    sw.WriteLine("Pike                       " + c.pike);
                    sw.WriteLine("Rapier                     " + c.rapier);
                    sw.WriteLine("Scimitar                   " + c.scimitar);
                    sw.WriteLine("Shortsword                 " + c.shortsword);
                    sw.WriteLine("Trident                    " + c.trident);
                    sw.WriteLine("War Pick                   " + c.warPick);
                    sw.WriteLine("Warhammer                  " + c.warhammer);
                    sw.WriteLine("Whip                       " + c.whip);
                    sw.WriteLine("Blowgun                    " + c.blowgun);
                    sw.WriteLine("Hand Crossbow              " + c.handCrossbow);
                    sw.WriteLine("Heavy Crossbow             " + c.heavyCrossbow);
                    sw.WriteLine("Longbow                    " + c.longbow);
                    sw.WriteLine("Net                        " + c.net);

                    sw.WriteLine();

                    //Armour Proficiencies
                    sw.WriteLine("Armour Proficiencies:");
                    sw.WriteLine("                      Proficient:");
                    sw.WriteLine("Light Armour               " + c.lightArmour);
                    sw.WriteLine("Medium Armour              " + c.mediumArmour);
                    sw.WriteLine("Heavy Armour               " + c.heavyArmour);
                    sw.WriteLine("Shields                    " + c.shields);
                }
                    
            }   
            
        }

        private static void createCharacter(List<DnDCharacter> characterList)
        {
            //New Character
            DnDCharacter newCharacter;

            //Character Info:
            string name = "";
            int age = 0;
            int morfSelect = 0;
            bool morf = true;
            int selectedRace = 0;
            int selectedClass = 0;

            int strength = 0;
            int dexterity = 0;
            int constitution = 0;
            int intelligence = 0;
            int wisdom = 0;
            int charisma = 0;

            Console.WriteLine("\nWhat is your character's name?: ");//Character's name
            name = Console.ReadLine();//Read in the name

            Console.WriteLine("\nWhat age is {0}?:", name );//Character's age
            age = Convert.ToInt32(Console.ReadLine());//Read in the age and convert to an int

            do
            {
                Console.WriteLine("\nIs {0} male or female?:", name);//Is the character male or female
                Console.WriteLine("\tPress 1: {0} is Male", name);
                Console.WriteLine("\tPress 2: {0} is Female", name);

                morfSelect = Convert.ToInt32(Console.ReadLine());

                if(morfSelect == 1)
                {
                    morf = true;//The character is male
                }
                else if(morfSelect == 2)
                {
                    morf = false;//The character is female
                }
                else if( (morfSelect != 1) && (morfSelect != 2) )
                {
                    //Inform the user that they entered incorrect input
                    Console.WriteLine("\nPlease select one of the options given.");
                }
            }
            while( (morfSelect != 1) && (morfSelect != 2) );

            do
            {
                Console.WriteLine("\nWhat race is {0}?:", name);//Character's race
                Console.WriteLine("\tPress 1: {0} is a Dwarf.", name);
                Console.WriteLine("\tPress 2: {0} is an Elf.", name);
                Console.WriteLine("\tPress 3: {0} is a Halfling.", name);
                Console.WriteLine("\tPress 4: {0} is a Human.", name);
                Console.WriteLine("\tPress 5: {0} is a Dragonborn.", name);
                Console.WriteLine("\tPress 6: {0} is a Gnome.", name);
                Console.WriteLine("\tPress 7: {0} is a Half-Elf.",name);
                Console.WriteLine("\tPress 8: {0} is a Half-Orc.", name);
                Console.WriteLine("\tPress 9: {0} is a Tiefling.", name);

                selectedRace = Convert.ToInt32(Console.ReadLine());
            }
            while( (selectedRace != 1) && (selectedRace != 2) && (selectedRace != 3) && (selectedRace != 4) && (selectedRace != 5) && (selectedRace != 6) && (selectedRace != 7) && (selectedRace != 8) && (selectedRace != 9) );

            strength = calcAbilityScore(strength);
            dexterity = calcAbilityScore(dexterity);
            constitution = calcAbilityScore(constitution);
            intelligence = calcAbilityScore(intelligence);
            wisdom = calcAbilityScore(wisdom);
            charisma = calcAbilityScore(charisma);
            
            //Character's class
            do
            {
                Console.WriteLine("What is {0}'s Class?:", name);
                Console.WriteLine("\tPress 1: {0} is a Barbarian.", name);
                Console.WriteLine("\tPress 2: {0} is a Bard.", name);
                Console.WriteLine("\tPress 3: {0} is a Cleric.", name);
                Console.WriteLine("\tPress 4: {0} is a Druid.", name);
                Console.WriteLine("\tPress 5: {0} is a Fighter.", name);
                Console.WriteLine("\tPress 6: {0} is a Monk.", name);
                Console.WriteLine("\tPress 7: {0} is a Paladin.", name);
                Console.WriteLine("\tPress 8: {0} is a Ranger.", name);
                Console.WriteLine("\tPress 9: {0} is a Rogue.", name);
                Console.WriteLine("\tPress 10: {0} is a Sorcerer.", name);
                Console.WriteLine("\tPress 11: {0} is a Warlock.", name);
                Console.WriteLine("\tPress 12: {0} is a Wizard.", name);

                selectedClass = Convert.ToInt32(Console.ReadLine());

                if(selectedClass == 1)
                {
                    //Make the new character a Barbarian
                    newCharacter = new Barbarian(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 2)
                {
                    //Make the new character a Bard
                    newCharacter = new Bard(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 3)
                {
                    //Make the new character a Cleric
                    newCharacter = new Cleric(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 4)
                {
                    //Make the new character a Druid
                    newCharacter = new Druid(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 5)
                {
                    //Make the new character a Fighter
                    newCharacter = new Fighter(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 6)
                {
                    //Make the new character a Monk
                    newCharacter = new Monk(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 7)
                {
                    //Make the new character a Paladin
                    newCharacter = new Paladin(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 8)
                {
                    //Make the new character a Ranger
                    newCharacter = new Ranger(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 9)
                {
                    //Make the new character a Rogue
                    newCharacter = new Rogue(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 10)
                {
                    //Make the new character a Sorcerer
                    newCharacter = new Sorcerer(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 11)
                {
                    //Make the new character a Warlock
                    newCharacter = new Warlock(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if(selectedClass == 12)
                {
                    //Make the new character a Wizard
                    newCharacter = new Wizard(name, age, morf, selectedRace, strength, dexterity, constitution, intelligence, wisdom, charisma);
                    characterList.Add(newCharacter);
                }
                else if( (selectedClass != 1) && (selectedClass != 2) && (selectedClass != 3) && (selectedClass != 4) && (selectedClass != 5) && (selectedClass != 6) && (selectedClass != 7) && (selectedClass != 8) && (selectedClass != 9) && (selectedClass != 10) && (selectedClass != 11) && (selectedClass != 12) )
                {
                    //Inform the user of incorrect input
                    Console.WriteLine("That is not a Dungeons & Dragons Class. Please select from the options provided!");
                }
            }
            while( (selectedClass != 1) && (selectedClass != 2) && (selectedClass != 3) && (selectedClass != 4) && (selectedClass != 5) && (selectedClass != 6) && (selectedClass != 7) && (selectedClass != 8) && (selectedClass != 9) && (selectedClass != 10) && (selectedClass != 11) && (selectedClass != 12) );

            
        }

        public static int calcAbilityScore(int ability)
        {
            //Four rolls of a 6-sided dice
            int roll1 = 0;
            int roll2 = 0;
            int roll3 = 0;
            int roll4 = 0;
            Random rand = new Random();

            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 7);
            roll3 = rand.Next(1, 7);
            roll4 = rand.Next(1, 7);

            //Add the three largest rolls
            if ( (roll1 >= roll4) && (roll2 >= 4) && (roll3 >= 4) )
            {
                ability = roll1 + roll2 + roll3;
            }
            else if ( (roll1 >= roll3) && (roll2 >= roll3) && (roll4 >= roll3))
            {
                ability = roll1 + roll2 + roll4;
            }
            else if ( (roll1 >= roll2) && (roll3 >= roll2) && (roll4 >= roll2) )
            {
                ability = roll1 + roll3 + roll4;
            }
            else if( (roll2 >= roll1) && (roll3 >= roll1) && (roll4 >= roll1) )
            {
                ability = roll2 + roll3 + roll4;
            }

            return ability;
        }
    }

    public interface IMenu
    {
        void displayMenu(Race r);
    }


    abstract class DnDCharacter : IMenu
    {
        //Character Info/Stats
        public string name;
        public int age;
        public int level = 1;

        public string characterClass = "";

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

        public Gender sex;
        public SizeCategory size;
        public Race race;
        public SubRace subRace;

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
                    subRace = SubRace.NA;
                    break;

                case 5:
                    race = Race.Dragonborn;
                    str = str + 2;//Strength score increase
                    cha = cha + 1;//Charisma score increase
                    size = SizeCategory.Medium;
                    speed = 30;//Base walking speed
                    languagesKnown = "Common and Draconic";
                    subRace = SubRace.NA;
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
                    subRace = SubRace.NA;

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
                    subRace = SubRace.NA;

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
                    subRace = SubRace.NA;
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
            characterClass = "Barbarian";
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
            characterClass = "Bard";
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
            characterClass = "Cleric";
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
            characterClass = "Druid";
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
            characterClass = "Fighter";
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
            characterClass = "Monk";
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
            characterClass = "Paladin";
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
            characterClass = "Ranger";
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
            characterClass = "Rogue";
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
            characterClass = "Sorcerer";
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
            characterClass = "Warlock";
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
            characterClass = "Wizard";
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
