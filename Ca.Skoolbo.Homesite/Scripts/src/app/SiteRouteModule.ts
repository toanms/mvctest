import { NgModule } from "@angular/core"
import { BrowserModule } from "@angular/platform-browser"
import { RouterModule } from "@angular/router"

import { AboutComponent } from "./about/aboutComponent"
import { PricingComponent } from "./pricing/pricingComponent"
import { HomeComponent } from "./home/homeComponent"

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: '', component: HomeComponent, useAsDefault: true },
            { path: 'about', component: AboutComponent },
            { path: 'pricing', component: PricingComponent }
        ])
    ],
    exports: [RouterModule]
})
export class SiteRouteModule {
    
}
