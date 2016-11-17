function openhabApiService($http) {
	var self = this;
	var url = 'http://localhost:8080/rest';

	return {
		item: Item
	};


	function Item(name) {
		var request = {
			method: 'get',
			url: url + '/items/' + name + '/state',
			//headers: { 'Content-Type': 'application/json' }
		};

		return $http(request);
	};
};

openhabApiService.$inject = ['$http'];