import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection, provideZonelessChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  // providers: [
  //   provideBrowserGlobalErrorListeners(),
  //   provideRouter(routes), provideClientHydration(withEventReplay()),
  //   provideZoneChangeDetection({ eventCoalescing: true }),
  //   provideHttpClient()
  // ]
    providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),
    provideHttpClient()
  ]
};
