using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetCreator
{
    struct DnDCharacter
    {
        private string name;
        private int age;
        private DndClass characterClass;
        
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
}
