"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var siteRouteModule_1 = require("./siteRouteModule");
var mainComponent_1 = require("./mainComponent");
var homeComponent_1 = require("./home/homeComponent");
var aboutComponent_1 = require("./about/aboutComponent");
var pricingComponent_1 = require("./pricing/pricingComponent");
var MainModule = (function () {
    function MainModule() {
    }
    return MainModule;
}());
MainModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            http_1.JsonpModule,
            forms_1.ReactiveFormsModule,
            siteRouteModule_1.SiteRouteModule
        ],
        providers: [],
        exports: [],
        declarations: [
            mainComponent_1.MainComponent,
            homeComponent_1.HomeComponent,
            aboutComponent_1.AboutComponent,
            pricingComponent_1.PricingComponent
        ],
        bootstrap: [mainComponent_1.MainComponent]
    })
], MainModule);
exports.MainModule = MainModule;
//# sourceMappingURL=mainModule.js.map