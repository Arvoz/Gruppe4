const availableDevices = [
    "Lyspære1", "Lyspære2", "Lyspære3"
];

//const pairedDevices = JSON.parse(localStorage.getItem('pairedDevices')) || [];
const pairedDevices = [];

function displayDevices(device) {
    const list = document.getElementById("availableDevices");
    list.innerHTML = '';
    device.forEach(device => {
        const li = document.createElement("li");
        li.textContent = device;
        const pairButton = document.createElement("button");
        pairButton.textContent = "Par";
        pairButton.onclick = () => pairDevice(device);
        li.appendChild(pairButton);
        list.appendChild(li);
    });
};

function pairDevice (device) {
    if (!pairedDevices.includes(device)) {
        pairedDevices.push(device);
        localStorage.setItem('pairedDevices', JSON.stringify(pairedDevices));
        displayPairedDevices();
    }
};

function displayPairedDevices() {
    const list = document.getElementById("pairedDevices");
    list.innerHTML = '';
    pairedDevices.forEach(device => {
        const li = document.createElement("li");
        li.textContent = device;
        const removeButton = document.createElement("button");
        removeButton.textContent = "Fjern";
        removeButton.onclick = () => removeDevice(device);
        li.appendChild(removeButton);
        list.appendChild(li);
    });
}

function removeDevice(device) {
    const index = pairedDevices.indexOf(device);
    if (index > -1) {
        pairedDevices.splice(index, 1);
    }
    displayPairedDevices();
}

displayDevices(availableDevices);
displayPairedDevices();