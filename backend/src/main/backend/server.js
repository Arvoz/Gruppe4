const express = require('express');
const path = require('path');

const app = express();
const PORT = process.env.PORT || 3000;

let groups = [];
let esp32 = [];

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

// Start serveren
app.listen(PORT, () => {
    console.log(`Serveren kjører på http://localhost:${PORT}`);
});
