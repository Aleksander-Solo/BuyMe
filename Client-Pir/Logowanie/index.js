function send(){
    const email = document.querySelector('#email').value
    const password = document.querySelector('#password').value
    const book = { email, password}
    register(book)
}

const register = user => {
    const config = {
        headers:{
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
            "Access-Control-Allow-Origin": "*"
        }
      };
    axios({
        method: 'post',
        url: 'https://olopl.bsite.net/api/Account/login',
        data: user
      }).then(response => {
        localStorage.setItem("access_token", response.data.token)
        localStorage.setItem("user_name", response.data.name)
        localStorage.setItem("user_role", response.data.role)
        localStorage.setItem("user_id", response.data.id)
        if(response.status == 200){
          debugger
          if(localStorage.getItem("user_role") == "Owner" || localStorage.getItem("user_role") == "Admin"){
            debugger
            window.location.href = "D:/BuyMe/BuyMe/Client-Pir/Administracja/index.html"
          }else{
            debugger
            window.location.href = "D:/BuyMe/BuyMe/Client-Pir/Produkty/index.html"
          }
        }
      }).catch(error => badRequest());
  }
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