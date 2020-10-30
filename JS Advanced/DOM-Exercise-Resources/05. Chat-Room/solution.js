function solve() {
   let buttonElement = document.querySelector("button[id='send']");
   let inputElement = document.querySelector("textarea[id='chat_input']");
   let sendAreaElement = document.querySelector("div[id='chat_messages']");
   console.log(inputElement.textContent);

   buttonElement.addEventListener('click', () => {      
      let textMsg = inputElement.value;
      let newMsgSended = document.createElement('div');
      newMsgSended.className = "message my-message";
      newMsgSended.innerHTML = textMsg;
      sendAreaElement.appendChild(newMsgSended);      
      inputElement.value = '';
   })
}


