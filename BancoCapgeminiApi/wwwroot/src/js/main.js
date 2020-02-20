const uri = "api";

function getClientes() {
  let uriClientes = uri + "/clientes/";
  fetch(uriClientes)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error("Unable to get items.", error));
}

function addCliente() {
  const addNameTextbox = document.getElementById("add-name");
  const uriClientes = uri + "/clientes";
  const item = {
    Nome: addNameTextbox.value.trim()
  };
  fetch(uriClientes, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getClientes();

      addNameTextbox.value = "";
    })
    .catch(error => console.error("Unable to add item.", error));
}

function _displayItems(data) {
  let dropdown = document.getElementById("titular");

  for (let i = 0; i < data.length; i++) {
    option = document.createElement("option");
    option.text = data[i].nome;
    option.value = data[i].id;
    dropdown.add(option);
  }

  dropdown.addEventListener("change", event => {
    let selectElement = event.target;
    let value = selectElement.value;
    buscaSaldo(value);
  });
}

function buscaSaldo(value) {
  let saldo = document.getElementById("saldo");

  const uriClientes = uri + "/contas/" + value;
  fetch(uriClientes)
    .then(response => response.json())
    .then((data) => {
      console.log(data);
      saldo.innerHTML = data;
    });
}

function depositar(){

  let dropdown = $("#titular").val();
  const uriClientes = uri + "/deposito";
  const moedaTextbox = document.getElementById("edit-moeda");

  const item =  {
    TitularId: parseInt(dropdown),
    Moeda: parseFloat(moedaTextbox.value.trim())
  }

  console.log(item);

  fetch(uriClientes, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
    },
    body: JSON.stringify(item)
  })
  .then(response =>  response.json())
  .then((data) => {
    console.log(data.titularId);
    moedaTextbox.value = "";
    buscaSaldo(data.titularId);
  })
  .catch(error => console.error("Unable to add item.", error));
}

function sacar(){
  let dropdown = $("#titular").val();

  const uriClientes = uri + "/saque";
  const moedaTextbox = document.getElementById("edit-moeda");

  const item = {
    TitularId: parseInt(dropdown),
    Moeda: parseFloat(moedaTextbox.value)
  }

  console.log(item);
  fetch(uriClientes, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
    },
    body: JSON.stringify(item)
  })
  .then(response => response.json())
  .then((data) => {
    console.log(data.titularId);
    moedaTextbox.value = "";
    buscaSaldo(data.titularId);
  })
  .catch(error => console.error("Unable to add item.", error));
}
