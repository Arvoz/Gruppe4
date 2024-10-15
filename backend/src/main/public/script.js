
let groups = [];

// Fiktive smarthjemenheter som dukker opp når du søker
const devices = [
    "Philips Hue Lyspære",
    "Sonos Høyttaler",
    "Google Nest Termostat",
    "Yale Smart Lock",
    "Arlo Outdoor Cam",
    "Samsung SmartThings Klokke"
];

// Hente grupper fra localStorage når siden lastes
document.addEventListener("DOMContentLoaded", function() {
    const storedGroups = localStorage.getItem("groups");
    if (storedGroups) {
        groups = JSON.parse(storedGroups);
        updateGroupList();
    }
});

// Funksjon for å legge til en gruppe
function addGroup() {
    const getGroupName = document.getElementById("groupName").value;
    const getDevice = document.getElementById("deviceSelect").value;
    let group = groups.find(g => g.groupName === getGroupName);

    if (!group) {
        groups.push({
            groupName: getGroupName,
            devices: [getDevice] 
        });
    } else {
        group.devices.push(getDevice); 
    }

    // Lagre gruppene til localStorage
    localStorage.setItem("groups", JSON.stringify(groups));

    updateGroupList();
}

// Oppdatere listen med grupper
function updateGroupList() {
    const groupList = document.getElementById('groupList');
    groupList.innerHTML = ''; 
  
    groups.forEach(group => {
        const groupItem = document.createElement('li');
        groupItem.textContent = group.groupName;
  
        const deviceList = document.createElement('ul');
        group.devices.forEach(device => { 
            const deviceItem = document.createElement('li');
            deviceItem.textContent = device; 
            deviceList.appendChild(deviceItem);
        });
  
        groupItem.appendChild(deviceList);
        groupList.appendChild(groupItem);
    });
}

// Funksjon for å nullstille grupper
function resetGroups() {
    groups = []; // Tømmer arrayet med grupper
    localStorage.removeItem("groups"); // Fjerner grupper fra localStorage
    updateGroupList(); // Oppdaterer visningen slik at gruppene fjernes fra grensesnittet
    console.log("Alle grupper er nullstilt");
}

// Vis tilgjengelige enheter på Innstillinger-siden
document.getElementById("searchDevicesButton")?.addEventListener("click", function() {
    const devicesList = document.getElementById("devicesList");
    const ul = document.getElementById("searchButton");

    ul.innerHTML = ""; // Tøm listen før nye enheter legges til

    devices.forEach(device => {
        const li = document.createElement("li");
        li.innerHTML = `${device} <button class="btn-primary">Pare med ESP32</button>`;
        ul.appendChild(li);
    });

    devicesList.style.display = "block"; // Viser listen med enheter
});

// Log for debugging
console.log("Script loaded successfully");
