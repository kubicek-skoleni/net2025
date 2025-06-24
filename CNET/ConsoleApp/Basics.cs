using System;

namespace Day1
{
    // Exercise 01: Basic C# Syntax and Data Types
    public class Exercise01_Basics
    {
        public static void Main()
        {
            Console.WriteLine("=== Exercise 01: C# Basics ===");

            // Task 1: Variables and Data Types
            Task1_Variables();

            // Task 2: String Operations
            Task2_StringOperations();

            // Task 3: Control Flow
            Task3_ControlFlow();

            // Task 4: Nullable Types
            Task4_NullableTypes();
        }

        static void Task1_Variables()
        {
            Console.WriteLine("\n--- Task 1: Variables and Data Types ---");

            // TODO: Declare variables of different types
            int age = 25;
            double salary = 75000.50;
            string name = "John Doe";
            bool isEmployed = true;
            char grade = 'A';
            decimal price = 19.99m;

            // Using var keyword
            var company = "Tech Corp";
            var yearsOfExperience = 5;
            var hourlyRate = 45.50;

            // Constants
            const double TAX_RATE = 0.20;
            const int RETIREMENT_AGE = 65;

            // Display all variables
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Salary: ${salary:N2}");
            Console.WriteLine($"Employed: {isEmployed}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine($"Company: {company}");
            Console.WriteLine($"Years until retirement: {RETIREMENT_AGE - age}");
            Console.WriteLine($"Tax amount: ${salary * TAX_RATE:N2}");
        }

        static void Task2_StringOperations()
        {
            Console.WriteLine("\n--- Task 2: String Operations ---");

            string firstName = "Alice";
            string lastName = "Johnson";

            // String interpolation
            string fullName = $"{firstName} {lastName}";
            Console.WriteLine($"Full name: {fullName}");

            // String methods
            Console.WriteLine($"Uppercase: {fullName.ToUpper()}");
            Console.WriteLine($"Lowercase: {fullName.ToLower()}");
            Console.WriteLine($"Length: {fullName.Length}");
            Console.WriteLine($"Contains 'John': {fullName.Contains("John")}");
            Console.WriteLine($"Starts with 'Alice': {fullName.StartsWith("Alice")}");

            // Substring
            string email = "alice.johnson@company.com";
            int atIndex = email.IndexOf('@');
            string username = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex + 1);
            Console.WriteLine($"Email username: {username}");
            Console.WriteLine($"Email domain: {domain}");

            // Verbatim string
            string filePath = @"C:\Users\Documents\file.txt";
            Console.WriteLine($"File path: {filePath}");

            // Multiline string
            string address = @"123 Main Street
Apartment 4B
New York, NY 10001";
            Console.WriteLine($"Address:\n{address}");
        }

        static void Task3_ControlFlow()
        {
            Console.WriteLine("\n--- Task 3: Control Flow ---");

            // Traditional if-else
            int score = 85;
            string grade;

            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 70)
                grade = "C";
            else if (score >= 60)
                grade = "D";
            else
                grade = "F";

            Console.WriteLine($"Score: {score}, Grade: {grade}");

            // Switch expression (modern C#)
            string dayName = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => "Start of work week",
                DayOfWeek.Friday => "TGIF!",
                DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend!",
                _ => "Regular work day"
            };
            Console.WriteLine($"Today: {dayName}");

            // Pattern matching with switch
            object data = 42;
            string result = data switch
            {
                int n when n > 0 => $"Positive integer: {n}",
                int n when n < 0 => $"Negative integer: {n}",
                int => "Zero",
                string s => $"String with length {s.Length}",
                null => "Null value",
                _ => "Unknown type"
            };
            Console.WriteLine($"Data type check: {result}");

            // Loops
            Console.WriteLine("\nLoop examples:");

            // for loop
            Console.Write("For loop: ");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // foreach with array
            string[] fruits = { "Apple", "Banana", "Orange", "Grape" };
            Console.Write("Foreach loop: ");
            foreach (var fruit in fruits)
            {
                Console.Write($"{fruit} ");
            }
            Console.WriteLine();

            // while loop
            Console.Write("While loop (countdown): ");
            int countdown = 5;
            while (countdown > 0)
            {
                Console.Write($"{countdown} ");
                countdown--;
            }
            Console.WriteLine("Blast off!");
        }

        static void Task4_NullableTypes()
        {
            Console.WriteLine("\n--- Task 4: Nullable Types ---");

            // Nullable value types
            int? nullableInt = null;
            double? temperature = 23.5;
            bool? isCompleted = null;

            // Checking for null
            if (nullableInt.HasValue)
            {
                Console.WriteLine($"Value: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("nullableInt is null");
            }

            // Null coalescing operator ??
            int actualValue = nullableInt ?? -1;
            Console.WriteLine($"Actual value (using ??): {actualValue}");

            // Null coalescing assignment ??=
            nullableInt ??= 10;
            Console.WriteLine($"After ??= operator: {nullableInt}");

            // Nullable reference types (C# 8.0+)
            string? nullableName = null;
            string nonNullableName = "Required Name";

            // Null-conditional operator ?.
            int? nameLength = nullableName?.Length;
            Console.WriteLine($"Nullable name length: {nameLength ?? 0}");

            // Pattern matching with null
            string message = nullableName switch
            {
                null => "Name is not provided",
                "" => "Name is empty",
                _ => $"Hello, {nullableName}"
            };
            Console.WriteLine(message);
        }
    }
}