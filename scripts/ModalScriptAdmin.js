//Modal Popup for editing Admin Details
// Get the modal
var modalAdmin = document.getElementById('myAdminModal');

// Get the button that opens the modal
var editAdmin = document.getElementById("editAdminDetails");

// Get the <span> element that closes the modal
var spanAdmin = document.getElementsByClassName("closeAdminPopup")[0];

// When the user clicks the button, open the modal 
editAdmin.onclick = function () {
    modalAdmin.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
spanAdmin.onclick = function () {
    modalAdmin.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modalAdmin) {
        modalAdmin.style.display = "none";
    }
}