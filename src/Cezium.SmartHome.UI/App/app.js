'use strict';

(function () {
	angular
		.module('app', ['ui.router'])

		.service('apiService', apiService)
		.service('openhabApiService', openhabApiService)
		.factory('atmosphereSubscriber', AtmosphereSubscriber)
		.factory('dashboardPage', dashboardPage)

		.component('openhabItemValue', openhabItemValue)
		.component('openhabSimpleSwitch', openhabSimpleSwitch)

		.controller('dashboardCtrl', dashboardCtrl)
		.controller('controlCtrl', controlCtrl)

		
		.run(['$rootScope', '$state', '$stateParams', function ($rootScope, $state, $stateParams) {
    		$rootScope.$state = $state;
    		$rootScope.$stateParams = $stateParams;

    		$rootScope.$on('$stateChangeSuccess', function (evt, toState, toParams, fromState, fromParams) {
    			$rootScope.$state = toState;
    		});
		}])
		

		.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

			$urlRouterProvider.otherwise('/');


    		$stateProvider
				.state("dashboard", {
					url: "/",
					templateUrl: '/app/modules/dashboard/templates/index.html',
					controller: dashboardCtrl,
					data: {
						pageTitle: 'Обзор'
					}
				})
				.state("control", {
					url: "/control",
					templateUrl: '/app/modules/control/templates/index.html',
					controller: controlCtrl,
					data: {
						pageTitle: 'Настройки',
						pageSubTitle: ''
					}
				})
				.state("security", {
					url: "/security",
					template: '',
					data: {
						pageTitle: 'Безопасность',
						pageSubTitle: ''
					}
				})
				.state("reports", {
					url: "/reports",
					template: '',
					data: {
						pageTitle: 'Статистика',
						pageSubTitle: ''
					}
				})
				.state("users", {
					url: "/users",
					template: '',
					data: {
						pageTitle: 'Пользователи',
						pageSubTitle: ''
					}
				})
				.state("scenarios", {
					url: "/scenarios",
					template: '',
					data: {
						pageTitle: 'Сценарии',
						pageSubTitle: ''
					}
				})
				.state("actions", {
					url: "/actions",
					template: '',
					data: {
						pageTitle: 'События',
						pageSubTitle: ''
					}
				})
				.state("hardware", {
					url: "/hardware",
					template: '',
					data: {
						pageTitle: 'Оборудование',
						pageSubTitle: ''
					}
				})
			;
		}])
	;
})();