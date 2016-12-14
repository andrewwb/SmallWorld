namespace SmallWorld.Controllers {

    export class HomeController {
        public warehouses;
        public employees;
        public items;

        constructor(public CommonServices: SmallWorld.Services.ICommonService) {
            CommonServices.$http.get(CommonServices.warehouseUrl).then((res) => {
                this.warehouses = res.data;
                console.log(res);
            });
            CommonServices.$http.get(CommonServices.employeeUrl).then((res) => {
                this.employees = res.data;
                console.log(res);
            });
            CommonServices.$http.get(CommonServices.itemUrl).then((res) => {
                this.items = res.data;
                console.log(res);
            });
        }
    }
}
