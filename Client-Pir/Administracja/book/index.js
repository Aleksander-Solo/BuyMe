function send(){
    const image = document.querySelector('#Image').value
    const title = document.querySelector('#Title').value
    const publishinghosue = document.querySelector('#Publishinghosue').value
    const releasedate = document.querySelector('#Releasedate').value
    const numOfPag = document.querySelector('#NumOfPag').value
    const description = document.querySelector('#Description').value
    const price = document.querySelector('#Price').value
    const book = { image, title, publishinghosue, releasedate, numOfPag, description, price}
    createBook(book)
}

const createBook = book => {
    let axiosConfig = {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
            "Access-Control-Allow-Origin": "*",
      
        }}
    axios.post('https://olopl.bsite.net/api/Book', book, axiosConfig)
      .then(response => {
        console.log(response.status);
      })
      .catch(error => console.error(error))
  }
  
