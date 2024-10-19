const fs = require('fs');
const path = '-/devices.json';

function getDevices(callback) {
    fs.readFile(path, 'utf8', (err, data) => {
        if (err) return callback(err);
        const devices = JSON.parse(data);
        callback(null, devices);
    });
};

function addDevice(newDevice, callback) {
    getDevices((err, data) => {
        if (err) return callback(err);

        devices.push(newDevice);
        fs.writeFile(path, JSON.stringify(devices, null, 2), callback);
    });
};

function deleteDevice(deviceName, callback) {
    getDevices((err, devices) => {
        if (err) return callback(err);

        const filteredDevices = devices.filter(device => device.name !== deviceName);
        fs.writeFile(path, JSON.stringify(filteredDevices, null, 2), callback);
    });
};

module.exports = {
    getDevices,
    addDevice,
    deleteDevice
};