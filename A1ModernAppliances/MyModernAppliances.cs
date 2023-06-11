using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System;
using System.IO;
using System.Collections.Generic;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumber;

            // Get user input as string and assign to variable.
            string itemin = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            itemNumber = long.Parse(itemin);
            Appliance foundAppliance = null;
            foreach(Appliance appliance in Appliances){
                if(appliance.ItemNumber == itemNumber){
                    foundAppliance = appliance;
                    break;
                }
            }

            if(foundAppliance == null){
                Console.WriteLine("No appliances found with that item number.");
            }

            else{
                if(foundAppliance.IsAvailable){
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else{
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
                // Test appliance item number equals entered item number
                    // Assign appliance in list to foundAppliance variable

                    // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
                // Write "No appliances found with that item number."

            // Otherwise (appliance was found)
                // Test found appliance is available
                    // Checkout found appliance

                    // Write "Appliance has been checked out."
                // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for:");

            string brand = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliance.Brand == brand){
                    foundAppliances.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundAppliances,0);

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.

            // Create list to hold found Appliance objects

            // Iterate through loaded appliances
                // Test current appliance brand matches what user entered
                    // Add current appliance in list to found list


            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"

            // Write "Enter number of doors: "
            Console.WriteLine("Possible options:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t2 - Double doors");
            Console.WriteLine("\t3 - Three doors");
            Console.WriteLine("\t4 - Four doors");
            Console.WriteLine("Enter number of doors: ");

            int ndoors = int.Parse(Console.ReadLine());

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliance.Type == Appliance.ApplianceTypes.Refrigerator){
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if(ndoors == 0 || ndoors == refrigerator.Doors){
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances,0);

            // Create variable to hold entered number of doors

            // Get user input as string and assign to variable

            // Convert user input from string to int and store as number of doors variable.

            // Create list to hold found Appliance objects

            // Iterate/loop through Appliances
                // Test that current appliance is a refrigerator
                    // Down cast Appliance to Refrigerator
                    // Refrigerator refrigerator = (Refrigerator) appliance;

                    // Test user entered 0 or refrigerator doors equals what user entered.
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"
            Console.WriteLine("Possible options:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t1 - Residential");
            Console.WriteLine("\t2 - Commercial");
            Console.WriteLine("Enter grade: ");

            string gradeinput = Console.ReadLine();
            string grade;

            if(gradeinput == "0"){
                grade = "Any";
            }
            else if(gradeinput == "1"){
                grade = "Residential";
            }
            else if(gradeinput == "2"){
                grade = "Commercial";
            }
            else{
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t1 - 18 Volt");
            Console.WriteLine("\t2 - 24 Volt");
            Console.WriteLine("Enter voltage: ");

            string voltinput = Console.ReadLine();

            int voltage;

            if(voltinput == "0"){
                voltage = 0;
            }
            else if(voltinput == "1"){
                voltage = 18;
            }
            else if(voltinput == "2"){
                voltage = 24;
            }
            else{
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliance.Type == Appliance.ApplianceTypes.Vacuum){
                    Vacuum vacuum = (Vacuum)appliance;
                    if((grade == "Any" || grade == vacuum.Grade) && (voltage == 0 || voltage == vacuum.BatteryVoltage)){
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances,0);

            // Get user input as string and assign to variable

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)

            // Test input is "0"
                // Assign "Any" to grade
            // Test input is "1"
                // Assign "Residential" to grade
            // Test input is "2"
                // Assign "Commercial" to grade
            // Otherwise (input is something else)
                // Write "Invalid option."

                // Return to calling (previous) method
                // return;

            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"

            // Get user input as string
            // Create variable to hold voltage

            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.

            // Loop through Appliances
                // Check if current appliance is vacuum
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"

            Console.WriteLine("Possible options:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t1 - Kitchen");
            Console.WriteLine("\t2 - Work site");
            Console.WriteLine("Enter room type:");

            string roominput = Console.ReadLine();

            char roomType;

            if(roominput == "0"){
                roomType = 'A';
            }
            else if(roominput == "1"){
                roomType = 'K';
            }
            else if(roominput == "2"){
                roomType = 'W';
            }
            else{
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliance.Type == Appliance.ApplianceTypes.Microwave){
                    Microwave microwave = (Microwave)appliance;
                    if(roomType == 'A' || roomType == microwave.RoomType){
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances,0);

            // Get user input as string and assign to variable

            // Create character variable that holds room type

            // Test input is "0"
                // Assign 'A' to room type variable
            // Test input is "1"
                // Assign 'K' to room type variable
            // Test input is "2"
                // Assign 'W' to room type variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method
                // return;

            // Create variable that holds list of 'found' appliances

            // Loop through Appliances
                // Test current appliance is Microwave
                    // Down cast Appliance to Microwave

                    // Test room type equals 'A' or microwave room type
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"
            Console.WriteLine("Possible options:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t1 - Quietest");
            Console.WriteLine("\t2 - Quieter");
            Console.WriteLine("\t3 - Quiet");
            Console.WriteLine("\t4 - Moderate");
            Console.WriteLine("Enter sound rating:");

            string srinput = Console.ReadLine();

            string soundRating;

            if(srinput == "0"){
                soundRating = "Any";
            }
            else if(srinput == "1"){
                soundRating = "Qt";
            }
            else if(srinput == "2"){
                soundRating = "Qr";
            }
            else if(srinput == "3"){
                soundRating = "Qu";
            }
            else if(srinput == "4"){
                soundRating = "M";
            }
            else{
                Console.WriteLine("Invalid option.");
                return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliance.Type == Appliance.ApplianceTypes.Dishwasher){
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if(soundRating == "Any" || soundRating == dishwasher.SoundRating){
                        foundAppliances.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances,0);

            // Get user input as string and assign to variable

            // Create variable that holds sound rating

            // Test input is "0"
                // Assign "Any" to sound rating variable
            // Test input is "1"
                // Assign "Qt" to sound rating variable
            // Test input is "2"
                // Assign "Qr" to sound rating variable
            // Test input is "3"
                // Assign "Qu" to sound rating variable
            // Test input is "4"
                // Assign "M" to sound rating variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method

            // Create variable that holds list of found appliances

            // Loop through Appliances
                // Test if current appliance is dishwasher
                    // Down cast current Appliance to Dishwasher

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                        // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"
            Console.WriteLine("Appliance Types:");
            Console.WriteLine("\t0 - Any");
            Console.WriteLine("\t1 - Refrigerators");
            Console.WriteLine("\t2 - Vacuums");
            Console.WriteLine("\t3 - Microwaves");
            Console.WriteLine("\t4 - Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            string appliancetype = Console.ReadLine();

            Console.WriteLine("Enter number of appliances: ");
            int num = int.Parse(Console.ReadLine());

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance appliance in Appliances){
                if(appliancetype == "0"){
                    foundAppliances.Add(appliance);
                }
                else if(appliancetype == "1"){
                    if(appliance.Type == Appliance.ApplianceTypes.Refrigerator){
                        foundAppliances.Add(appliance);
                    }
                }
                else if(appliancetype == "2"){
                    if(appliance.Type == Appliance.ApplianceTypes.Vacuum){
                        foundAppliances.Add(appliance);
                    }
                }
                else if(appliancetype == "3"){
                    if(appliance.Type == Appliance.ApplianceTypes.Microwave){
                        foundAppliances.Add(appliance);
                    }
                }
                else if(appliancetype == "4"){
                    if(appliance.Type == Appliance.ApplianceTypes.Dishwasher){
                        foundAppliances.Add(appliance);
                    }
                }
            }

            foundAppliances.Sort(new RandomComparer());

            DisplayAppliancesFromList(foundAppliances,num);
            // Get user input as string and assign to appliance type variable

            // Write "Enter number of appliances: "

            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances

            // Loop through appliances
                // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                        // Add current appliance in list to found list
                // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                        // Add current appliance in list to found list
                // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                        // Add current appliance in list to found list
                // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                        // Add current appliance in list to found list

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
        }
    }
}
