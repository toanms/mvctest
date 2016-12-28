import { NgModule, AfterViewInit } from "@angular/core"
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';


import { SiteRouteModule } from "./siteRouteModule"

import { MainComponent } from "./mainComponent"
import { HomeComponent } from "./home/homeComponent"
import { AboutComponent } from "./about/aboutComponent"
import { PricingComponent } from "./pricing/pricingComponent"

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
        MainComponent,
        HomeComponent,
        AboutComponent,
        PricingComponent
    ],
    bootstrap: [MainComponent]
})
export class MainModule {
    
}