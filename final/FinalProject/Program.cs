using System;
using System.Text.Json;
using static DeluxeConsole;
class Program
{
    static void Main(string[] args)
    {
        Campaign campaign = new Campaign();

        int menuDecision = 0;
        while (menuDecision != 7)
        {
            Console.Clear();
            try
            {
                WriteLineDeluxe("Select an action to perform:\n   1. Make a character\n   2. Make an enemy\n   3. Fight enemies\n   4. View your party's stats\n   5. Save your campaign\n   6. Load a campaign\n   7. Quit", 3);
                menuDecision = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                menuDecision = 0;
            }

            if (menuDecision == 1)
            {
                campaign.MakeCharacter();
                DisplaySpinner(3);
            }
            else if (menuDecision == 2)
            {
                campaign.MakeEnemy();
                DisplaySpinner(3);
            }
            else if (menuDecision == 3)
            {
                Battlefield battlefield = new Battlefield(campaign.GetCharacters(), campaign.GetEnemies());
                
                battlefield.Battle();
            }
            else if (menuDecision == 4)
            {
                campaign.ViewParty();
                WriteLineDeluxe("\nEnter anything to go back.");
                Console.ReadLine();
            }
            else if (menuDecision == 5)
            {
                campaign.SaveCharacters();
                DisplaySpinner(3);
            }
            else if (menuDecision == 6)
            {
                campaign.LoadCharacters();
                DisplaySpinner(3);
            }
            else if (menuDecision == 7)
            {
                Console.WriteLine("\nHave a great day!");
                DisplaySpinner(2);
            }
        }
    }
}