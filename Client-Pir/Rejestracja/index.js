function Register(){
    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value
    const name = document.querySelector("#Name").value
    const picture = ""
    const registerObject = {name, email, password, picture}
    sendUser(registerObject)
}

const sendUser = registerObject => {
    debugger
    axios({
        method: 'post',
        url: 'https://olopl.bsite.net/api/Account/register',
        data: registerObject,
        headers: {
            'Content-Type': 'application/json',
            'Content-Length': book.length,
            'authority': "https://olopl.bsite.net",
            "Access-Control-Allow-Origin": "*"
          }
      }).then((response) => {
        console.log(response.status);
        if(response.status == 200){
          window.location.href = "D:/BuyMe/BuyMe/Client-Pir/Produkty/index.html"
        }
      }).catch(error => badRequest());
      const badRequest = () =>{
            const box = document.querySelector("#log-box")
            const erro = document.querySelector(".error")
            if(!erro){
                const err = document.createElement("h1")
                err.classList.add("error")
                err.innerHTML = "Dane niepoprawne!"
                box.appendChild(err)
            }
      }
  }