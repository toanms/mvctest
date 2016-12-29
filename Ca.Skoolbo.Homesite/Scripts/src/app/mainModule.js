System.register(["@angular/core", "@angular/platform-browser", "@angular/forms", "@angular/http", "./siteRouteModule", "./mainComponent", "./home/homeComponent", "./about/aboutComponent", "./pricing/pricingComponent"], function (exports_1, context_1) {
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
    var core_1, platform_browser_1, forms_1, http_1, siteRouteModule_1, mainComponent_1, homeComponent_1, aboutComponent_1, pricingComponent_1, MainModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (siteRouteModule_1_1) {
                siteRouteModule_1 = siteRouteModule_1_1;
            },
            function (mainComponent_1_1) {
                mainComponent_1 = mainComponent_1_1;
            },
            function (homeComponent_1_1) {
                homeComponent_1 = homeComponent_1_1;
            },
            function (aboutComponent_1_1) {
                aboutComponent_1 = aboutComponent_1_1;
            },
            function (pricingComponent_1_1) {
                pricingComponent_1 = pricingComponent_1_1;
            }
        ],
        execute: function () {
            MainModule = (function () {
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
                }),
                __metadata("design:paramtypes", [])
            ], MainModule);
            exports_1("MainModule", MainModule);
        }
    };
});
//# sourceMappingURL=mainModule.js.map