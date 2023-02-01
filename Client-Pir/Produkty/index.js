const urlParams = new URLSearchParams(window.location.search);

function Spinner(){
  const list = document.querySelector('#main-product')
  const spinner = document.createElement('div')
  spinner.classList.add('spinner');
  list.appendChild(spinner);
}
let target = "Book";
let newcategorie = ""
function sortFun(){
  const sort = document.querySelector('#sort').value
  const main = document.getElementById("main-product");
  main.innerHTML = "";
  Spinner();
  debugger
  axios
      .get('https://olopl.bsite.net/api/'+ target +'?pageSize=8&PageNumber='+ actualPage +'&sort=' + sort + '&category=' + newcategorie)
      .then(response => {
        const books = response.data.items
        // append to DOM
        console.log(response.data.items);
        appendToDOM(books)
        CreatePaggination(response.data.totalPages)
      })
      .catch(error => console.error(error))
}

let actualPage = 1

const createDiv = book => {
    const box = document.createElement('div')
    box.classList.add('product-box');
    box.appendChild(createPhoto(book))
    box.appendChild(createPrice(book))
    return box
  }
  const createA = book => {
    const a = document.createElement('a')
    a.classList.add('link-prod');
    a.href = `/Produkty/Szczegoly/index.html?id=${book.id}&target=${target}`
    a.appendChild(createDiv(book))
    return a
  }
  const createPrice = book => {
    const price = document.createElement('h4')
    price.classList.add('product-price');
    price.setAttribute('style', 'white-space: pre;');
    price.textContent = `${book.title} \r\n `
    price.textContent += `${book.price} zł.`
    return price
  }
  const createPhoto = book => {
    const photo = document.createElement('div')
    photo.classList.add('product-photo');
    photo.appendChild(createImg(book))
    return photo
  }

  const createImg = book => {
    const img = document.createElement('img')
    img.classList.add('product-photo-img');
    img.src = 'data:image/jpg;base64, ' + book.image
    return img
  }
  
  const appendToDOM = books => {
    const list = document.querySelector('#main-product')
    list.innerHTML = ""
    //iterate over all books
    books.map(book => {
        list.appendChild(createA(book))
    })
  }
  const appendCategories = (categories, id)=> {
    const select = document.querySelector(id)
    //iterate over all books
    categories.map(categorie => {
      if(id == '#cat-book-list'){
        select.appendChild(ProductBook(categorie))
      }else if(id == '#cat-game-list'){
        select.appendChild(ProductGame(categorie))
      }
    })
  }

  function Start(){
    axios
      .get('https://olopl.bsite.net/api/Book/categories')
      .then(response => {
        const categories = response.data
        // append to DOM
        console.log(response.data);
        appendCategories(categories, '#cat-book-list')
      })
      .catch(error => console.error(error))
      axios
      .get('https://olopl.bsite.net/api/Game/categories')
      .then(response => {
        const categories = response.data
        // append to DOM
        console.log(response.data);
        appendCategories(categories, '#cat-game-list')
      })
      .catch(error => console.error(error))
      

    if(urlParams.get('target') == "Book"){
      target = "Book";
        axios
          .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1')
          .then(response => {
            const books = response.data.items
            // append to DOM
            console.log(response.data.items);
            appendToDOM(books)
            CreatePaggination(response.data.totalPages)
          })
          .catch(error => console.error(error))
    }else if(urlParams.get('target') == "Game"){
      target = "Game";
        axios
          .get('https://olopl.bsite.net/api/Game?pageSize=8&PageNumber=1')
          .then(response => {
            const books = response.data.items
            // append to DOM
            console.log(response.data.items);
            appendToDOM(books)
            CreatePaggination(response.data.totalPages)
          })
          .catch(error => console.error(error))
    }else if(urlParams.get('target') == "Film"){
      target = "Film";
        axios
          .get('https://olopl.bsite.net/api/Film?pageSize=8&PageNumber=1')
          .then(response => {
            const books = response.data.items
            // append to DOM
            console.log(response.data.items);
            appendToDOM(books)
            CreatePaggination(response.data.totalPages)
          })
          .catch(error => console.error(error))
  }else{
    axios
          .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1')
          .then(response => {
            const books = response.data.items
            // append to DOM
            console.log(response.data.items);
            appendToDOM(books)
            CreatePaggination(response.data.totalPages)
          })
          .catch(error => console.error(error))
  }}

      const ProductBook = categorie => {
        const option = document.createElement('div')
        option.id = "categorie"
        option.innerHTML = categorie.name
        option.addEventListener('click', function() {
          const sort = document.querySelector('#sort');
          newcategorie = categorie.name;
          const main = document.getElementById("main-product");
          main.innerHTML = '';
          Spinner();
          axios
              .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1&category=' + categorie.name + '&sort=' + sort.value)
              .then(response => {
                const books = response.data.items
                // append to DOM
                console.log(response.data.items);
                target = "Book";
                appendToDOM(books)
                CreatePaggination(response.data.totalPages)
              })
              .catch(error => console.error(error))
                }, false);
          return option
      }

      const ProductGame = categorie => {
        const option = document.createElement('div')
        option.id = "categorie"
        option.innerHTML = categorie.name
        option.addEventListener('click', function() {
          const sort = document.querySelector('#sort');
          newcategorie = categorie.name;
          const main = document.getElementById("main-product");
          main.innerHTML = '';
          Spinner();
          axios
              .get('https://olopl.bsite.net/api/Game?pageSize=8&PageNumber=1&category=' + categorie.name + '&sort=' + sort.value)
              .then(response => {
                const books = response.data.items
                // append to DOM
                console.log(response.data.items);
                target = "Game";
                appendToDOM(books)
                CreatePaggination(response.data.totalPages)
              })
              .catch(error => console.error(error))
                }, false);
          return option
      }

  Start();
  const  CreatePaggination = pageNumber =>{
    const paggination = document.querySelector("#paggination")
    paggination.innerHTML = ""
    for(i = 1; i < pageNumber + 1; i++)
    {
      const pag = document.createElement('div')
      pag.classList.add("pag")
      pag.innerHTML = i
      pag.addEventListener('click', function() {
        const main = document.getElementById("main-product");
        main.innerHTML = '';
        const sort = document.querySelector('#sort')
        Spinner();
        debugger
        axios
          .get('https://olopl.bsite.net/api/'+ target +'?pageSize=8&PageNumber=' +  pag.innerHTML +'&category=' + newcategorie + '&sort=' + sort.value)
          .then(response => {
            const books = response.data.items
            main.innerHTML = '';
            actualPage = pag.innerHTML
            appendToDOM(books)
            debugger
          })
          .catch(error => console.error(error))
            }, false);
            paggination.appendChild(pag)
    }}