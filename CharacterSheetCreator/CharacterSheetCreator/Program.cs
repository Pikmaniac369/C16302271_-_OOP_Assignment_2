using System;
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


    //Abstract classes for DnDClasses and DnDRaces:
    //-----------------------------------------------
    abstract class DndClass
    {

    }

    abstract class DnDCharacter
    {
        private string name;
        private int age;
        Gender sex;
        SizeCategory size;
        Race race;
        private int str;//Strength ability score
        private int dex;//Dexterity ability score
        private int con;//Constitution ability score
        private int inte;//Intelligence ability score
        private int wis;//Wisdom ability score
        private int cha;//Charisma ability score

        public static int numOfCharacters = 0;

        //DON'T LET THIS BE CALLED IF ANY NUMBER OTHER THAN THE RACE ONES ARE CHOSEN!!!!!!!!!!!!!!!
        public void createCharacter(string namae, int anni, bool morf, int selectedRace)
        {
            //Set the character's name and age:
            name = namae;
            age = anni;

            //What is the character's gender?
            if (morf == true)
            {
                sex = Gender.Male;
            }
            else if (morf == false)
            {
                sex = Gender.Female;
            }

            //What race is the character?
            switch (selectedRace)
            {
                case 1:
                    race = Race.Dwarf;
                    break;

                case 2:
                    race = Race.Elf;
                    break;

                case 3:
                    race = Race.Halfling;
                    break;

                case 4:
                    race = Race.Human;
                    break;

                case 5:
                    race = Race.Dragonborn;
                    break;

                case 6:
                    race = Race.Gnome;
                    break;

                case 7:
                    race = Race.Half_Elf;
                    break;

                case 8:
                    race = Race.Half_Orc;
                    break;

                case 9:
                    race = Race.Tiefling;
                    break;
            }

            numOfCharacters++;

            /*switch(race)
            {
                case Race.Dwarf:
                    break;

                case Race.Elf:
                    break;

                case Race.Halfling:
                    break;

                case Race.Human:
                    break;

                case Race.Dragonborn:
                    break;

                case Race.Gnome:
                    break;

                case Race.Half_Elf:
                    break;

                case Race.Half_Orc:
                    break;

                case Race.Tiefling:
                    break;
            }*/
        }

        public static int getNumOfCharacters()
        {
            return numOfCharacters;
        }
    }


    public interface IHitPointRoller
    {

    }


    //DnD CLASSES:
    //----------------------------------------------
    class Barbarian : DnDCharacter, IHitPointRoller
    {

    }

    class Bard : DnDCharacter, IHitPointRoller
    {

    }

    class Cleric : DnDCharacter, IHitPointRoller
    {

    }

    class Druid : DnDCharacter, IHitPointRoller
    {

    }

    class Fighter : DnDCharacter, IHitPointRoller
    {

    }

    class Monk : DnDCharacter, IHitPointRoller
    {

    }

    class Paladin : DnDCharacter, IHitPointRoller
    {
        
    }

    class Ranger : DnDCharacter, IHitPointRoller
    {

    }

    class Rogue : DnDCharacter, IHitPointRoller
    {

    }

    class Sorcerer : DnDCharacter, IHitPointRoller
    {

    }

    class Warlock : DnDCharacter, IHitPointRoller
    {

    }

    class Wizard : DnDCharacter, IHitPointRoller
    {

    }


    
}
