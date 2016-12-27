import { NgModule } from "@angular/core"
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from "./appComponent"
import { SiteRouteModule } from "./siteRouteModule"


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        ReactiveFormsModule,
        SiteRouteModule
    ],
    providers: [
    ],
    exports: [],
    declarations: [
    ],
    bootstrap: [AppComponent]
})
export class MainModule {
    
}