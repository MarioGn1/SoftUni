function solve() {
   let tbodyElement = document.getElementsByTagName('tbody')[0];
   let tdataElements = Array.from(tbodyElement.getElementsByTagName('td'));
   let tableRowElement = Array.from(tbodyElement.getElementsByTagName('tr'));

   let searchFieldElement = document.getElementById('searchField');
   let searchBtnElement = document.getElementById('searchBtn');

   searchBtnElement.addEventListener('click', search)

   function search() {
      tableRowElement.forEach(el => el.classList.remove('select'))
      tdataElements.filter(td => td.textContent.includes(searchFieldElement.value.toString()))
         .forEach(el => el.parentElement.classList.add('select'));
      searchFieldElement.value = '';
   }
}