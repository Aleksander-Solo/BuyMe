const urlParams = new URLSearchParams(window.location.search);
axios.get('https://olopl.bsite.net/api/Book/' + urlParams.get('id'))
      .then(response => {
        const book = response.data
        // append to DOM
        if(response.status == 200){
            appendToDOM(book)
        }
      })
      .catch(error => badRequest())

      const appendToDOM = book => {
        const title = document.querySelector('#Title')
        title.innerHTML = "Tytuł: " + book.title
        const price = document.querySelector('#Price')
        price.innerHTML = "Cena: " + book.price + " zł."
        const publishinghosue = document.querySelector('#Publishinghosue')
        publishinghosue.innerHTML = "Wydawnictwo: " + book.publishinghosue
        const releasedate = document.querySelector('#Releasedate')
        releasedate.innerHTML = "Data premiery: " + book.releasedate
        const numOfPag = document.querySelector('#NumOfPag')
        numOfPag.innerHTML = "Liczba stron: " + book.numOfPag
        const bookCategory = document.querySelector('#BookCategory')
        bookCategory.innerHTML = "Gatunek: " + book.bookCategory
        const opis = document.querySelector('#opis')
        opis.innerHTML = "Opis: " + book.description
        const image = document.querySelector('#product-photo-img')
        image.src = 'data:image/jpg;base64, ' + book.image
      }

      const badRequest = () =>{
        const title = document.querySelector('#Title')
        title.innerHTML = "Niema takiej książki!"
      }