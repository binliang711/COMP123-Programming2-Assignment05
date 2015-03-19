/*
 * studentName:Bin Liang | studentNumber:300788322
 * Date last Modified:March 19th,2015
 * Program description:COMP123_Assignment05,Array Practice-Airline Reservations System.
 * Revision	History:
 * 1.Finish: a+b requirements of assignment.
 * 2.Finish c,d basic requirement
 * 3.Debugging successfully.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //need this in order to perform File I/O

namespace COMP123_Programming2_Assignment05
{
    class Program
    {
        static void Main(string[] args)
        {       
            MainMenu();
        }

        private static void MainMenu()
        {
            int selection = 0;

            while (selection != 2)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("+                              +");
                Console.WriteLine("+      1. Display grades       +");
                Console.WriteLine("+      2. Exit                 +");
                Console.WriteLine("+                              +");
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.Write("Please make your selection: ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception error1)
                {
                    selection = 0;
                    Console.WriteLine("You entered incorrect information");
                    Console.WriteLine(error1.Message);
                }

                switch (selection)
                {
                    case 1:
                        CheckFile();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect entry - Please try again");
                        Console.WriteLine();
                        WaitForKey();
                        break;
                }

                Console.Clear(); // Clears the screen
            }
        }

        private static void CheckFile()
        {
            string appDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string pathName = appDir;
            string fileName = "\\Data\\Grade.txt";
            string delimeter = " ";

            string prompt;
            Console.Write("Please enter a file name: ");

            try
            {
                prompt = Console.ReadLine();//Here, enter Grade.txt
                Console.WriteLine();
                if (File.Exists(prompt))
                {
                    Console.WriteLine("The File Exists");
                    Console.WriteLine();
                    ReadFileMethod(pathName, fileName, delimeter);
                }
                else
                {
                    File.Open("prompt", FileMode.Open);;
                }
            }
            catch (FileNotFoundException error2)
            {
                Console.WriteLine("The file does not exist");
                Console.WriteLine(error2.Message);
            }
            catch (IOException error3)
            {
                Console.WriteLine("The file can't be opened");
                Console.WriteLine(error3.Message);
            }
            
            WaitForKey();
        }

        private static void ReadFileMethod(string pathName, string fileName, string delimeter)
        {
            string fileData = "";
            string[] fileArray = new string[10];
            try
            {
                FileStream inFile = new FileStream(pathName + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                for (int row = 0; row < 5; row++)
                {
                    fileData = reader.ReadLine();
                    fileArray[row] = fileData;

                    Console.WriteLine("Your Data: {0}", fileData);
                } // Read one record (line of data)
                reader.Close(); // closes the file
                inFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("Your code caused a darn error!!!");
                Console.WriteLine("Error: {0} ", error.Message);
            }
        }

        // UTILITY METHODS
        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++Press any key to continue...+++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
