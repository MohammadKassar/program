using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        bool isRunning = true;
        // start a while loop that continues until isRunning is set to false (user entering 0) 

        while (isRunning)
        {
            // display the main menu options to the user
            Console.WriteLine("Main Menu");
            Console.WriteLine("0. Exit the program");
            Console.WriteLine("1. Entrance price depends on age");
            Console.WriteLine("2. Calculate total cost for group");
            Console.WriteLine("3. Repeat ten times");
            Console.WriteLine("4. The third word");
            Console.Write("Please choose an option (0-4): ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                //cases, method 1/2/3/4 or 0 false (to exit the program) or default line 46 : display an error message with invalid input (not 0 to 4)
                case "0":
                    isRunning = false;
                    break;

                case "1":
                    CheckDiscount();
                    break;

                case "2":
                    CalculateGroupCost();
                    break;

                case "3":
                    RepeatTenTimes();
                    break;

                case "4":
                    GetTheThirdWord();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    break;
            }
        }
    }


    //case 1
    static void CheckDiscount()
    {
        Console.Write("Enter your age: ");
        string ageUserInput = Console.ReadLine();
        // Use tryparse to handle invalid age input not int, else line 80 for error message to user for invalid input 
        if (int.TryParse(ageUserInput, out int age))
        //or int age = int.Parse(Console.ReadLine() but im this way cant make sure the program will not crush 
        {
            // if else and print a different message for each age group
            if (age < 20)
            {
                Console.WriteLine("Youth Price: $80");
            }
            else if (age > 64)
            {
                Console.WriteLine("Pensioner Price: $90");
            }
            else if (age > 100 || age < 5)
            {
                Console.WriteLine("Children Under 5 and Pensioner Over 100 are free");
            }
            else
            {
                Console.WriteLine("Standard Price: $120");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid age as a number.");
        }
    }



    // case 2 
    static void CalculateGroupCost()
    {
        Console.Write("Enter the number of people in the group: ");
        // Use itryparse to handle invalid number of people input / else line 134 for error message to user for invalid input 
        if (int.TryParse(Console.ReadLine(), out int numberOfPeople))
        {
            int totalCost = 0;
            int youthCount = 0;
            int pensionerCount = 0;
            int standardCount = 0;
            int childAndFreeCount = 0;

            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.Write($"Enter age for person {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int age)) // else line 128 for error message to user for invalid input 
                {
                    //Check the age and update the total cost and counts
                    if (age < 20)
                    {
                        totalCost += 80;
                        youthCount++;
                    }
                    else if (age > 64)
                    {
                        totalCost += 90;
                        pensionerCount++;
                    }
                    else if (age > 100 || age < 5)
                    {
                        childAndFreeCount++;
                    }
                    else
                    {
                        totalCost += 120;
                        standardCount++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid age as a number.");
                    i--; // Repeat the loop for the same person to get valid input (1-- took me an hour to figure it out )
                }
            }
            // line 136 to 139 EXTRA just to know how many ticket are sold in each group.condition line 111 116 125
            Console.WriteLine($"Total cost for the group: ${totalCost}");
            Console.WriteLine($"Youth count: {youthCount}");
            Console.WriteLine($"Pensioner count: {pensionerCount}");
            Console.WriteLine($"Standard count: {standardCount}");
            Console.WriteLine($"Children and Free count: {childAndFreeCount}");
        }
        else
        {
            Console.WriteLine("Invalid number of people. Please enter a valid number.");
        }
    }

    static void RepeatTenTimes()
    {
        Console.Write("Enter text: ");
        string userInput = Console.ReadLine();

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i}. {userInput}");
        }
    }

    static void GetTheThirdWord()
    {
        Console.Write("Enter a sentence with at least 3 words: ");
        string userInput = Console.ReadLine();
        // array of strings named words. split the sentence into words using the space 
        string[] words = userInput.Split(' ');

        if (words.Length >= 3)
        {
            // get the third word from the array 
            string thirdWord = words[2]; //(array start from 1=0 - 2=1 - 3=2)
            Console.WriteLine($"The third word is: {thirdWord}");
        }
        else
        {
            Console.WriteLine("The sentence must contain at least 3 words.");
        }
    }
}
