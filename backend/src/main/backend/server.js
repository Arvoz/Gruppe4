const express = require('express');
const path = require('path');
const deviceController = require("./deviceController");

const app = express();
const PORT = process.env.PORT || 3000;

let groups = [];

// Angi mappen for statiske filer (som HTML, CSS og JavaScript)
app.use(express.static(path.join(__dirname, '../public')));
app.use(express.json());

// Lag en rute for rotsiden som sender index.html
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, '../public', 'index.html'));
});

// Bekrefter at gruppe er lagt til
app.post('/api/groups', (req, res) => {
    const group = req.body;
    groups.push(group);
    res.status(201).json({ message: 'Gruppe lagt til', group: group })
});

// Hente grupper
app.get('/api/groups', (req, res) => {
    res.status(200).json(groups);
});

app.post('/api/esp32', (req, res) => {
    const espData = req.body; // Mottatt data fra ESP32
    console.log('Mottatt data fra ESP32:', espData);

    // Send en respons tilbake til ESP32
    res.status(200).send({ message: 'Data mottatt av serveren' });
});

app.get('/api/esp32', (req, res) => {
    // Eksempel på data du vil sende tilbake til ESP32
    const responseData = {
        status: 'Tilkoblet',
        instructions: 'Send flere data',
    };
    res.status(200).json(responseData);
});

app.get('/api/devices', (req, res) => {
    deviceController.getDevices((err, devices) => {
        if (err) return res.status(500).send('Error reading devices');
        res.json(devices);
    });
});

// POST-endepunkt for å legge til en ny enhet
app.post('/api/devices', (req, res) => {
    const newDevice = req.body;
    deviceController.addDevice(newDevice, (err) => {
        if (err) return res.status(500).send('Error saving device');
        res.status(201).send('Device added');
    });
});

// DELETE-endepunkt for å slette en enhet
app.delete('/api/devices/:deviceName', (req, res) => {
    const deviceName = req.params.deviceName;
    deviceController.deleteDevice(deviceName, (err) => {
        if (err) return res.status(500).send('Error deleting device');
        res.send('Device deleted');
    });
});

// Start serveren
app.listen(PORT, () => {
    console.log(`Serveren kjører på http://localhost:${PORT}`);
});
