'use strict';

(function () {
	angular
		.module('app', [])

		.service('apiService', apiService)
		.factory('dashboardPage', dashboardPage)

		.controller('dashboardCtrl', dashboardCtrl)
	;
})();