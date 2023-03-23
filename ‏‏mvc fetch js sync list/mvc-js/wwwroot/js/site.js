
const AddBtn = document.querySelector("#btnAddNewCustomer");
const btnGetAllCustomers = document.getElementById("btnGetAllCustomers");
const AddForm = document.querySelector("#AddForm");
const FnameText = document.querySelector("#Fname");
const LnameText = document.querySelector("#Lname");
const MainList = document.querySelector("#main-list");
const LoadingSpinner = document.querySelector("#LoadingSpinner");

btnGetAllCustomers.addEventListener("click", function (event) {

    console.log("Get Data");
    btnGetAllCustomers.innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
  Loading...`;
    fetch("https://localhost:7054/Customer/GetList")
        .then((response) => {
            if (!response.ok)
                throw new Error("Error");
            return response.json();
        }).then((data) => {
            MainList.innerHTML =
                data.map(el => `<li class="list-group-item">${el.fname} ${el.lname}</li>`)
                    .join("\n");
            console.log(data);
            btnGetAllCustomers.innerHTML = 'Get Data';
        }).catch((err) => {
            console.log(err);
        });

    event.preventDefault();
});


AddForm.addEventListener("submit", (event) => {

    console.log('Add Customer');
    LoadingSpinner.innerHTML = "<p>Loading ...</p>";
    fetch("Customer/AddJSON", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Fname: FnameText.value, Lname: LnameText.value })
    })
        .then((response) => {
            return response.json();
        })
        .then(data => {
            console.log(data);
            MainList.innerHTML += `<li class="list-group-item">${data.fname} ${data.lname};
            FnameText.value = '';
            LoadingSpinner.innerHTML = "";
        });

    event.preventDefault();
});

console.log(btnGetAllCustomers);
