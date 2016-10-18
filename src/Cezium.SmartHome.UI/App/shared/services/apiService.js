function apiService($http) {
	var self = this;

	return {
		DashboardMetrics: dashboardMetrics,
		Users: users
	};


	function users(page, order) {
		var request = {
			method: 'get',
			url: '/api/users/paged/' + page + '/' + order,
			headers: { 'Content-Type': 'application/json' }
		};

		return $http(request);
	};

	function dashboardMetrics(page, order) {
		var request = {
			method: 'get',
			url: '/api/metrics/dashboard' + page + '/' + order,
			headers: { 'Content-Type': 'application/json' }
		};

		return $http(request);
	};
};

apiService.$inject = ['$http'];