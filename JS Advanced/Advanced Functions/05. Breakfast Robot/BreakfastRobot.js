function solve() {
    let robot = {
        protein: 0,
        carbohydrates: 0,
        fat: 0,
        flavours: 0,
        restock: function (component, qty) {
            qty = Number(qty);
            if (component === 'protein') {
                this.protein += qty;
                return 'Success';
            } else if (component === 'carbohydrate') {
                this.carbohydrates += qty;
                return 'Success';
            } else if (component === 'fat') {
                this.fat += qty;
                return 'Success';
            } else if (component === 'flavour') {
                this.flavours += qty;
                return 'Success';
            }
        },
        prepare: function (recipe, qty) {
            qty = Number(qty);
            let missingProduct = '';
            switch (recipe) {
                case 'apple':
                    if (this.carbohydrates < qty) {
                        missingProduct += 'carbohydrate';
                    } else if (this.flavours < qty * 2) {
                        missingProduct += 'flavour';
                    } else {
                        this.carbohydrates -= qty;
                        this.flavours -= qty * 2;
                    }
                    break;
                case 'lemonade':
                    if (this.carbohydrates < qty * 10) {
                        missingProduct += 'carbohydrate';
                    } else if (this.flavours < qty * 20) {
                        missingProduct += 'flavour';
                    } else {
                        this.carbohydrates -= qty * 10;
                        this.flavours -= qty * 20;
                    }
                    break;
                case 'burger':
                    if (this.carbohydrates < qty * 5) {
                        missingProduct += 'carbohydrate';
                    } else if (this.fat < qty * 7) {
                        missingProduct += 'fat'
                    } else if (this.flavours < qty * 3) {
                        missingProduct += 'flavour';
                    } else {
                        this.carbohydrates -= qty * 5;
                        this.fat -= qty * 7;
                        this.flavours -= qty * 3;
                    }
                    break;
                case 'eggs':
                    if (this.protein < qty * 5) {
                        missingProduct += 'protein';
                    } else if (this.fat < qty) {
                        missingProduct += 'fat'
                    } else if (this.flavours < qty) {
                        missingProduct += 'flavour';
                    } else {
                        this.protein -= qty * 5;
                        this.fat -= qty;
                        this.flavours -= qty;
                    }
                    break;
                case 'turkey':
                    if (this.protein < qty * 10) {
                        missingProduct += 'protein';
                    } else if (this.carbohydrates < qty * 10) {
                        missingProduct += 'carbohydrate'
                    } else if (this.fat < qty * 10) {
                        missingProduct += 'fat'
                    } else if (this.flavours < qty) {
                        missingProduct += 'flavour';
                    } else {
                        this.protein -= qty * 10;
                        this.carbohydrates -= qty * 10;
                        this.fat -= qty * 10;
                        this.flavours -= qty * 10;
                    }
                    break;
                default:
                    break;
            }
            if (!missingProduct) {
                return 'Success'
            }else{
                return `Error: not enough ${missingProduct} in stock`
            }
        },
        report: function () {
            return `protein=${this.protein} carbohydrate=${this.carbohydrates} fat=${this.fat} flavour=${this.flavours}`;
        }
    }

    function robotAction(command) {
        let curCommand = command.split(' ')
        switch (curCommand[0]) {
            case 'restock':
                return robot.restock(curCommand[1], curCommand[2]);
            case 'prepare':
                return robot.prepare(curCommand[1], curCommand[2]);                
            case 'report':
                return robot.report();
            default:
                break;
        }
    }
    return robotAction;
}

let manager = solve();
console.log(manager('restock carbohydrate 10'))
console.log(manager('restock flavour 10'))
console.log(manager('prepare apple 1'))
console.log(manager('restock fat 10'))
console.log(manager('prepare burger 1'))
console.log(manager('report'))



