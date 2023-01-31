const urlParams = new URLSearchParams(window.location.search);

Spinner();
debugger
if(urlParams.get("target") == "Book"){
    axios.get('https://olopl.bsite.net/api/Book/' + urlParams.get('id'))
        .then(response => {
          const book = response.data
          // append to DOM
          if(response.status == 200){
              appendToDOMBook(book);
              CreateComments(response.data.bookComments);
          }
        })
        .catch(error => badRequest())
}else if(urlParams.get("target") == "Game"){
    axios.get('https://olopl.bsite.net/api/Game/' + urlParams.get('id'))
        .then(response => {
          const game = response.data
          // append to DOM
          if(response.status == 200){
              appendToDOMGame(game);
              CreateComments(response.data.gameComments);
          }
        })
        .catch(error => badRequest())
}else if(urlParams.get("target") == "Film"){
    axios.get('https://olopl.bsite.net/api/Film/' + urlParams.get('id'))
    .then(response => {
      const film = response.data
      // append to DOM
      if(response.status == 200){
          appendToDOM(film);
          CreateComments(response.data.filmComments);
      }
    })
    .catch(error => badRequest())
}

  const appendToDOMGame = game => {
    const dane = document.getElementById("dane");
    dane.innerHTML = "";
    const title = document.createElement('div');
    title.innerHTML = "Tytuł: " + game.title;
    title.className = "text-product-title";
    dane.appendChild(title);
    //        ***********************
    const hr = document.createElement('hr');
    dane.appendChild(hr);
    const price = document.createElement('div');
    price.innerHTML = "Cena: " + game.price + " zł.";
    price.className = "text-product";
    dane.appendChild(price);
    const producer = document.createElement('div');
    producer.innerHTML = "Producent: " + game.producer;
    producer.className = "text-product";
    dane.appendChild(producer);
    const releasedate = document.createElement('div');
    releasedate.innerHTML = "Data premiery: " + game.releasedate;
    releasedate.className = "text-product";
    dane.appendChild(releasedate);
    const carrier = document.createElement('div');
    carrier.innerHTML = "Nośnik: " + game.carrier;
    carrier.className = "text-product";
    dane.appendChild(carrier);
    const gameCategory = document.createElement('div');
    gameCategory.innerHTML = "Gatunek: " + game.gameCategory
    gameCategory.className = "text-product";
    dane.appendChild(gameCategory);
    const opis = document.querySelector('#opis')
    opis.innerHTML += game.description
    const image = document.querySelector('#product-photo-img')
    image.src = 'data:image/jpg;base64, ' + game.image
    SetButtons(dane);
  }

      const appendToDOMBook = book => {
        const dane = document.getElementById("dane");
        dane.innerHTML = "";
        const title = document.createElement('div');
        title.innerHTML = "Tytuł: " + book.title;
        title.className = "text-product-title";
        dane.appendChild(title);
        //        ***********************
        const hr = document.createElement('hr');
        dane.appendChild(hr);
        const price = document.createElement('div');
        price.innerHTML = "Cena: " + book.price + " zł.";
        price.className = "text-product";
        dane.appendChild(price);
        const publishinghosue = document.createElement('div');
        publishinghosue.innerHTML = "Wydawnictwo: " + book.publishinghosue;
        publishinghosue.className = "text-product";
        dane.appendChild(publishinghosue);
        const releasedate = document.createElement('div');
        releasedate.innerHTML = "Data premiery: " + book.releasedate;
        releasedate.className = "text-product";
        dane.appendChild(releasedate);
        const numOfPag = document.createElement('div');
        numOfPag.innerHTML = "Liczba stron: " + book.numOfPag;
        numOfPag.className = "text-product";
        dane.appendChild(numOfPag);
        const bookCategory = document.createElement('div');
        bookCategory.innerHTML = "Gatunek: " + book.bookCategory
        bookCategory.className = "text-product";
        dane.appendChild(bookCategory);
        const opis = document.querySelector('#opis')
        opis.innerHTML += book.description
        const image = document.querySelector('#product-photo-img')
        image.src = 'data:image/jpg;base64, ' + book.image
        SetButtons(dane);
      }
      
      function SetButtons(dane){
        const p = document.createElement('p');
        p.style.marginTop = "10px";
        const button = document.createElement('button');
        button.innerHTML = 'Dodaj do koszyka <i class="fa-solid fa-cart-shopping"></i>';
        button.className = "btn btn-success";
        button.addEventListener('click', function(){
          addToShopCard();
        })
        dane.appendChild(p);
        p.appendChild(button);

        let role = localStorage.getItem("user_role");
        if(role == "Owner" || role == "Admin"){
          const buttonDelete = document.createElement('button');
          buttonDelete.innerHTML = 'Usuń z bazy <i class="fa-solid fa-trash"></i>';
          buttonDelete.className = "btn btn-danger";
          buttonDelete.setAttribute("data-bs-toggle", "modal");
          buttonDelete.setAttribute("data-bs-target", "#myModal");
          buttonDelete.style.marginLeft = "10px";
          p.appendChild(buttonDelete);
          const buttonEdit = document.createElement('button');
          buttonEdit.innerHTML = 'Edytuj produkt <i class="fa-regular fa-pen-to-square"></i>';
          buttonEdit.className = "btn btn-warning";
          buttonEdit.style.marginLeft = "10px";
          p.appendChild(buttonEdit);
        }
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
        const dane = document.querySelector('#dane')
        dane.innerHTML = "Niema takiego rekordu!"
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
          url: 'https://olopl.bsite.net/api/'+ urlParams.get("target") +'/comment',
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
        axios.get('https://olopl.bsite.net/api/'+ urlParams.get("target") +'/' + urlParams.get('id'))
        .then(response => {
          const book = response.data
          if(response.status == 200){
            let itemShop = []
            if (localStorage.getItem("shopCard") === null)
            {
              itemShop.push(book);
              localStorage.setItem("shopCard", JSON.stringify(itemShop))
            }else
            {
              itemShop = JSON.parse(localStorage.getItem("shopCard"))
              itemShop.push(book);
              localStorage.setItem("shopCard", JSON.stringify(itemShop))
            }
          }
        })
        .catch(error => console.error(error))
      }

      function Spinner(){
        const list = document.querySelector('#dane')
        const spinner = document.createElement('div')
        spinner.classList.add('spinner');
        list.appendChild(spinner);
        debugger
      }

      function Delete(){
        let token = localStorage.getItem("access_token");
        debugger
        axios.delete('https://olopl.bsite.net/api/'+ urlParams.get("target") +'/' + urlParams.get('id'), {
          headers: {
            Authorization: "Bearer " + token
          }
        }).then(() => alert("Produkt usunienty!"));;
        debugger;
        window.location.href = "D:/BuyMe/BuyMe/Client-Pir/Produkty/index.html";
      }