using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQTasks
{
    class Program
    {
        static void Main()
        {
            // Завдання 1
            Task1();

            // Завдання 2
            Task2();

            // Завдання 3
            Task3();

            // Завдання 4
            Task4();

            // Завдання 5
            Task5();

            // Завдання 6
            Task6();
        }

        // Завдання 1: Запити LINQ для вибору додатних і від'ємних чисел
        static void Task1()
        {
            Console.WriteLine("Task 1: LINQ Queries for Positive and Negative Numbers");

            int[] numbers = { -10, 15, -3, 7, -8, 20, -30, 5, 0, 12, -7, 9, -5, 18, -25, 14, 4, -2, 6, -11 };

            // Запит для вибору додатних чисел
            var positiveNumbers = numbers.Where(n => n > 0);
            Console.WriteLine("Positive Numbers: " + string.Join(", ", positiveNumbers));

            // Запит для вибору від'ємних чисел
            var negativeNumbers = numbers.Where(n => n < 0);
            Console.WriteLine("Negative Numbers: " + string.Join(", ", negativeNumbers));

            // Обчислення суми додатних чисел
            int sumOfPositives = positiveNumbers.Sum();
            Console.WriteLine($"Sum of Positive Numbers: {sumOfPositives}\n");
        }

        // Завдання 2: Пошук слів у тексті з файлу
        static void Task2()
        {
            Console.WriteLine("Task 2: Search for Words in a File");

            string filePath = "text.txt"; // Ім'я файлу (створіть його у папці з програмою)
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);

                // Пошук слів
                bool containsSecret = text.Contains("таємно");
                bool containsConfidential = text.Contains("для службового використання");

                Console.WriteLine("Words Found:");
                if (containsSecret) Console.WriteLine("The word 'таємно' was found.");
                if (containsConfidential) Console.WriteLine("The phrase 'для службового використання' was found.");
                if (!containsSecret && !containsConfidential) Console.WriteLine("No target words found.");
            }
            else
            {
                Console.WriteLine($"File {filePath} not found.");
            }

            Console.WriteLine();
        }

        // Завдання 3: LINQ для об'єктів класу Book
        static void Task3()
        {
            Console.WriteLine("Task 3: LINQ for Book Filtering");

            // Створення колекції книг
            List<Book> books = new List<Book>
            {
                new Book("Author1", "C# Programming", 95, "Programming", 2008),
                new Book("Author2", "Java Basics", 120, "Programming", 2015),
                new Book("Author3", "Algorithms", 90, "Programming", 2005),
                new Book("Author4", "History of Science", 80, "Science", 2009),
                new Book("Author5", "Python 101", 85, "Programming", 2010),
                new Book("Author6", "Cooking Recipes", 50, "Cooking", 2012),
                new Book("Author7", "Advanced C++", 100, "Programming", 2009),
                new Book("Author8", "Gardening Tips", 70, "Hobby", 2011),
                new Book("Author9", "HTML & CSS", 60, "Programming", 2007),
                new Book("Author10", "Physics Fundamentals", 110, "Science", 2003)
            };

            // LINQ-запит
            var filteredBooks = books
                .Where(b => b.Category == "Programming" && b.Year <= 2010 && b.Price <= 100)
                .OrderBy(b => b.Author)
                .ToList();

            // Вивід результатів
            Console.WriteLine("Filtered Books:");
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"{book.Author} - {book.Name}, Price: {book.Price}, Year: {book.Year}");
            }

            Console.WriteLine($"Number of Selected Books: {filteredBooks.Count}\n");
        }

        // Завдання 4: Вибір доменів .edu та .ua
        static void Task4()
        {
            Console.WriteLine("Task 4: Filter Domains with '.edu' and '.ua'");

            List<string> domains = new List<string>
            {
                "example.com", "university.edu", "site.ua", "school.edu", "shop.org",
                "news.ua", "example.edu", "portal.net", "blog.ua", "forum.com"
            };

            var filteredDomains = domains.Where(d => d.EndsWith(".edu") || d.EndsWith(".ua"));
            Console.WriteLine("Filtered Domains: " + string.Join(", ", filteredDomains) + "\n");
        }

        // Завдання 5: Знайти найбільше число
        static void Task5()
        {
            Console.WriteLine("Task 5: Find the Largest Number");

            int[] numbers = { 1, -2, 4, 8, 12, 25 };
            int maxNumber = numbers.Max();
            Console.WriteLine($"The Largest Number is: {maxNumber}\n");
        }

        // Завдання 6: Вибрати 4 числа, починаючи з третього
        static void Task6()
        {
            Console.WriteLine("Task 6: Select 4 Numbers Starting from the Third");

            int[] numbers = { 1, -2, 4, 8, 12, 25 };
            var subset = numbers.Skip(2).Take(4);
            Console.WriteLine("Selected Numbers: " + string.Join(", ", subset) + "\n");
        }
    }

    // Клас Book для завдання 3
    class Book
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }

        public Book(string author, string name, double price, string category, int year)
        {
            Author = author;
            Name = name;
            Price = price;
            Category = category;
            Year = year;
        }
    }
}
