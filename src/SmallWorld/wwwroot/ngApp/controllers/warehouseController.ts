namespace SmallWorld.Controllers {
    export class WarehouseController {
        public checkoutMenu;
        public checkInMenu;
        public checking;
        public checkoutStatus;
        public checkInStatus;
        public warehouses;
        public employees;
        public items;
        public warehouse;

        constructor(public CommonServices: SmallWorld.Services.ICommonService) {
            this.checkoutMenu = false;
            this.checkInMenu = false;
            this.checking = false;
            this.checkoutStatus = "";
            this.checkInStatus = "";

            if (!CommonServices.$stateParams['id']) {
                CommonServices.$http.get('api/warehouse').then((res) => {
                    this.warehouses = res.data;
                }).catch((err) => {
                    console.log(err);
                });
            }
            else {
                CommonServices.$http.get(`${CommonServices.warehouseUrl}/${CommonServices.$stateParams['id']}`).then((res) => {
                    this.warehouse = res.data;
                    console.log(this.warehouse);
                })

                CommonServices.$http.get(CommonServices.employeeUrl).then((res) => {
                    this.employees = res.data;
                })

                CommonServices.$http.get(`${CommonServices.itemUrl}/${CommonServices.$stateParams['id']}`).then((res) => {
                    this.items = res.data;
                })
            }
        }

        public postNewWarehouse(warehouse) {
            this.CommonServices.$http.post(this.CommonServices.warehouseUrl, warehouse).then((res) => {
                console.log(res);
                this.CommonServices.$state.reload();
            });
        }

        public postNewItem(item) {
            this.CommonServices.$http.post(`${this.CommonServices.itemUrl}/${this.CommonServices.$stateParams['id']}`, item).then((res) => {
                console.log(res);
                this.CommonServices.$state.reload();
            });
        }

        public checkoutItem(item) {
            this.CommonServices.$http.post(`${this.CommonServices.warehouseUrl}/checkout`, item).then((res) => {
                this.checkoutStatus = "Item checkout complete.";
                this.CommonServices.$http.get(`${this.CommonServices.warehouseUrl}/${this.CommonServices.$stateParams['id'] }`).then((res) => {
                    this.items = res.data;
                });
            }).catch((err) => {
                this.checkoutStatus = "Item checkout failed... Try again.";
            });
        }

        public checkInItem(item) {
            this.CommonServices.$http.post(`${this.CommonServices.warehouseUrl}/checkin`, item).then((res) => {
                this.checkInStatus = "Item check in complete.";
                this.CommonServices.$http.get(`${this.CommonServices.warehouseUrl}/${this.CommonServices.$stateParams['id'] }`).then((res) => {
                    this.items = res.data;
                });
            }).catch((err) => {
                this.checkInStatus = "Item check in failed... Try again.";
            });
        }
    }
}