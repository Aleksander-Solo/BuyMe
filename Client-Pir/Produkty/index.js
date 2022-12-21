let newcategorie = ""
function sortFun(){
  const sort = document.querySelector('#sort').value
  const main = document.getElementById("main-product");
  main.innerHTML = '';
  axios
      .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber='+ actualPage +'&sort=' + sort + '&category=' + newcategorie)
      .then(response => {
        const books = response.data.items
        // append to DOM
        console.log(response.data.items);
        appendToDOM(books)
        debugger
        CreatePaggination(response.data.totalPages)
        debugger
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
    a.href = `/BuyMe/Produkty/Szczegoly/index.html?id=${book.id}`
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
    //iterate over all books
    books.map(book => {
        list.appendChild(createA(book))
    })
  }
  
  const fetchUsers = () => {
    axios
      .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1')
      .then(response => {
        const books = response.data.items
        // append to DOM
        console.log(response.data.items);
        appendToDOM(books)
        CreatePaggination(response.data.totalPages)
        debugger
      })
      .catch(error => console.error(error))
      
  }

  axios
      .get('https://olopl.bsite.net/api/Book/categories')
      .then(response => {
        const categories = response.data
        // append to DOM
        console.log(response.data);
        appendCategories(categories)
      })
      .catch(error => console.error(error))
  
      const appendCategories = categories => {
        const select = document.querySelector('#cat-book-list')
        //iterate over all books
        categories.map(categorie => {
          select.appendChild(createOption(categorie))
        })
      }
      const createOption = categorie => {
        const option = document.createElement('div')
        option.id = "categorie"
        option.innerHTML = categorie.name
        option.addEventListener('click', function() {
          const sort = document.querySelector('#sort')
          sort.value = ""
          newcategorie = categorie.name
          const main = document.getElementById("main-product");
          main.innerHTML = '';
          axios
              .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1&category=' + categorie.name)
              .then(response => {
                const books = response.data.items
                // append to DOM
                console.log(response.data.items);
                appendToDOM(books)
                CreatePaggination(response.data.totalPages)
              })
              .catch(error => console.error(error))
                }, false);
          return option
      }

  fetchUsers()
  const  CreatePaggination = pageNumber =>{
    const paggination = document.querySelector("#paggination")
    paggination.innerHTML = ""
    for(i = 1; i < pageNumber + 1; i++)
    {
      const pag = document.createElement('div')
      pag.classList.add("pag")
      pag.innerHTML = i
      pag.addEventListener('click', function() {
        axios
          .get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=' +  pag.innerHTML +'&category=' + newcategorie)
          .then(response => {
            const books = response.data.items
            // append to DOM
            console.log('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=' +  pag.innerHTML +'&category=' + newcategorie);
            const main = document.getElementById("main-product");
            main.innerHTML = '';
            actualPage = pag.innerHTML
            appendToDOM(books)
            const sort = document.querySelector('#sort')
            sort.value = ""
          })
          .catch(error => console.error(error))
            }, false);
            paggination.appendChild(pag)
    }
  }