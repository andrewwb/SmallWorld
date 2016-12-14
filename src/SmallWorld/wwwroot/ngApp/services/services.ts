namespace SmallWorld.Services {
    export class CommonService {
        constructor(
            public $http: ng.IHttpService,
            public $state: ng.ui.IStateService,
            public $stateParams: ng.ui.IStateParamsService,
            public warehouseUrl: string, 
            public employeeUrl: string,
            public itemUrl: string
        ) { }
    }

    angular.module('SmallWorld').service('CommonServices', SmallWorld.Services.CommonService);
}