class Parking{
    constructor(capacity){
        this.capacity = capacity;
        this.vehicles = [];
    }
    addCar(carModel, carNumber){
        if (this.vehicles.length === this.capacity) {
            throw new Error("Not enough parking space.");
        }
        let curCar = {carModel, carNumber, payed: false};
        this.vehicles.push(curCar);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`
    }
    removeCar(carNumber){
        let curCar = this.vehicles.find(car => car.carNumber === carNumber);
        if (!curCar) {
            throw new Error("The car, you're looking for, is not found.");
        }
        if (curCar.payed === false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }
        let index = this.vehicles.indexOf(curCar);
        this.vehicles.slice(index, 1);
        return `${carNumber} left the parking lot.`
    }
    pay(carNumber){
        let curCar = this.vehicles.find(car => car.carNumber === carNumber);
        if (!curCar) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
        if (curCar.payed === true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`)
        }
        curCar.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`
    }
    getStatistics(carNumber){
        let result = '';
        if (carNumber === undefined) {
            result += `The Parking Lot has ${ this.capacity - this.vehicles.length } empty spots left.`;
            this.vehicles.sort((a,b) => {
                return a.carModel.localeCompare(b.carModel);
            });
            this.vehicles.forEach(car =>{
                result += `\n${car.carModel} == ${car.carNumber} - `;
                result += this.hasPayed(car);
            })
            
        }else{
            let curCar = this.vehicles.find(car => car.carNumber === carNumber);
            result += `${curCar.carModel} == ${curCar.carNumber} - `;
            result += this.hasPayed(curCar);
        }
        return result;
    }
    hasPayed(car){
        let result = ''
        if (car.payed === true) {
            result += 'Has payed';
        }else{
            result += 'Not payed';
        }
        return result;
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
