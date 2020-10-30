function solve() {

    let numPadElement = document.getElementsByTagName('button');
    let calcFieldElement = document.getElementById('expressionOutput');
    let resultElement = document.getElementById('resultOutput');

    let firstNum = '';
    let secondNum = '';
    let sign = '';

    Object.values(numPadElement).forEach(btn => {
        btn.addEventListener('click', () => {

            let currentClickedChar = btn.value;            
            switch (currentClickedChar) {
                case '=':
                    resultElement.innerHTML = makeCalculation(firstNum, sign, secondNum);
                    return;
                case 'Clear':
                    firstNum = '';
                    secondNum = '';
                    sign = '';
                    resultElement.textContent = '';
                    calcFieldElement.textContent = '';
                    return;
                default:
                    break;
            }
            if ((Number.isInteger(Number(currentClickedChar)) || currentClickedChar === '.') && sign === '') {
                firstNum += currentClickedChar;
                calcFieldElement.innerHTML += currentClickedChar;
                return
            }
            if (firstNum !== '' && sign === '' && (!Number.isInteger(Number(currentClickedChar)) || currentClickedChar !== '.')) {
                sign = currentClickedChar;
                calcFieldElement.innerHTML += ' ' + currentClickedChar + ' ';
                return
            }
            if (firstNum !== '' && sign !== '' && (Number.isInteger(Number(currentClickedChar)) || currentClickedChar === '.')) {
                secondNum += currentClickedChar;
                calcFieldElement.innerHTML += currentClickedChar;
                return
            }
        })
    })

    function makeCalculation(a, sign, b) {
        if (!b) {
            return NaN;
        }
        switch (sign) {
            case '+':
                return Number(a) + Number(b);
            case '-':
                return Number(a) - Number(b);
            case '*':
                return Number(a) * Number(b);
            case '/':
                return Number(a) / Number(b);
            default:
                break;
        }
    }
}