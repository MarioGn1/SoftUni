class Bank {
    #bankName;
    constructor(bankName) {
        this.#bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer) {
        if (this.allCustomers.find(cust => cust.firstName === customer.firstName
            && cust.lastName === customer.lastName
            && cust.personalId === customer.personalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }
        this.allCustomers.push(customer);
        return customer
    }
    depositMoney(personalId, amount) {
        let customer = this.findCustomer(personalId);
        if (!customer.totalMoney) {
            customer.totalMoney = 0
        }
        customer.totalMoney += amount;
        this.storeTransaction(customer, 'deposit', amount);
        return `${customer.totalMoney}$`;
    }
    withdrawMoney (personalId, amount){
        let customer = this.findCustomer(personalId);
        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }
        customer.totalMoney -= amount;
        this.storeTransaction(customer, 'withdraw', amount);
        return `${customer.totalMoney}$`;
    }

    storeTransaction(customer, action, amount){
        if (!customer.hasOwnProperty('transactions')) {
            customer.transactions = [];
        }
        let number = customer.transactions.length + 1
        customer.transactions.push({number, names:[customer.firstName, customer.lastName], transactionType: action, amount})
    }

    findCustomer(id){
        let customer = this.allCustomers.find(cust => cust.personalId === id)
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }
        return customer;
    }
    customerInfo (personalId){
        let customer = this.findCustomer(personalId);
        let result = `Bank name: ${this.#bankName}`;
        result+= `\nCustomer name: ${customer.firstName} ${customer.lastName}`;
        result+= `\nCustomer ID: ${customer.personalId}`;
        result+= `\nTotal Money: ${customer.totalMoney}$`;
        result+= `\nTransactions:`
        customer.transactions.sort(function(a,b){return b.number-a.number})
        customer.transactions.forEach(trans => {
            if (trans.transactionType === 'deposit') {
                result+= `\n${trans.number}. ${trans.names[0]} ${trans.names[1]} made deposit of ${trans.amount}$!`
            }else{
                result+= `\n${trans.number}. ${trans.names[0]} ${trans.names[1]} withdrew ${trans.amount}$!`
            }
        });
        return result;
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
