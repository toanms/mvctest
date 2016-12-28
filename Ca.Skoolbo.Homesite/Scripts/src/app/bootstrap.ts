import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { MainModule } from './mainModule'
import { enableProdMode } from '@angular/core';
enableProdMode();

platformBrowserDynamic().bootstrapModule(MainModule);