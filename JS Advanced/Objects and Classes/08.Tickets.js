function solve(arr, sortCriteria) {
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = []
    for (let i = 0; i < arr.length; i++) {
        let [curDestination, curPrice, curStatus] = arr[i].split('|');
        curPrice = Number(curPrice);
        tickets.push(new Ticket(curDestination, curPrice, curStatus));
    }

    if (sortCriteria !== 'price') {
        tickets.sort(sortStrings);
    }else{
        tickets.sort(sortNums);
    }

    return tickets;
   
    function sortNums(a, b) {
        return a.value - b.value;
      };
      
    
    function sortStrings(a, b) {        
        if (a[sortCriteria] < b[sortCriteria]) {
          return -1;
        }
        if (a[sortCriteria] > b[sortCriteria]) {
          return 1;
        }             
        return 0;
      };
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
)