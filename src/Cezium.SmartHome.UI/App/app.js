'use strict';

(function () {
	angular
		.module('app', ['ui.router'])

		.service('apiService', apiService)
		.factory('dashboardPage', dashboardPage)

		.controller('dashboardCtrl', dashboardCtrl)

		
		.run(['$rootScope', '$state', '$stateParams', function ($rootScope, $state, $stateParams) {
    		$rootScope.$state = $state;
    		$rootScope.$stateParams = $stateParams;
		}])
		

		.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

			$urlRouterProvider.otherwise('/');


    		$stateProvider
				.state("dashboard", {
					url: "/",
					templateUrl: '/app/modules/dashboard/templates/index.html',
				})
				.state("control", {
					url: "/control",
					template: 'Управление',
				})
				.state("security", {
					url: "/security",
					template: 'Безопасность',
				})
				.state("reports", {
					url: "/reports",
					template: 'отчеты',
				})
				.state("users", {
					url: "/users",
					template: 'пользователи',
				})
				.state("scenarios", {
					url: "/scenarios",
					template: 'сценарии',
				})
				.state("actions", {
					url: "/actions",
					template: 'события',
				})
			;
		}])
	;
})();