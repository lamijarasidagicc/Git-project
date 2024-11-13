## Personal Budget Tracker 

## Project Overview

The Personal Budget Tracker is a console-based application that helps users manage and track their finances efficiently. Built using Python, JavaScript, and C#, this project showcases cross-language programming skills and provides a simple, intuitive way for users to monitor income, expenses, and savings goals.

## Project Goals

- Financial Management Tool: To create an interactive budget tracker that allows users to track income, expenses, and savings across different categories.
- Cross-Language Practice: To demonstrate proficiency in Python, JavaScript, and C#, making the budget tracker accessible across multiple platforms.
- Feature-Rich Budgeting Experience: To implement features like category management, real-time balance updates, expense tracking, and goal setting, ensuring a user-friendly experience.

## Features 

- Category Management: Users can create and manage categories for various expense types (e.g., Groceries, Rent, Entertainment) to organize their budget.
- Income & Expense Tracking: Users can log income and expenses with descriptions, dates, and amounts for clear financial records.
- Real-Time Balance Updates: Provides an updated balance after each transaction, so users always know their financial status.
- Goal Setting: Allows users to set savings goals and provides progress tracking to help reach them.
- Monthly Summary: Generates a monthly summary showing total income, expenses, and savings.
- Multi-Language Support: Developed in Python, JavaScript, and C# for flexible deployment on various platforms.
- Data Persistence: Saves data for each session and allows users to resume or analyze previous months.

## Technologies Used 

1. JavaScript (Node.js Console Application)
2. C# (.NET Console Application)
3. Python (Standard Console Application)

## Project structutre 
   ```
   
Personal_Budget_Tracker
│
├── Python/
│   ├── budget_tracker.py
│
├── JavaScript/
│   ├── budgetTracker.js
│
├── C#/
│   ├── BudgetTracker.cs
│
└── data.json

```


   
## How to Download and Install

1. **Download:**
- Clone this repository:
```
git clone https://github.com/your-username/Personal_Budget_Tracker.git
```
2. **Navigate to the Project Folder:**
```
cd Personal_Budget_Tracker
```

 3. **Ensure required tools:**
- Install Python 3.x, Node.js (for JavaScript), and .NET Core SDK on your machine.

## How to Run

1. **Python: Navigate to the Python folder and execute:**

 ```   
python budget_tracker.py
 ```

2. **JavaScript: Navigate to the JavaScript folder and execute:**

 ```   
node budgetTracker.js
 ```

3. **C#: Navigate to the C# folder and execute:**

 ```   
dotnet run BudgetTracker.cs
 ```

## J SON Data File

The data.json file contains transaction data and savings goals and should be placed in each language folder.

JSON Structure:
 ```   
[
   {
       "date": "2024-01-01",
       "type": "income",
       "category": "Salary",
       "amount": 1500,
       "description": "Monthly paycheck"
   },
   {
       "date": "2024-01-02",
       "type": "expense",
       "category": "Groceries",
       "amount": 50,
       "description": "Weekly grocery shopping"
   }
]
  ``` 
  ## User Interaction

1.  **Starting the Budget Tracker** 
    Users are prompted to enter income or expense transactions and view summaries or set goals.
    

