/// created by : Michael
/// date       : 
/// description: A basic text adventure game engine

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostV2
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();  //creates a random number generator

        int scene = 0;  // tracks what part of the game the user is at
        bool invisPot = false;
        bool cloak = false;
        bool amulet = false;
        bool lockpicks = false;
        bool skeletons = true;
        bool armorySecretSeen = false;
        int scene3Trap;
        int trapSurvive;
        int prisonDoor;
        int armoryDoor;
        int armorySecretChance;


        public Form1()
        {
            InitializeComponent();

            scene3Trap = rnd.Next(1, 2); //THIS IS JUST SO THAT I CAN TEST EASILY NEED TO CHANGE TO (1, 11) I REALLY HOPE I REMEMBER TO CHANGE IT
            trapSurvive = rnd.Next(1, 4);
            prisonDoor = rnd.Next(1, 5);
            armoryDoor = rnd.Next(1, 5);
            armorySecretChance = rnd.Next(1, 3);

            //display initial message and options
            outputLabel.Text = "You are an adventurer passing through the town of Phandalin. While at the general store, the owner mentioned some trouble the town had been having with a local gang called the Redbrands, who are led by a wizard named Glasstaff. He asks if you could help out. You agree, and have managed to track them to Tresandar Manor. After investigating the ruins, you find a cellar.";
            roomLabel.Text = "Tresandar Ruins";
            blueLabel.Text = "Enter the cellar";
            redLabel.Text = "Don't enter the cellar";
            yellowLabel.Text = "";
            greenLabel.Text = "";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            actionOutputLabel.Text = "";

            /// check to see what button has been pressed and advance
            /// to the next appropriate scene
            if (e.KeyCode == Keys.M)           //red button press
            {
                switch (scene)
                {
                    case 0:
                        actionOutputLabel.Text = "Don't be a bitch";
                        break;
                    case 1:
                        actionOutputLabel.Text = "You find nothing useful in the barrels. You made so much noise that the thugs in the next room heard you. They sneak up behind you and smash a barrel over your head, killing you instantly.";
                        scene = 20;
                        break;
                    case 2:
                        actionOutputLabel.Text = "You find nothing useful";
                        break;
                    case 3:
                        if (scene3Trap == 1)
                        {
                            actionOutputLabel.Text = "You enter the doors, avoiding the pitfall";
                            scene = 4;
                        }
                        break;
                    case 4:
                        if(skeletons)
                        {
                            actionOutputLabel.Text = "As you approach the door, you hear some creaking behind you. You turn around to see that the skeletons have stood up. They cut you to ribbons";
                            scene = 20;
                        }
                        else
                        {
                            actionOutputLabel.Text = "You enter the eastern door";
                            scene = 5;
                        }
                        break;
                    case 5:
                        if (prisonDoor == 1)
                        {
                            actionOutputLabel.Text = "You throw all your weight into the door, but you cant get it open";
                        }
                        else
                        {
                            actionOutputLabel.Text = "You manage to get the doors open. You tell the prisoners how to escape, and warn them about the trap in the hallway";
                        }
                        break;
                    case 6:
                        if (armoryDoor == 1)
                        {
                            actionOutputLabel.Text = "You throw all of you weight into the door, and manage to break through into the next room";
                            scene = 7;
                        }
                        else if (armorySecretChance == 1)
                        {
                            actionOutputLabel.Text = "You throw all of your weight into the door, but are unable to break though. However, while you were struggling to get it open, you found a secret door right beside it";
                            armorySecretSeen = true;
                        }
                        else
                        {
                            actionOutputLabel.Text = "You throw all of your weight into the door, but are unable to break though";
                        }
                        break;
                    case 7:
                        if (!cloak)
                        {
                            actionOutputLabel.Text = "You put on a cloak";
                            cloak = true;
                            UpdateInv();
                        }
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    default:
                        break;
                }

            }
            else if (e.KeyCode == Keys.B)      //blue button press
            {
                switch (scene)
                {
                    case 0:
                        actionOutputLabel.Text = "You enter the cellar";
                        scene = 1;
                        break;
                    case 1:
                        actionOutputLabel.Text = "You enter the western door";
                        scene = 2;
                        break;
                    case 2:
                        if(!lockpicks)
                        {
                            actionOutputLabel.Text = "You take the lockpicks";
                            lockpicks = true;
                            UpdateInv();
                        }
                        break;
                    case 3:
                        if (trapSurvive == 1)
                        {
                            actionOutputLabel.Text = "As you walk down the hall, the floor falls away beneath you. Luckily, you manage to grab the edge to avoid falling in. You continue through the doors";
                            scene = 4;
                        }
                        else
                        {
                            actionOutputLabel.Text = "As you walk down the hall, the floor falls away beneath you. You attempt to grab the ledge, but you miss. You fall into the pit, and are impaled on a large spike";
                            scene = 20;
                        }
                        break;
                    case 4:
                        actionOutputLabel.Text = "You notice that while the skeletons appear to have been there for years, their swords are razor sharp, and unrusted. You also notice a strange rune and the back of each skeleton's head. You recognize the rune as an arcane symbol used to reanimate the dead. You crush all three skulls, just to be safe";
                        skeletons = false;
                        break;
                    case 5:
                        if (lockpicks)
                        {
                            actionOutputLabel.Text = "You pick the lock and get the door open. You tell the prisoners how to escape, and warn them about the trap in the hallway";
                        }
                        break;
                    case 6:
                        if (lockpicks)
                        {
                            actionOutputLabel.Text = "You pick the lock and get the door open. You go inside";
                            scene = 7;
                        }
                        break;
                    case 7:
                        if (!amulet)
                        {
                            actionOutputLabel.Text = "You put on the amulet";
                            amulet = true;
                            UpdateInv();
                        }
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    default:
                        break;
                }
            }
            else if (e.KeyCode == Keys.N)      //yellow button press
            {
                switch (scene)
                {
                    case 0:
                        break;
                    case 1:
                        actionOutputLabel.Text = "You enter the northern door";
                        scene = 3;
                        break;
                    case 2:
                        if(!cloak)
                        {
                            actionOutputLabel.Text = "You put on a cloak";
                            cloak = true;
                            UpdateInv();
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        actionOutputLabel.Text = "You enter the northern door";
                        scene = 6;
                        break;
                    case 5:
                        break;
                    case 6:
                        if (armorySecretSeen)
                        {
                            actionOutputLabel.Text = "You enter the secret door";
                            scene = 8;
                        }
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    default:
                        break;
                }
            }
            else if (e.KeyCode == Keys.Space)  //green button press
            {
                switch (scene)
                {
                    case 0:
                        break;
                    case 1:
                        if (!invisPot)
                        {
                            actionOutputLabel.Text = "You find a waterproof satchel hidden inside. Within, you find a small vial labeled \"Potion of Invisibility\". You take it.";
                            invisPot = true;
                            UpdateInv();
                        }
                        break;
                    case 2:
                        actionOutputLabel.Text = "You return to the cellar";
                        scene = 1;
                        break;
                    case 3:
                        actionOutputLabel.Text = "You return to the cellar";
                        scene = 1;
                        break;
                    case 4:
                        actionOutputLabel.Text = "You return to the trapped hallway";
                        scene = 3;
                        break;
                    case 5:
                        actionOutputLabel.Text = "You return to the crypts";
                        scene = 4;
                        break;
                    case 6:
                        actionOutputLabel.Text = "You return to the crypts";
                        scene = 4;
                        break;
                    case 7:
                        actionOutputLabel.Text = "You return to the armory hallway";
                        scene = 6;
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    default:
                        break;
                }
            }

            /// Display text and game options to screen based on the current scene
            switch (scene)
            {
                case 0:  //start scene  
                    outputLabel.Text = "You are an adventurer passing through the town of Phandalin. While at the general store, the owner mentioned some trouble the town had been having with a local gang called the Redbrands, who are led by a wizard named Glasstaff. He asks if you could help out. You agree, and have managed to track them to Tresandar Manor. After investigating the ruins, you find a cellar.";
                    roomLabel.Text = "Tresandar Ruins";
                    blueLabel.Text = "Enter the cellar";
                    redLabel.Text = "Don't enter the cellar";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    break;
                case 1:
                    if (!invisPot)
                    {
                        greenLabel.Text = "Search the cistern";
                    }
                    outputLabel.Text = "The door opens onto a five-foot-wide landing fifteen feet above a large cellar, with stone steps descending to the floor in two short flights. There is a door on the western wall, while another door stands beneath the stairs to the north. A large stone cistern occupies the western part of the room, whose walls are lined with kegs and barrels.";
                    roomLabel.Text = "Cellar";
                    blueLabel.Text = "Go west";
                    redLabel.Text = "Search the barrels";
                    yellowLabel.Text = "Go north";

                    break;
                case 2:
                    if (!lockpicks)
                    {
                        blueLabel.Text = "Take the lockpicks";
                    }
                    else
                    {
                        blueLabel.Text = "";
                    }
                    if(!cloak)
                    {
                        yellowLabel.Text = "Put on a cloak";
                    }
                    else
                    {
                        yellowLabel.Text = "";
                    }
                    outputLabel.Text = "This appears to be a storeroom pressed into service as living quarters. Two double bunks stand against the wall near the door, while barrels and crates fill the southern half of the chamber. There are 3 dirty scarlet cloaks hanging up on the bunks, and a set of lockpicks on top of a nearby crate.";
                    roomLabel.Text = "Barracks";
                    redLabel.Text = "Search the barrels";
                    greenLabel.Text = "Return the the cellar";
                    break;
                case 3:
                    if (scene3Trap == 1)
                    {
                        outputLabel.Text = "Thick dust covers the flagstones of this somber hallway. The walls are decorated with faux columns every ten feet, and the double doors at the west end of the hall are sheathed in copper plate, now green with age. A relief carving of a mournful angel graces the doors. You notice that a section of the floor about halfway down is a slightly different color. You figure this is a trap, so you think its best to avoid it.";
                        roomLabel.Text = "Crypt Hallway";
                        blueLabel.Text = "Enter the double doors";
                        redLabel.Text = "Avoid the trap";
                        yellowLabel.Text = "";
                        greenLabel.Text = "Return to the cellar";
                    }
                    else
                    {
                        outputLabel.Text = "Thick dust covers the flagstones of this somber hallway. The walls are decorated with faux columns every ten feet, and the double doors at the west end of the hall are sheathed in copper plate, now green with age. A relief carving of a mournful angel graces the doors.";
                        roomLabel.Text = "Crypt Hallway";
                        blueLabel.Text = "Enter the double doors";
                        redLabel.Text = "";
                        yellowLabel.Text = "";
                        greenLabel.Text = "Return to the cellar";
                    }
                    break;
                case 4:
                    trapSurvive = 1;
                    outputLabel.Text = "Three large stone sarcophagi stand within this dusty crypt, and propped up against each sarcophagus is a human skeleton clad in bits of rusty mail. False columns along the walls are carved in the image of spreading oak trees. There is a door on the northern wall, and a door on the eastern wall.";
                    roomLabel.Text = "Crypts";
                    blueLabel.Text = "Investigate the skeletons";
                    redLabel.Text = "Go east";
                    yellowLabel.Text = "Go north";
                    greenLabel.Text = "Return to the crypt hallway";
                    break;
                case 5:
                    if(lockpicks)
                    {
                        blueLabel.Text = "Pick the cell doors";
                    }
                    else
                    {
                        blueLabel.Text = "";
                    }
                    outputLabel.Text = "This long room is partitioned into three areas, with iron bars walling off the north and south. Filthy straw lines the floors of those cells, the hinged doors of which are secured by chains and padlocks. A pair of disheveled human women are held in the cell to the south, while a human boy is confined to the north. All are dressed in plain gray tunics and have iron collars fitted around their necks. A heap of discarded clothing is piled carelessly against the far wall.";
                    roomLabel.Text = "Prison";
                    redLabel.Text = "Try to force the cell doors";
                    yellowLabel.Text = "";
                    greenLabel.Text = "Return to the crypts";
                    break;
                case 6:
                    if(lockpicks)
                    {
                        blueLabel.Text = "Pick the lock";
                    }
                    else
                    {
                        blueLabel.Text = "";
                    }
                    if (armorySecretSeen)
                    {
                        yellowLabel.Text = "Enter the secret door";
                    }
                    else
                    {
                        yellowLabel.Text = "";
                    }
                    outputLabel.Text = "The door leads to a 15 foot long hallway. At the end of it is a locked door.";
                    roomLabel.Text = "Armory Hallway";
                    redLabel.Text = "Try to force the door";
                    greenLabel.Text = "Return to the armory hallway";
                    break;
                case 7:
                    if (!cloak)
                    {
                        redLabel.Text = "Put on a cloak";
                    }
                    else
                    {
                        redLabel.Text = "";
                    }
                    if (!amulet)
                    {
                        blueLabel.Text = "Put on the necklace";
                    }
                    else
                    {
                        blueLabel.Text = "";
                    }
                    outputLabel.Text = "Racks of weapons line the walls of this chamber, including spears, swords, crossbows, and bolts. A dozen dirty red cloaks hang from hooks by the door. On a pedestal at the end of the room is a necklace. A sign under it reads \"Necklace of Discerning\"";
                    roomLabel.Text = "Armory";
                    yellowLabel.Text = "";
                    greenLabel.Text = "Return to the armory hallway";
                    break;
                case 8:
                    outputLabel.Text = "This area is the north end of a large natural cavern, but it has been finished with dressed stone block walls and a flagstone floor. Several barrels are stored against the walls here, along with a number of empty crates, straw for packing, hammers, pry bars, and nails. The cavern continues for some distance to the south. You can make out several passages that open up off the larger cavern, and what looks like a deep pit or crevasse in the floor.";
                    roomLabel.Text = "Storeroom";
                    blueLabel.Text = "Search the barrels";
                    redLabel.Text = "Enter the secret door";
                    yellowLabel.Text = "Go south";
                    greenLabel.Text = "Return to the armory hallway";
                    break;
                case 9:
                    outputLabel.Text = "A cold breeze fills this large natural cavern, carrying with it the faint scent of decaying flesh. A crevasse divides the cavern and is flanked by two rough stone columns that support the twenty-foot-high ceiling. Two arched wooden bridges span the chasm. There are two hallways on the other side of the chasm. Both lead towards the east, one to the north and one to the south.";
                    roomLabel.Text = "Crevasse";
                    blueLabel.Text = "Go north";
                    redLabel.Text = "Go east";
                    yellowLabel.Text = "Go south";
                    greenLabel.Text = "Return to the storeroom";
                    break;
                case 10:
                    outputLabel.Text = "This barracks contains four roughly built wooden bunks, with heaped-up blankets and dirty dishes scattered about. A strong smell of unwashed bodies and rotten meat fills the air. Three tall, furry humanoids are lounging among the mess.";
                    roomLabel.Text = "Guard Barracks";
                    blueLabel.Text = "";
                    redLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "Return to crevasse";
                    break;
                case 11:
                    outputLabel.Text = "Several worn tables and chairs are scattered around this large room. Wooden benches are drawn up against walls decorated with draperies of brown and red, and several ale kegs are propped up and tapped. Four tough-looking human warriors wearing scarlet cloaks are gathered around one of the tables. A stack of coins and trinkets is heaped upon the tabletop between them.";
                    roomLabel.Text = "Common Room";
                    blueLabel.Text = "";
                    redLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "Return to crevasse";
                    break;
                case 12:
                    outputLabel.Text = "This room appears to be a wizard's workshop. A rat scurries across the floor and takes refuge under a large worktable set up with alembics, retorts, distillation coils, and other alchemical devices, all of it stewing and bubbling away. Bookshelves are crowded with sheaves of parchment and strange-looking tomes. There is a door along the eastern wall.";
                    roomLabel.Text = "Wizard's Workshop";
                    blueLabel.Text = "Go east";
                    redLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "Return to crevasse";
                    break;
                case 13:
                    outputLabel.Text = "The walls of this bedchamber are covered with drapes of scarlet cloth. The furnishings include a small writing desk with matching chair, a comfortable-looking bed, and a wooden chest at the foot of the bed. The chest is open, and mostly empty, as if someone in a rush had grabbed the contents and fled. There is a secret door slightly ajar on the opposite side of the room. Upon investigation, the passage leads back to the storeroom. It appears that glasstaff has fled.";
                    roomLabel.Text = "Glasstaff's Quarters";
                    blueLabel.Text = "";
                    redLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    break;
                default:
                    outputLabel.Text = "You died. Sucks to suck.";
                    roomLabel.Text = "";
                    blueLabel.Text = "";
                    redLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    break;
            }
        }

        public void UpdateInv()
        {
            string outputString = "";

            if (cloak) 
            {
                outputString += "Cloak\n";
            }
            if (lockpicks)
            {
                outputString += "Lockpicks\n";
            }
            if (invisPot)
            {
                outputString += "Potion of Invisibility\n";
            }
            if (amulet)
            {
                outputString += "Amulet of Discerning\n";
            }

            invLabel.Text =  outputString;
        }

    }

}
