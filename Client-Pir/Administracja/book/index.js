function send(){
  let flag = true
    const image = binaryString
    const title = document.querySelector('#Title').value
    if(title == ""){
      flag = false
      const titleInput = document.querySelector('#Title')
      titleInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Title')
      descriptionInput.classList.remove("input-text-error")
    }
    const author = document.querySelector('#Author').value
    if(author == ""){
      flag = false
      const authorInput = document.querySelector('#Author')
      authorInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Author')
      descriptionInput.classList.remove("input-text-error")
    }
    const publishinghosue = document.querySelector('#Publishinghosue').value
    if(publishinghosue == ""){
      flag = false
      const publishinghosueInput = document.querySelector('#Publishinghosue')
      publishinghosueInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Publishinghosue')
      descriptionInput.classList.remove("input-text-error")
    }
    const releasedate = document.querySelector('#Releasedate').value
    if(releasedate == ""){
      flag = false
      const releasedateInput = document.querySelector('#Releasedate')
      releasedateInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Releasedate')
      descriptionInput.classList.remove("input-text-error")
    }
    const numOfPag = document.querySelector('#NumOfPag').value
    if(numOfPag == ""){
      flag = false
      const numOfPagInput = document.querySelector('#NumOfPag')
      numOfPagInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#NumOfPag')
      descriptionInput.classList.remove("input-text-error")
    }
    const description = document.querySelector('#Description').value
    if(description == ""){
      flag = false
      const descriptionInput = document.querySelector('#Description')
      descriptionInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Description')
      descriptionInput.classList.remove("input-text-error")
    }
    const price = document.querySelector('#Price').value
    if(price == ""){
      flag = false
      const priceInput = document.querySelector('#Price')
      priceInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Price')
      descriptionInput.classList.remove("input-text-error")
    }
    const bookCategoryId = document.querySelector('#Categories').value
    if(bookCategoryId == 0){
      flag = false
      const priceInput = document.querySelector('#Categories')
      priceInput.classList.add("input-text-error")
    }else{
      flag = true
      const descriptionInput = document.querySelector('#Categories')
      descriptionInput.classList.remove("input-text-error")
    }
    if(flag){
      const book = { image, title, author, publishinghosue, releasedate, numOfPag, description, price, bookCategoryId}
      console.log(book)
      createBook(book)
    }
}

var binaryString = ""

document.querySelector('#Image').addEventListener('change', function() {

    var reader = new FileReader();
    reader.onload = function() {
        const form = document.querySelector('#formularz')
      var arrayBuffer = this.result,
        array = new Uint8Array(arrayBuffer),
        byteArray = btoa(String.fromCharCode.apply(null, array));
        form.appendChild(createImg(byteArray))
        binaryString = byteArray
    }
    reader.readAsArrayBuffer(this.files[0]);
    const section = document.querySelector("#admin-panel")
    section.id = "admin-panel2"
  }, false);

  const createImg = byteArray => {
    if(binaryString == ""){
      const img = document.createElement('img')
      img.classList.add('imageView');
      img.src = 'data:image/jpg;base64, ' + byteArray
      return img
    }else{
      const img = document.querySelector('img')
      img.src = 'data:image/jpg;base64, ' + byteArray
      return img
    }
  }

const createBook = book => {  
    axios({
        method: 'post',
        url: 'https://olopl.bsite.net/api/Book',
        data: book,
        headers: {
            'Content-Type': 'application/json',
            'Content-Length': book.length,
            'authority': "https://olopl.bsite.net",
            'Authorization': `Bearer ${localStorage.getItem("access_token")}`,
            "Access-Control-Allow-Origin": "*"
          }
      }).then((response) => {
        debugger
        console.log(response.status);
        console.log(book);
        if(response.status == 201){
          window.location.href = "D:/BuyMe/BuyMe/Client-Pir/Produkty/index.html"
        }
      });
  }

  const appendToDOM = categories => {
    const select = document.querySelector('#Categories')
    //iterate over all books
    categories.map(categorie => {
      select.appendChild(createOption(categorie))
    })
  }

  const createOption = categorie => {
    const option = document.createElement('option')
    option.value = categorie.id
    option.innerHTML = categorie.name
    return option
  }
  
  axios
      .get('https://olopl.bsite.net/api/Book/categories')
      .then(response => {
        const categories = response.data
        // append to DOM
        console.log(response.data);
        appendToDOM(categories)
      })
      .catch(error => console.error(error))