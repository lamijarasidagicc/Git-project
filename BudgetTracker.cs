using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BudgetTracker
{
    class BudgetTracker
    {
        static string dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
        static List<Transaction> transactions = new List<Transaction>();
        static decimal savingsGoal = 0;

        static void Main(string[] args)
        {
            LoadData();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Personal Budget Tracker!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View Monthly Summary");
                Console.WriteLine("4. Set Savings Goal");
                Console.WriteLine("5. Exit\n");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction("income");
                        break;
                    case "2":
                        AddTransaction("expense");
                        break;
                    case "3":
                        ViewMonthlySummary();
                        break;
                    case "4":
                        SetSavingsGoal();
                        break;
                    case "5":
                        SaveData();
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTransaction(string type)
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine() ?? "Uncategorized";

            Console.Write("Enter amount: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Write("Invalid amount. Please enter a positive number: ");
            }

            Console.Write("Enter description: ");
            string description = Console.ReadLine() ?? "No description";

            Transaction transaction = new Transaction
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Type = type,
                Category = category,
                Amount = amount,
                Description = description
            };

            transactions.Add(transaction);
            Console.WriteLine($"{type} added successfully!");
            SaveData();
        }

        static void ViewMonthlySummary()
        {
            decimal totalIncome = 0;
            decimal totalExpenses = 0;

            foreach (var transaction in transactions)
            {
                if (DateTime.Parse(transaction.Date).Month == DateTime.Now.Month)
                {
                    if (transaction.Type == "income")
                        totalIncome += transaction.Amount;
                    else if (transaction.Type == "expense")
                        totalExpenses += transaction.Amount;
                }
            }

            decimal savings = totalIncome - totalExpenses;
            Console.WriteLine("\nMonthly Summary:");
            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Savings: {savings:C}");

            if (savingsGoal > 0)
            {
                Console.WriteLine($"Savings Goal: {savingsGoal:C}");
                Console.WriteLine($"Progress: {(savings / savingsGoal * 100):F2}%");
            }

            if (totalExpenses > totalIncome)
                Console.WriteLine("Warning: Your expenses exceed your income!");
        }

        static void SetSavingsGoal()
        {
            Console.Write("Enter your savings goal: ");
            while (!decimal.TryParse(Console.ReadLine(), out savingsGoal) || savingsGoal <= 0)
            {
                Console.Write("Invalid goal. Please enter a positive number: ");
            }

            Console.WriteLine($"Savings goal set to {savingsGoal:C}");
        }

        static void LoadData()
        {
            if (File.Exists(dataFile))
            {
                try
                {
                    string json = File.ReadAllText(dataFile);
                    transactions = JsonConvert.DeserializeObject<List<Transaction>>(json) ?? new List<Transaction>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading data: {ex.Message}");
                }
            }
        }

        static void SaveData()
        {
            try
            {
                string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText(dataFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        class Transaction
        {
            public string Date { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Description { get; set; } = string.Empty;
        }
    }
}
