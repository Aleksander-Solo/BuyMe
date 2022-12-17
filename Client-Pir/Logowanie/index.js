function send(){
    debugger
    const email = document.querySelector('#email').value
    const password = document.querySelector('#password').value
    const book = { email, password}
    register(book)
}

const register = user => {
    debugger
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
        localStorage.setItem("access_token", response.data)
        debugger
      })
      .catch(error => console.error(error));
      debugger
  }