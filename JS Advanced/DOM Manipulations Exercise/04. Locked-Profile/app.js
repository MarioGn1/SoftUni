function lockedProfile() {
    let mainDivElement = document.getElementById('main');

    mainDivElement.addEventListener('click', function (e) {        
        if (e.target.tagName === 'BUTTON') {            
            let parentEl = e.target.parentElement;
            let radioEls = parentEl.querySelectorAll("input[type='radio']");          
            
            if (radioEls[1].checked === true) {
                if (e.target.innerHTML === 'Show more') {
                    e.target.innerHTML = 'Hide it'
                    e.target.previousElementSibling.style.display = 'block';
                }else{
                    e.target.innerHTML = 'Show more'
                    e.target.previousElementSibling.style.display = 'none';
                }
            }            
        }
    })
}