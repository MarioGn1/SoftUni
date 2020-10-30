function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.value = newItemValueElement.value;
    optionElement.textContent = newItemTextElement.value;

    let menuElement = document.getElementById('menu');
    menuElement.appendChild(optionElement);
    newItemTextElement.value = '';
    newItemValueElement.value = '';
    console.log()
}

addItem()