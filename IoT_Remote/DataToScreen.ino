#include <WiFi.h>
#include <HTTPClient.h>
#include <TFT_eSPI.h>

TFT_eSPI tft = TFT_eSPI();

const char* ssid = "Your_SSID";
const char* password = "Your_PASSWORD";
const char* apiEndpoint = "http://yourwebsite.com/api/device_status";

void setup() {
  tft.init();
  tft.setRotation(1);
  tft.fillScreen(TFT_BLACK);
  tft.setTextColor(TFT_WHITE);
  tft.setTextSize(2);

  // Connect to WiFi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    tft.println("Connecting to WiFi...");
  }

  tft.println("Connected to WiFi!");
}

void loop() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    http.begin(apiEndpoint);
    
    int httpCode = http.GET();
    if (httpCode > 0) {
      String payload = http.getString();
      
      // Clear screen and display the fetched data
      tft.fillScreen(TFT_BLACK);
      tft.setCursor(0, 0);
      tft.println("Device Status:");
      tft.println(payload); // Replace with parsed data
    } else {
      tft.println("Error fetching data");
    }
    http.end();
  } else {
    tft.println("WiFi Disconnected");
  }

  delay(10000); // Update every 10 seconds
}
