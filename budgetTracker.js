const fs = require('fs');
const path = require('path');

const dataFilePath = path.join(__dirname, 'data.json');


function loadData() {
    if (fs.existsSync(dataFilePath)) {
        const data = fs.readFileSync(dataFilePath);
        return JSON.parse(data);
    }
    return [];
}


function saveData(data) {
    fs.writeFileSync(dataFilePath, JSON.stringify(data, null, 2));
}


function addTransaction(type, category, amount, description) {
    const transactions = loadData();
    const date = new Date().toISOString().split('T')[0];
    
    const newTransaction = { date, type, category, amount, description };
    transactions.push(newTransaction);
    saveData(transactions);
    console.log(`${type} added successfully!`);
}


function viewMonthlySummary() {
    const transactions = loadData();
    const currentMonth = new Date().toISOString().slice(0, 7); 

    const filteredTransactions = transactions.filter(transaction =>
        transaction.date.startsWith(currentMonth)
    );

    let totalIncome = 0;
    let totalExpenses = 0;

    filteredTransactions.forEach(transaction => {
        if (transaction.type === 'income') {
            totalIncome += transaction.amount;
        } else if (transaction.type === 'expense') {
            totalExpenses += transaction.amount;
        }
    });

    const savings = totalIncome - totalExpenses;

    console.log(`\nMonthly Summary for ${currentMonth}`);
    console.log(`Total Income: ${totalIncome}`);
    console.log(`Total Expenses: ${totalExpenses}`);
    console.log(`Savings: ${savings}`);
}


let savingsGoal = 0;
function setGoal(goalAmount) {
    savingsGoal = goalAmount;
    console.log(`Savings goal set to ${goalAmount}`);
}


function mainMenu() {
    console.log(`\nWelcome to the Personal Budget Tracker!`);
    console.log(`1. Add Income`);
    console.log(`2. Add Expense`);
    console.log(`3. View Monthly Summary`);
    console.log(`4. Set Savings Goal`);
    console.log(`5. Exit`);

    const prompt = require('prompt-sync')();
    const choice = prompt('Select an option: ');

    switch (choice) {
        case '1':
            const incomeCategory = prompt('Enter category: ');
            const incomeAmount = parseFloat(prompt('Enter amount: '));
            const incomeDescription = prompt('Enter description: ');
            addTransaction('income', incomeCategory, incomeAmount, incomeDescription);
            break;
        case '2':
            const expenseCategory = prompt('Enter category: ');
            const expenseAmount = parseFloat(prompt('Enter amount: '));
            const expenseDescription = prompt('Enter description: ');
            addTransaction('expense', expenseCategory, expenseAmount, expenseDescription);
            break;
        case '3':
            viewMonthlySummary();
            break;
        case '4':
            const goalAmount = parseFloat(prompt('Enter your savings goal: '));
            setGoal(goalAmount);
            break;
        case '5':
            console.log('Goodbye!');
            process.exit();
        default:
            console.log('Invalid choice. Please try again.');
    }

    mainMenu(); 
}

mainMenu();