#include <SPIFFS.h>
#include <ESPAsyncWebServer.h>
#include <ArduinoJson.h>
#include "WiFiHandler.h"
#include "ServerHandler.h"
#include <AsyncTCP.h>

// Initialiserer webserver på port 80
AsyncWebServer server(80);

void handleConfigRequest(AsyncWebServerRequest *request, uint8_t *data, size_t len) {
    String body = String((char*)data).substring(0, len);

    DynamicJsonDocument doc(256);
    DeserializationError error = deserializeJson(doc, body);

    if (error) {
        request->send(400, "text/plain", "JSON Deserialization Failed");
        return;
    }

    String ssid = doc["ssid"];
    String password = doc["password"];
    
    // Logg for debugging
    Serial.println("Mottok SSID og passord:");
    Serial.println(ssid);
    Serial.println(password);

    request->send(200, "text/plain", "WiFi-konfigurasjon mottatt");
    connectToWiFi(ssid, password);  // Funksjon fra WiFiHandler for å koble til WiFi
}

void startServer() {
    server.on("/", HTTP_GET, [](AsyncWebServerRequest *request) {
        request->send(SPIFFS, "/index.html", "text/html");
    });

    server.on("/configWiFi", HTTP_POST, [](AsyncWebServerRequest *request) {},
        NULL, handleConfigRequest); // Bruk onBody til å håndtere POST-data

    server.serveStatic("/styles.css", SPIFFS, "/styles.css");
    server.serveStatic("/script.js", SPIFFS, "/script.js");

    server.begin();
    Serial.println("Server startet på ESP32.");
}
