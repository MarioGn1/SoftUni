function toggle() {
   let linkElement = document.getElementsByClassName('button')[0];
   let textElement = document.getElementById('extra');
  
   if (linkElement.innerHTML === 'More') {
       textElement.style.display = 'block';
       linkElement.innerHTML = 'Less';
   }else{
    linkElement.innerHTML = 'More';
    textElement.style.display = 'none';
   }
   
}

