const urlParams = new URLSearchParams(window.location.search);
axios.get('https://olopl.bsite.net/api/Book/' + urlParams.get('id'))
      .then(response => {
        const book = response.data
        // append to DOM
        if(response.status == 200){
            appendToDOM(book)
            CreateComments(response.data.bookComments)
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
        opis.innerHTML += book.description
        const image = document.querySelector('#product-photo-img')
        image.src = 'data:image/jpg;base64, ' + book.image
      }

      const CreateComments = comments => {
        const kom = document.querySelector('#kom')
        comments.map(comment => {
          kom.appendChild(createComment(comment))
        })
      }

      const createComment = commment => {
        const divComment = document.createElement("div");
        divComment.classList.add("kometarze");
        divComment.innerHTML = commment.userName + ', ' + commment.title;
        const divContent = document.createElement("div");
        divContent.innerHTML = commment.content;
        divContent.classList.add("komCom");
        divComment.appendChild(divContent)
        return divComment;
      }

      const badRequest = () =>{
        const title = document.querySelector('#Title')
        title.innerHTML = "Niema takiej książki!"
      }

      function addComment(){
        const Title = document.getElementById("titleComment").value
        const Content = document.querySelector("#Content").value
        const UserId = localStorage.getItem("user_id")
        const BookId =  urlParams.get('id')
        const comment = {Title, Content, UserId, BookId}
        console.log(comment)
        axios({
          method: 'post',
          url: 'https://olopl.bsite.net/api/Book/comment',
          data: comment,
          headers: {
              'Content-Type': 'application/json',
              'Content-Length': book.length,
              'authority': "https://olopl.bsite.net",
              "Access-Control-Allow-Origin": "*"
            }
        }).then((response) => {
          console.log(response.status);
          if(response.status == 200){
            location.reload()
          }
        }).catch(error => console.error(error));

      }

      function addToShopCard(){
        axios.get('https://olopl.bsite.net/api/Book/' + urlParams.get('id'))
        .then(response => {
          const book = response.data
          if(response.status == 200){
            let booksShop = []
            if (localStorage.getItem("shopCard") === null)
            {
              booksShop.push(book);
              localStorage.setItem("shopCard", JSON.stringify(booksShop))
            }else
            {
              booksShop = JSON.parse(localStorage.getItem("shopCard"))
              booksShop.push(book);
              localStorage.setItem("shopCard", JSON.stringify(booksShop))
            }
          }
        })
        .catch(error => console.error(error))
      }