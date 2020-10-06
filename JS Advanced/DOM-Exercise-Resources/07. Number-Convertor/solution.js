function solve() {
    let menuElement = document.getElementById('selectMenuTo');
    let buttonElement = document.querySelector("button");
    let numToConvertElement = document.getElementById('input');
    let resultElement = document.getElementById('result');    
    let binaryOptionElement = document.createElement('option');
    let hexadecimalOptionElement = document.createElement('option');

    Object.assign(binaryOptionElement, {
        value: 'binary',
        textContent: 'Binary'
    })
    menuElement.appendChild(binaryOptionElement);
    Object.assign(hexadecimalOptionElement, {
        value: 'hexadecimal',
        textContent: 'Hexadecimal'
    })
    menuElement.appendChild(hexadecimalOptionElement);
    
    buttonElement.addEventListener('click', () => {
        
        if (menuElement.value === 'binary') {
            resultElement.value = Number(numToConvertElement.value).toString(2);            
        }
        if (menuElement.value === 'hexadecimal') {
            resultElement.value = Number(numToConvertElement.value).toString(16).toUpperCase();            
        }
    })
}