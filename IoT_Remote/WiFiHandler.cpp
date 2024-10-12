#include "WiFiHandler.h"

void startAccessPoint() {
    WiFi.softAP(apSSID, apPassword);
    Serial.print("Access Point IP: ");
    Serial.println(WiFi.softAPIP());
}

void connectToWiFi(const String& ssid, const String& password) {
    WiFi.softAPdisconnect(true);
    WiFi.begin(ssid.c_str(), password.c_str());
    Serial.print("Kobler til WiFi ..");

    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }
    Serial.println("\nTilkoblet til WiFi!");
    Serial.print("IP: ");
    Serial.println(WiFi.localIP());
}
