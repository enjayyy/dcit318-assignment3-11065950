using System;
using System.IO;

namespace GradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new StudentResultProcessor();
            string inputFile = "student.txt";   
            string outputFile = "report.txt";

            try
            {
                var students = processor.ReadStudentsFromFile(inputFile);
                processor.WriteReportToFile(students, outputFile);

                Console.WriteLine("Report generated successfully!\n");
                foreach (var s in students)
                {
                    Console.WriteLine(s);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Input file not found: {inputFile}");
            }
            catch (GradingSystem.Exceptions.InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Invalid score: {ex.Message}");
            }
            catch (GradingSystem.Exceptions.MissingFieldException ex)
            {
                Console.WriteLine($"Missing field: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine("\nDone. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
