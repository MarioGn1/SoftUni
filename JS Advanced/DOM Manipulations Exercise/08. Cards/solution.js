function solve() {
   let sectionCardsElement = document.getElementsByClassName('cards')[0];
   let resultElment = Array.from(sectionCardsElement.getElementsByTagName('span'));
   let firstPlayerDeck = document.getElementById('player1Div');
   let historyElement = document.getElementById('history');

   let firstChoiceElement = null;
   let secondChoiceElement = null;

   sectionCardsElement.addEventListener('click', chooseCards);

   function chooseCards(e) {
      if (resultElment[0].innerText && resultElment[2].innerText) {
         resultElment[0].innerText = '';
         resultElment[2].innerText = '';         
      }

      if (resultElment[0].innerText === '' && e.target.className !== 'used' && e.target.parentElement === firstPlayerDeck) {

         resultElment[0].innerText = e.target.name;
         firstChoiceElement = e.target;
         e.target.src = 'images/whiteCard.jpg';

      } else if (resultElment[2].innerText === '' && e.target.parentElement !== firstPlayerDeck && e.target.className !== 'used') {

         resultElment[2].innerText = e.target.name;
         secondChoiceElement = e.target;
         e.target.src = 'images/whiteCard.jpg';

      }

      if (resultElment[0].innerText && resultElment[2].innerText) {

         if (Number(firstChoiceElement.name) > Number(secondChoiceElement.name)) {
            firstChoiceElement.style.border = '2px solid green';
            secondChoiceElement.style.border = '2px solid red';
         } else if (Number(firstChoiceElement.name) < Number(secondChoiceElement.name)) {
            firstChoiceElement.style.border = '2px solid red';
            secondChoiceElement.style.border = '2px solid green';
         }
         firstChoiceElement.classList.add('used');
         secondChoiceElement.classList.add('used');

         if (firstChoiceElement.parentElement === firstPlayerDeck) {
            historyElement.innerText += `[${firstChoiceElement.name} vs ${secondChoiceElement.name}] `;
         } else {
            historyElement.innerText += `[${secondChoiceElement.name} vs ${firstChoiceElement.name}] `;
         }
      }
   }
}