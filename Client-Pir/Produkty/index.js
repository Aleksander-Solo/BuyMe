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
    const price = document.createElement('div')
    price.classList.add('product-price');
    price.setAttribute('style', 'white-space: pre;');
    price.textContent = `${book.title} ${book.author} \r\n `
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
    img.src = book.image
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
      .get('https://olopl.bsite.net/api/Book?pageSize=9&PageNumber=1')
      .then(response => {
        const books = response.data.items
        // append to DOM
        appendToDOM(books)
      })
      .catch(error => console.error(error))
  }
  
  fetchUsers()