using ProbabilityCalculator.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityCalculator
{
    class Program
    {
         

        static void Main(string[] args)
        {
            //Method to display the menu.
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        #region "Methods"
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an method:");
            Console.WriteLine("1) Probability for independent events P(A)P(B).");
            Console.WriteLine("2) Probability for non-mutual exclusive events P(A)+ P(B)-P(A).P(B).");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    TakeInputs("1");
                    return true;
                case "2":
                    TakeInputs("2");
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        private static void TakeInputs(string choice)
        {
            ArrayList list = new ArrayList();
            Console.WriteLine("Please enter the number of events.");
            string number = Console.ReadLine();
            StringBuilder writeToFile;
            writeToFile = new StringBuilder();
            int NoofInputs;
            bool parseSuccess = int.TryParse(number, out NoofInputs);
            if (parseSuccess)
            {
                if(Convert.ToInt32(number) == 1)
                {
                    Console.WriteLine("Please enter atleast 2 events.\n");
                    TakeInputs(choice);
                    return;
                }
            }
            if (parseSuccess)
            {
                int count = 1;
                while (count <= Convert.ToInt32(number))
                {
                    Console.WriteLine("Please enter probability for event {0}", count);
                    string floatinput = Console.ReadLine();
                    float NoofInput;
                    parseSuccess = float.TryParse(floatinput, out NoofInput);
                    if (parseSuccess)
                    {
                        if (Convert.ToSingle(floatinput) < 1 && Convert.ToSingle(floatinput) > 0)
                        {
                            list.Add(Convert.ToSingle(floatinput));
                            count++;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nProbability should be between 1 and 0..\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input.");
                    }
                }
                if (choice == "1")
                {
                    Probability objProbability = new Probability();
                    if (list.Count == 2)
                    {
                        objProbability.eventX = Convert.ToSingle(list[0]);
                        objProbability.eventY = Convert.ToSingle(list[1]);
                        objProbability.Multiply();
                        Console.Clear();
                        Console.WriteLine("Probability of independent events {0},{1} is {2}", list[0], list[1], objProbability.Multiply());
                        Console.WriteLine("\n Press enter to continue....");
                        writeToFile.Append("\n Input variable == " + list[0]);
                        writeToFile.Append("\n Input variable == " + list[1]);
                        writeToFile.Append("\nP(A)+P(B) ==" + objProbability.Multiply());
                        WriteFile(Convert.ToString(writeToFile));
                    }
                    else
                    {
                        objProbability.eventX = Convert.ToSingle(list[0]);
                        objProbability.eventY = Convert.ToSingle(list[1]);
                        writeToFile.Append("\n Input variable == " + list[0]);
                        writeToFile.Append("\n Input variable == " + list[1]);
                        ProbabilityWrapper A = new ProbabilityWrapper();
                        for (int Index = 2; Index < list.Count; Index++)
                        {
                            A.SetComponent(objProbability);
                            objProbability.eventX = A.Multiply();
                            objProbability.eventY = Convert.ToSingle(list[Index]);
                            writeToFile.Append("\nInput variable == " + list[Index]);
                            
                        }
                        Console.Clear();
                        Console.WriteLine("Probability of independent events {0},{1} is {2}", list[0], list[1], objProbability.Multiply());
                        Console.WriteLine("\n Press enter to continue....");
                        writeToFile.Append("\nP(A)+P(B) ==" + objProbability.Multiply());
                        WriteFile(Convert.ToString(writeToFile));
                    }
                    
                }
                if (choice == "2")
                {
                    Probability objProbability = new Probability();
                    if (list.Count == 2)
                    {
                        objProbability.eventX = Convert.ToSingle(list[0]);
                        objProbability.eventY = Convert.ToSingle(list[1]);
                        writeToFile.Append("\n Input variable == " + list[0]);
                        writeToFile.Append("\n Input variable == " + list[1]);
                        Console.Clear();
                        Console.WriteLine("Probability of mutually exclusive events {0},{1} is {2}", list[0], list[1], objProbability.Calculate());
                        Console.WriteLine("\n Press enter to continue....");
                        writeToFile.Append("\nP(A)+P(B)-P(A).P(B) ==" + objProbability.Calculate());
                        WriteFile(Convert.ToString(writeToFile));
                    }
                    else
                    {
                        objProbability.eventX = Convert.ToSingle(list[0]);
                        objProbability.eventY = Convert.ToSingle(list[1]);
                        writeToFile.Append("\n Input variable == " + list[0]);
                        writeToFile.Append("\n Input variable == " + list[1]);
                        ProbabilityWrapper Wrapper = new ProbabilityWrapper();
                        Wrapper.SetComponent(objProbability);
                        for (int Index = 2; Index < list.Count; Index++)
                        {
                            objProbability.eventX = Wrapper.Calculate();
                            objProbability.eventY = Convert.ToSingle(list[Index]);
                            Wrapper.SetComponent(objProbability);
                            writeToFile.Append("\n Input variable == " + list[Index]);
                        }
                        Console.Clear();
                        Console.WriteLine("Probability of mutually exclusive is {0}", Wrapper.Calculate());
                        Console.WriteLine("\n Press enter to continue....");
                        writeToFile.Append("\nP(A)+P(B)-P(A).P(B) ==" + objProbability.Calculate());
                        WriteFile(Convert.ToString(writeToFile));
                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please provide an valid number.");
                TakeInputs(choice);
            }
        }
        public static void WriteFile(string message)
        {
            string appDirectory = Path.Combine(Environment.CurrentDirectory) + "\\" + "Log";
            if (!Directory.Exists(appDirectory))
            {
                Directory.CreateDirectory("Log");
            }
            string fileName = appDirectory + "\\" + "Log_" + DateTime.Today.ToString("MM/dd/yyyy") + ".txt";
            FileInfo file = new FileInfo(fileName);
            try
            {
                if (!file.Exists)
                {
                    using (StreamWriter stream = file.CreateText())
                    {
                        stream.WriteLine("Date Time : " + DateTime.Now.ToString());
                        stream.WriteLine(message);
                        stream.WriteLine("===============");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine("Date Time : " + DateTime.Now.ToString());
                        sw.WriteLine(message + "\n\n");
                        sw.WriteLine("===============");
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        #endregion
    }
}
