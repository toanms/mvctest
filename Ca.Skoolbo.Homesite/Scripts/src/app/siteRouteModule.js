System.register(["@angular/core", "@angular/router", "./about/aboutComponent", "./pricing/pricingComponent", "./home/homeComponent"], function (exports_1, context_1) {
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
    var __moduleName = context_1 && context_1.id;
    var core_1, router_1, aboutComponent_1, pricingComponent_1, homeComponent_1, SiteRouteModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (aboutComponent_1_1) {
                aboutComponent_1 = aboutComponent_1_1;
            },
            function (pricingComponent_1_1) {
                pricingComponent_1 = pricingComponent_1_1;
            },
            function (homeComponent_1_1) {
                homeComponent_1 = homeComponent_1_1;
            }
        ],
        execute: function () {
            SiteRouteModule = (function () {
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
            exports_1("SiteRouteModule", SiteRouteModule);
        }
    };
});
//# sourceMappingURL=siteRouteModule.js.map