using System;
using System.Collections.Generic;
using System.IO;
using GradingSystem.Models;

namespace GradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using var reader = new StreamReader(inputFilePath);
            string? line;
            int lineNumber = 0;

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                var parts = line.Split(',');

                if (parts.Length != 3)
                    throw new GradingSystem.Exceptions.MissingFieldException(
                        $"Line {lineNumber} is missing fields."
                    );

                try
                {
                    int id = int.Parse(parts[0].Trim());
                    string fullName = parts[1].Trim();
                    int score = int.Parse(parts[2].Trim());

                    students.Add(new Student(id, fullName, score));
                }
                catch (FormatException)
                {
                    throw new GradingSystem.Exceptions.InvalidScoreFormatException(
                        $"Invalid score format on line {lineNumber}."
                    );
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using var writer = new StreamWriter(outputFilePath);
            foreach (var student in students)
            {
                writer.WriteLine(student.ToString());
            }
        }
    }
}
