function solve(name, age, weight, height ) {
    let person = {
        name: name,
        personalInfo: {
            age: age, 
            weight: weight,
            height: height
        },
        BMI: Math.round(weight/(height/100*height/100)) ,
        status: makeStatus(Math.round(weight/(height/100*height/100)))
    }
    function makeStatus(bmi) {
        if (bmi < 18.5) {
            return 'underweight';
        }else if (bmi < 25) {
            return 'normal';
        }else if (bmi < 30) {
            return 'overweight';
        }else if (bmi >= 30) {            
            return 'obese'
        }
    }
    if (person.BMI >= 30) {            
        person.recommendation ='admission required'; 
    }
    return person;
}

console.log(solve('Peter', 29, 75, 182));
console.log(solve("Honey Boo Boo", 9, 57, 137));