function solve() {

    let orderedListElement = document.querySelector("ol[type = 'A']").children;
    let inputElement = document.querySelector("[type='text']");
    let btnElement = document.getElementsByTagName('button')[0];       

    btnElement.addEventListener('click', () => {
        let inputText = inputElement.value.charAt(0).toUpperCase() + inputElement.value.slice(1).toLocaleLowerCase()
        let index = inputText.charCodeAt(0) - 65;
        console.log(inputText)
        console.log(index)
        if (orderedListElement[index].textContent === '') {
            orderedListElement[index].textContent = inputText;
        }else{
            orderedListElement[index].textContent += `, ${inputText}`;
        }
        inputElement.value = '';
    })    
}