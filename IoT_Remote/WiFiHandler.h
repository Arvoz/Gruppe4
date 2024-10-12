#ifndef WIFI_HANDLER_H
#define WIFI_HANDLER_H

#include <WiFi.h>

// AP detaljer
const char* apSSID = "ESP32_AccessPoint";
const char* apPassword = "12345678";

// Variabler for WiFi SSID og passord fra brukeren
String ssid;
String password;

void startAccessPoint();
void connectToWiFi(const String& ssid, const String& password);

#endif