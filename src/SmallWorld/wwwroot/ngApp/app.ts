namespace SmallWorld {

    angular.module('SmallWorld', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: SmallWorld.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('warehouses', {
                url: '/warehouses',
                templateUrl: '/ngApp/views/warehouses.html',
                controller: SmallWorld.Controllers.WarehouseController,
                controllerAs: 'controller'
            })
            .state('warehouse', {
                url: '/warehouses/:id',
                templateUrl: '/ngApp/views/warehouse.html',
                controller: SmallWorld.Controllers.WarehouseController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: SmallWorld.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: SmallWorld.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: SmallWorld.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
       
    });

    
    angular.module('SmallWorld').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('SmallWorld').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

}
