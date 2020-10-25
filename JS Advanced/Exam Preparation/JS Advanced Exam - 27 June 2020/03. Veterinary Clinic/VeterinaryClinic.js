class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }
    newCustomer(ownerName, petName, kind, procedures) {
        if (this.currentWorkload === this.capacity) {
            throw new Error("Sorry, we are not able to accept more patients!")
        }
        let client = this.clients.find(client => client.ownerName === ownerName);

        if (client) {
            let curPet = client.pets.find(pet => pet.petName === petName && pet.kind === kind)
            if (curPet && curPet.procedures.length > 0) {
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${curPet.procedures.join(', ')}.`);
            } else if (curPet && curPet.procedures.length === 0) {
                curPet.procedures = procedures;
                this.currentWorkload += 1;
                return `Welcome ${petName}!`;
            }
        }
        if (!client) {
            this.clients.push({
                ownerName,
                pets: [{ petName, kind, procedures }]
            });
        } else {
            client.pets.push({ petName, kind, procedures });
        }
        this.currentWorkload += 1;
        return `Welcome ${petName}!`;
    }
    onLeaving(ownerName, petName) {
        let client = this.clients.find(client => client.ownerName === ownerName);
        if (!client) {
            throw new Error("Sorry, there is no such client!");
        }
        let curPet = client.pets.find(pet => pet.petName === petName)
        if (!curPet || curPet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }
        let curBill = 0;
        curPet.procedures.forEach(proc => curBill += 500);
        this.totalProfit += curBill;
        this.currentWorkload -= 1;
        curPet.procedures = [];
        return `Goodbye ${petName}. Stay safe!`;
    }
    toString() {
        let parcentageWorkLoad = Math.floor((this.currentWorkload / this.capacity) * 100);
        let result = `${this.clinicName} is ${parcentageWorkLoad}% busy today!`;
        result += `\nTotal profit: ${this.totalProfit.toFixed(2)}$`
        this.clients.sort(this.sortClients);
        this.clients.forEach(client => client.pets.sort(this.sortPets));
        this.clients.forEach(client => {
            result += `\n${client.ownerName} with:`;
            client.pets.forEach(pet => {
                result += `\n---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(', ')}`
            })
        })
        return result;
    }
    sortClients(a, b) {
        return a.ownerName.localeCompare(b.ownerName);
    }
    sortPets(a, b) {
        return a.petName.localeCompare(b.petName);
    }
}


let clinic = new VeterinaryClinic('SoftCare', 4);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));

console.log(clinic.onLeaving('Jim Jones', 'Tom'));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));

console.log(clinic.onLeaving('Anna Morgan', 'Max'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);

console.log(clinic.onLeaving('Jim Jones', 'Sara'));

console.log(clinic.toString());