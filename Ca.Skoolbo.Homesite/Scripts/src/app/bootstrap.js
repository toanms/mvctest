System.register(["@angular/platform-browser-dynamic", "./mainModule", "@angular/core"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var platform_browser_dynamic_1, mainModule_1, core_1;
    return {
        setters: [
            function (platform_browser_dynamic_1_1) {
                platform_browser_dynamic_1 = platform_browser_dynamic_1_1;
            },
            function (mainModule_1_1) {
                mainModule_1 = mainModule_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            }
        ],
        execute: function () {
            core_1.enableProdMode();
            platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(mainModule_1.MainModule);
        }
    };
});
//# sourceMappingURL=bootstrap.js.map