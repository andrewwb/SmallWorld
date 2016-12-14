namespace SmallWorld.Services {
    export interface ICommonService {
        $http: ng.IHttpService,
        $state: ng.ui.IStateService,
        $stateParams: ng.ui.IStateParamsService,
        warehouseUrl: string,
        itemUrl: string,
        employeeUrl: string
    }
}