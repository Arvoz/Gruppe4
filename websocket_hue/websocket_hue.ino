#include <Arduino.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <AsyncTCP.h>
#include <ESPAsyncWebServer.h>
#include <Arduino_JSON.h>
#include <WiFiClientSecure.h>
#include <vector>

// TODO:
// Wi-Fi connect process
// Hue autodiscover IP
// Hue autoconnect + catch response function for username


// Wi-fi credentials, stored insecurely FOR NOW:
String ssid = "";
String pwd = "";

// Async webserver + socket for html and variables:
AsyncWebServer server(80);
AsyncWebSocket ws("/ws");

// ESP32 Variables:
const int btnPin = 12;
const int potPin = 25;
bool buttonPressed = false; 
JSONVar input_variables;
int modeSelect = 0;

// Hue variables:
const char* hueBridgeIP = "192.168.1.181";
const char* apiUsername =  "ez-4DhpG03fVStwV0S3Xkf4KskaaMqdPK9ewDW2N";  // hue bridge username
int numberOfLights;
bool lightsOn;
std::vector<int> hueID;

void setup() {
  pinMode(btnPin, INPUT_PULLUP);
  pinMode(potPin, INPUT);
  Serial.begin(115200);
  initWiFi();

  server.addHandler(&ws);
  server.on("/", HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send_P(200, "text/html", index_html);
  });
  server.begin();
  
  getHueID();
}

void loop() {
  ws.cleanupClients();
  int buttonVal = digitalRead(btnPin);
  int potVal = map(analogRead(potPin), 0, 4095, 0, 50);

  if (buttonVal == 0 && !buttonPressed) {
    buttonPressed = true;
  } else if (buttonVal == 1 && buttonPressed) {
    modeSelect = modeSelect + 1;
    lightsDefault();
    buttonPressed = false;
  }

  if (modeSelect == 4) {
    modeSelect = 0;
  }

  // JSON data to send through websocket:
  JSONVar jsonData;
  jsonData["button"] = buttonVal;
  jsonData["mode"] = modeSelect;
  jsonData["pot"] = potVal;
  ws.textAll(JSON.stringify(jsonData));
  delay(100);
}


// Function to connect to wi-fi given the credentials:
void initWiFi() { 
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, pwd);
  Serial.print("Connecting to WiFi ..");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print('.');
    delay(1000);
  }
  Serial.println(WiFi.localIP()); // Printing local IP address ESP is connected to
}

// Get the keys for each Hue Light and store in the list:
void getHueID() {
  WiFiClientSecure client;
  HTTPClient http;

  String url = String("https://") + hueBridgeIP + "/api/" + apiUsername + "/lights";
  client.setInsecure(); 
  http.begin(client, url);
  http.addHeader("Content-Type", "application/json");

  int httpResponseCode = http.GET();
  if (httpResponseCode > 0) {
    String response = http.getString();

    // Parsing JSON to find number of lights and each key ID:
    JSONVar jsonData = JSON.parse(response);

    if (JSON.typeof(jsonData) == "undefined") {
      Serial.println("Parsing JSON failed!");
    }

    numberOfLights = jsonData.keys().length();
    int lightsOnCounter = 0;
    hueID.resize(numberOfLights);

    Serial.print("Light list: ");
    for (int i = 0; i < numberOfLights; i++) {
      String lightID = jsonData.keys()[i];  // Get the key (light ID)
      hueID[i] = lightID.toInt();  // Convert light ID to integer and store in vector
      Serial.println(lightID);

      // Access the light's state
      JSONVar lightState = jsonData[lightID]["state"];
      
      // Increment counter if light is on
      if (lightState.hasOwnProperty("on") && bool(lightState["on"]) == true) {
        lightsOnCounter++; 
      }
    }
    // If majority of the lights are on, set lightsOn to true:
    if ((numberOfLights - lightsOnCounter) > (numberOfLights / 2)){
      lightsOn = true;
    }
    else {
      lightsOn = false;
    }
    http.end();
  } 
  
  else {
    Serial.print("GET ERROR: ");
    Serial.println(httpResponseCode);
  }
}

// Function to set lights to default values:
void lightsDefault() {
  // WiFiClientSecure for HTTPS
  WiFiClientSecure client;
  HTTPClient http;

  // Loop over each light and send a PUT request:
  for (int i = 0; i < numberOfLights; i++) {
    
    // The url to send put request to:
    String url = String("https://") + hueBridgeIP + "/api/" + apiUsername + "/lights/" + String(hueID[i]) + "/state";
    
    // Start HTTP connection with JSON headers:
    http.begin(client, url);
    http.addHeader("Content-Type", "application/json");
    client.setInsecure(); // Might want to change this later, not sure what setInsecure actually means in terms of security, but has to be insecure to work for now.
    
    // If lights are on, turn them off, else turn them on with default values:
    String payload;
    if (lightsOn){
      payload = "{\"on\": false}";
      lightsOn = false;
    }
    else {
      payload = "{\"on\": true, \"bri\": 254, \"ct\": 370}";  // 3 KV pairs, on for on/off state, bri for brightness and ct for color temperature.
      lightsOn = true;
    }

    // Sending PUT request:
    int httpResponseCode = http.PUT(payload);

    // Checking for errors:
    if (httpResponseCode > 0) {
      Serial.print("PUT request sent for light ");
      Serial.print(i);
      Serial.print(", response code: ");
      Serial.println(httpResponseCode);
      String response = http.getString();
      Serial.println(response);
    } else {
      Serial.print("Error on PUT request for light ");
      Serial.print(i);
      Serial.print(": ");
      Serial.println(httpResponseCode);
      }
    }

    // End HTTP connection to free resources:
    http.end();
  }



// HTML for local website:
const char index_html[] PROGMEM = R"rawliteral(
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>IoT Remote Hub</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      margin: 0;
      padding: 20px;
      background-color: #f4f4f9;
    }
    h1 {
      color: #333;
    }
    p {
      color: #555;
    }
    .sensor {
      font-size: 1.5em;
      margin: 10px 0;
    }
  </style>
</head>
<body>
  <h1>IoT Remote</h1>
  <p class="sensor">Button State: <span id="buttonState">0</span></p>
  <p class="sensor">Potentiometer Value: <span id="potValue">0</span></p>
  <p class="sensor">Mode Selection: <span id="modeSelect">0</span></p>
  <script>
    var websocket;
    function initWebSocket() {
      websocket = new WebSocket('ws://' + window.location.hostname + '/ws');
      websocket.onmessage = function(event) {
        var data = JSON.parse(event.data);
        document.getElementById('buttonState').innerText = data.button;
        document.getElementById('potValue').innerText = data.pot;
        document.getElementById('modeSelect').innerText = data.mode
      };
    }
    window.onload = function() {
      initWebSocket();
    };
  </script>
</body>
</html>
)rawliteral";