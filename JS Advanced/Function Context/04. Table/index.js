function solve() {
    let tbodyElement = document.getElementsByTagName('tbody')[0];
    let tableRowsElements = Array.from(tbodyElement.getElementsByTagName('tr'));

    tbodyElement.addEventListener('click', markRow);

    function markRow(e) {               
        if (e.target.tagName === 'TD' && e.target.parentElement.style.backgroundColor === '') {            
            e.target.parentElement.style.backgroundColor = '#413f5e';
            tableRowsElements.forEach(tr => {
                if(tr!== e.target.parentElement){
                    tr.style.backgroundColor = '';
                }                
            }); 
        }else{
            e.target.parentElement.style.backgroundColor = '';
        }
        
    }
}