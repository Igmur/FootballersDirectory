function editFootballer(id, url) {
    let rec = new XMLHttpRequest();
    let fullUrl = url + "/" + id;
    rec.open("get", fullUrl, true);
    rec.onload = function() {
        const p = document.getElementById("edit-form");
        p.style.visibility = "visible";
        p.innerHTML = rec.response;
        unlockForm();
    };
    rec.send();
}

function unlockForm() {
    const nameField = document.getElementById("edit-name");
    nameField.removeAttribute("disabled");
    const lastNameField = document.getElementById("edit-lastname");
    lastNameField.removeAttribute("disabled");
    const genderField = document.getElementById("edit-gender");
    genderField.removeAttribute("disabled");
    const birthDateField = document.getElementById("edit-birthdate");
    birthDateField.removeAttribute("disabled");
    const commandField = document.getElementById("edit-command");
    commandField.removeAttribute("disabled");
    const countryField = document.getElementById("edit-country");
    countryField.removeAttribute("disabled");
    const saveButton = document.getElementById("edit-save");
    saveButton.removeAttribute("disabled");
    saveButton.setAttribute("class", "btn btn-outline-success")
    const cancelButton = document.getElementById("edit-clear");
    cancelButton.removeAttribute("disabled");
    cancelButton.setAttribute("class", "btn btn-outline-danger")
}

function clearForm() {
    document.getElementById("edit-form").reset();
}