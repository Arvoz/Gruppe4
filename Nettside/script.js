let groups = [];

function addGroup() {
    console.log("Koden kjører")
    let getGroupName = document.getElementById("groupName").value;
    let getDevice = document.getElementById("deviceSelect").value;
    let group = groups.find(g => g.groupName === getGroupName);

    if (!group) {
        groups.push({
            groupName: getGroupName,
            devices: [getDevice] 
        });
        console.log("Ny gruppe lagt til:", getGroupName);
    }   
    else {
        group.devices.push(getDevice); 
        console.log("Enhet lagt til i eksisterende gruppe:", getDevice);
    }
    
    updateGroupList(); 
    console.log("Oppdatert grupper:", groups); 
}

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
