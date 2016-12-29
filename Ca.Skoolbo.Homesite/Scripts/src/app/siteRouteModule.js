"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var aboutComponent_1 = require("./about/aboutComponent");
var pricingComponent_1 = require("./pricing/pricingComponent");
var homeComponent_1 = require("./home/homeComponent");
var SiteRouteModule = (function () {
    function SiteRouteModule() {
    }
    return SiteRouteModule;
}());
SiteRouteModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forRoot([
                { path: '', component: homeComponent_1.HomeComponent, useAsDefault: true },
                { path: 'about', component: aboutComponent_1.AboutComponent },
                { path: 'pricing', component: pricingComponent_1.PricingComponent }
            ])
        ],
        exports: [router_1.RouterModule]
    }),
    __metadata("design:paramtypes", [])
], SiteRouteModule);
exports.SiteRouteModule = SiteRouteModule;
//# sourceMappingURL=siteRouteModule.js.map