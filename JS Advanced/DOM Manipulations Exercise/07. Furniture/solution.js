function solve() {
  let tbodyElement = document.getElementsByTagName('tbody')[0];
  let genBtnElement = document.getElementsByTagName('button')[0];
  let buyBtnElement = document.getElementsByTagName('button')[1];
  let inputElement = document.getElementsByTagName('textarea')[0];
  let outputElement = document.getElementsByTagName('textarea')[1];
  
  genBtnElement.addEventListener('click', generate);
  buyBtnElement.addEventListener('click', buy);

  function generate() {
    let objs = JSON.parse(inputElement.value);

    objs.forEach(obj => {
      let rowElement = document.createElement('tr');

      let tdImgElement = document.createElement('td');
      let tdNameElement = document.createElement('td');
      let tdPriceElement = document.createElement('td');
      let tdFactorElement = document.createElement('td');
      let tdCheckBoxElement = document.createElement('td');

      let imgElement = document.createElement('img')
      let pNameElement = document.createElement('p');
      let pPriceElement = document.createElement('p');
      let pFactorElement = document.createElement('p');
      let checkBoxElement = document.createElement('input');

      Object.keys(obj).forEach(prop => {
        switch (prop) {
          case 'img':            
            imgElement.src = obj[prop];
            tdImgElement.appendChild(imgElement);
            break;
          case 'name':            
            pNameElement.textContent = obj[prop];
            tdNameElement.appendChild(pNameElement);
            break;
          case 'price':            
            pPriceElement.textContent = obj[prop];
            tdPriceElement.appendChild(pPriceElement)
            break;
          case 'decFactor':            
            pFactorElement.textContent = obj[prop];
            tdFactorElement.appendChild(pFactorElement)
            break;
          default:
            break;
        }
      })           
      checkBoxElement.type = 'checkbox';
      tdCheckBoxElement.appendChild(checkBoxElement);

      rowElement.appendChild(tdImgElement);
      rowElement.appendChild(tdNameElement);
      rowElement.appendChild(tdPriceElement);
      rowElement.appendChild(tdFactorElement);      
      rowElement.appendChild(tdCheckBoxElement);

      tbodyElement.appendChild(rowElement);
    });
  }

  function buy() {
    let products = [];
    let price = 0;
    let factor = 0;

    let checkedElements = Array.from(document.getElementsByTagName('input')).filter(el => el.checked);

    checkedElements.forEach(element => {
      let parentRowElement = element.parentElement.parentElement;
      let productInfoElements = Array.from(parentRowElement.getElementsByTagName('p'));

      products.push(productInfoElements[0].innerText);
      price += Number(productInfoElements[1].innerText);
      factor += Number(productInfoElements[2].innerText);
    });

    outputElement.value = `Bought furniture: ${products.join(', ')}\n`
      + `Total price: ${price.toFixed(2)}\n`
      + `Average decoration factor: ${factor / checkedElements.length}`;

  }
}