function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {        
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbon = {};
            this.ribbon.color = ribbonColor;
            this.ribbon.length = ribbonLength;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength)
            this.text = text;
        }
    }

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}

solve()

// let myBallon = new BirthdayBalloon('red', 10, 'blue', 100, 'Happy Birth Day!');
// console.log(myBallon.color)
// console.log(myBallon.gasWeight)
// console.log(myBallon.ribbon.color)
// console.log(myBallon.ribbon.length)
// console.log(myBallon.text)