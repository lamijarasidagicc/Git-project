import os
import json
from datetime import datetime

class BudgetTracker:
    data_file = os.path.join(os.path.dirname(_file_), 'data.json')
    transactions = []
    savings_goal = 0

    @staticmethod
    def main():
        BudgetTracker.load_data()

        while True:
            print("\nWelcome to the Personal Budget Tracker!")
            print("Please select an option:")
            print("1. Add Income")
            print("2. Add Expense")
            print("3. View Monthly Summary")
            print("4. Set Savings Goal")
            print("5. Exit\n")

            choice = input("Enter your choice: ")

            if choice == "1":
                BudgetTracker.add_transaction("income")
            elif choice == "2":
                BudgetTracker.add_transaction("expense")
            elif choice == "3":
                BudgetTracker.view_monthly_summary()
            elif choice == "4":
                BudgetTracker.set_savings_goal()
            elif choice == "5":
                BudgetTracker.save_data()
                print("Goodbye!")
                break
            else:
                print("Invalid option. Please try again.")

    @staticmethod
    def add_transaction(transaction_type):
        category = input("Enter category: ") or "Uncategorized"

        while True:
            try:
                amount = float(input("Enter amount: "))
                if amount <= 0:
                    raise ValueError("Amount must be positive.")
                break
            except ValueError as e:
                print(e)

        description = input("Enter description: ") or "No description"

        transaction = {
            "date": datetime.now().strftime("%Y-%m-%d"),
            "type": transaction_type,
            "category": category,
            "amount": amount,
            "description": description
        }

        BudgetTracker.transactions.append(transaction)
        print(f"{transaction_type.capitalize()} added successfully!")
        BudgetTracker.save_data()

    @staticmethod
    def view_monthly_summary():
        total_income = 0
        total_expenses = 0
        current_month = datetime.now().month

        for transaction in BudgetTracker.transactions:
            transaction_month = datetime.strptime(transaction["date"], "%Y-%m-%d").month
            if transaction_month == current_month:
                if transaction["type"] == "income":
                    total_income += transaction["amount"]
                elif transaction["type"] == "expense":
                    total_expenses += transaction["amount"]

        savings = total_income - total_expenses

        print("\nMonthly Summary:")
        print(f"Total Income: ${total_income:.2f}")
        print(f"Total Expenses: ${total_expenses:.2f}")
        print(f"Savings: ${savings:.2f}")

        if BudgetTracker.savings_goal > 0:
            progress = (savings / BudgetTracker.savings_goal) * 100
            print(f"Savings Goal: ${BudgetTracker.savings_goal:.2f}")
            print(f"Progress: {progress:.2f}%")

        if total_expenses > total_income:
            print("Warning: Your expenses exceed your income!")

    @staticmethod
    def set_savings_goal():
        while True:
            try:
                BudgetTracker.savings_goal = float(input("Enter your savings goal: "))
                if BudgetTracker.savings_goal <= 0:
                    raise ValueError("Savings goal must be positive.")
                break
            except ValueError as e:
                print(e)

        print(f"Savings goal set to ${BudgetTracker.savings_goal:.2f}")

    @staticmethod
    def load_data():
        if os.path.exists(BudgetTracker.data_file):
            try:
                with open(BudgetTracker.data_file, 'r') as file:
                    BudgetTracker.transactions = json.load(file)
            except Exception as e:
                print(f"Error loading data: {e}")

    @staticmethod
    def save_data():
        try:
            with open(BudgetTracker.data_file, 'w') as file:
                json.dump(BudgetTracker.transactions, file, indent=4)
        except Exception as e:
            print(f"Error saving data: {e}")

if _name_ == "_main_":
    BudgetTracker.main()
