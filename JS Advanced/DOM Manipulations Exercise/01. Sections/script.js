function create(words) {
   let contentElements = document.getElementById('content');
   words.forEach(str => {
      let curDivElement = document.createElement('div');
      let curPElement = document.createElement('p');
      curPElement.innerText = str;
      curPElement.style.display = 'none';
      curDivElement.appendChild(curPElement);
      contentElements.appendChild(curDivElement);
   });
   contentElements.addEventListener('click', function(e){
      
      if (e.target.tagName == 'DIV') {
         e.target.firstChild.style.display ='block';
      }
   })
}