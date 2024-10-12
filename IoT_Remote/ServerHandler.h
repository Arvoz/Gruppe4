#ifndef SERVER_HANDLER_H
#define SERVER_HANDLER_H

#include <ESPAsyncWebServer.h>

// Deklarasjon av server-objekt
extern AsyncWebServer server;

void startServer();
void handleConfigRequest(AsyncWebServerRequest *request, uint8_t *data, size_t len);

#endif
