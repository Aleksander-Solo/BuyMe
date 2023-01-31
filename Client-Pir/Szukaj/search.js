const input = document.querySelector('#search');
const urlParams = new URLSearchParams(window.location.search);

let target = "Book";

axios.get('https://olopl.bsite.net/api/Book?pageSize=8&PageNumber=1&phrase=' + urlParams.get('search'))
      .then(response => {
        const books = response.data.items
        // append to DOM
        console.log(response.data.items);
        appendToDOMBook(books)
      })
      .catch(error => console.error(error))

axios.get('https://olopl.bsite.net/api/Game?pageSize=8&PageNumber=1&phrase=' + urlParams.get('search'))
      .then(response => {
        const games = response.data.items
        // append to DOM
        console.log(response.data.items);
        appendToDOMGame(games)
      })
      .catch(error => console.error(error))

// axios.get('https://olopl.bsite.net/api/Film?pageSize=8&PageNumber=1&phrase=' + urlParams.get('search'))
//       .then(response => {
//         const films = response.data.items
//         // append to DOM
//         console.log(response.data.items);
//         appendToDOM(films)
//       })
//       .catch(error => console.error(error))

      const appendToDOMGame = items => {
        const list = document.querySelector('#Games');
        target = "Game";
        //iterate over all books
        items.map(item => {
            list.appendChild(createA(item))
        })
      }

      const appendToDOMBook = items => {
        const list = document.querySelector('#Books');
        target = "Book";
        //iterate over all books
        items.map(item => {
            list.appendChild(createA(item))
        })
      }


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
        a.href = `/BuyMe/Produkty/Szczegoly/index.html?id=${book.id}&target=${target}`
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