const express = require('express');
const path = require('path');

const app = express();
const PORT = process.env.PORT || 3000;

// Angi mappen for statiske filer (som HTML, CSS og JavaScript)
app.use(express.static(path.join(__dirname, '../public')));

// Lag en rute for rotsiden som sender index.html
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, '../public', 'index.html'));
});

// Start serveren
app.listen(PORT, () => {
    console.log(`Serveren kjører på http://localhost:${PORT}`);
});
