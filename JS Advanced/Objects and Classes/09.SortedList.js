class List {

    constructor() {
        this.orderedList = [];
        this.size = 0;
    }

    add(element) {
        this.orderedList.push(element);
        this.orderedList.sort((a, b) => a - b);
        this.size = this.orderedList.length;
        return;
    }
    remove(index) {
        if (!(index < 0 || index >= this.orderedList.length)) {
            this.orderedList.splice(index, 1);
            this.size = this.orderedList.length;
        }
        return;
    }
    get(index) {
        let el = this.orderedList[index];
        return el;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
