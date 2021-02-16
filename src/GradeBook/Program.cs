using System;

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name of the book");
            var name = Console.ReadLine();
            var diskBook = new DiskBook(name + "'s Book");
            diskBook.GradeAdded += OnGradeAdded;

            EnterGrades(diskBook);

            var stats = diskBook.GetStatistics();
            Console.WriteLine($"Grades for the book {diskBook.Name} of category: {InMemoryBook.CATEGORY}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch
                {
                    throw; //re-throw any unexpected exception
                }
            }
        }
    }
}