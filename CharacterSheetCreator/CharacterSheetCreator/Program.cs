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

    struct DnDCharacter
    {
        private string name;
        private int age;
        Gender sex;
        SizeCategory size;
        Race race;
        private DndClass characterClass;
        
        //DON'T LET THIS BE CALLED IF ANY NUMBER OTHER THAN THE RACE ONES ARE CHOSEN!!!!!!!!!!!!!!!
        public void createCharacter(string namae, int anni, bool morf, int selectedRace)
        {
            //Set the character's name and age:
            name = namae;
            age = anni;

            //What is the character's gender?
            if(morf == true)
            {
                sex = Gender.Male;
            }
            else if(morf == false)
            {
                sex = Gender.Female;
            }

            //What race is the character?
            switch(selectedRace)
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
            Console.WriteLine("Welcome to my Dungeons & Dragons Character Sheet Creation tool!");
        }
    }


    //Abstract classes for DnDClasses and DnDRaces:
    //-----------------------------------------------
    abstract class DndClass
    {

    }

    abstract class DnDRace
    {
       
    }




    //DnD CLASSES:
    //----------------------------------------------
    class Barbarian : DndClass
    {

    }

    class Bard : DndClass
    {

    }

    class Cleric : DndClass
    {

    }

    class Druid : DndClass
    {

    }

    class Fighter : DndClass
    {

    }

    class Monk : DndClass
    {

    }

    class Paladin : DndClass
    {

    }

    class Ranger : DndClass
    {

    }

    class Rogue : DndClass
    {

    }

    class Sorcerer : DndClass
    {

    }

    class Warlock : DndClass
    {

    }

    class Wizard : DndClass
    {

    }




    /*
    //DnD RACES:
    //-------------------------------------------------
    class Dwarf : DnDRace
    {
        
    }

    class Elf : DnDRace
    {

    }

    class Halfling : DnDRace
    {

    }

    class Human : DnDRace
    {

    }

    class Dragonborn : DnDRace
    {

    }

    class Gnome : DnDRace
    {

    }

    class Half_Elf : DnDRace
    {

    }

    class Half_Orc : DnDRace
    {

    }

    class Tiefling : DnDRace
    {

    }
    */
}
