var totalPrice = 0

  const createItem = item => {
    const divbox = document.createElement("div");
    divbox.classList.add("content-box");
    //Name
    const divName = document.createElement("div");
    divName.innerHTML = item.title;
    divName.classList.add("box-nazwa");
    //Price
    const divPrice = document.createElement("div");
    divPrice.innerHTML = item.price;
    divPrice.classList.add("box-cena");
    //Price
    const divDelete = document.createElement("div");
    divDelete.innerHTML = "Usuń";
    divDelete.classList.add("box-out");
    //append
    divbox.appendChild(divName)
    divbox.appendChild(divPrice)
    divbox.appendChild(divDelete)

    totalPrice += item.price;
    const suma = document.querySelector("#suma-text-2");
    suma.innerHTML = totalPrice + " zł."

    return divbox
  }
  
var items = JSON.parse(localStorage.getItem("shopCard"));
const box = document.querySelector("#koszyk-box");
items.map(item => {
    box.appendChild(createItem(item))
  })
