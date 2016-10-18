function dashboardPage() {

	var api = apiService;

	var _loading = false;
	var _loaded = false;

	var _data = {
		
	};



	function Page() {
		var self = this;
	};

	//#region private functions

	function onLoadSuccess(data) {
		_data.Campaign = data;
		_loading = false;
		_loaded = true;
	};

	function onLoadFailure(data) {
		console.log('failed: ', data);
		_loading = false;
	};

	//#endregion


	//#region public function

	Page.prototype = {
		get Loading() { return _loading; },
		get Loaded() { return _loaded; },
		Load: load
	};


	function load() {
		_loading = true;
		return api.DashboardMetrics().then(
			function (response) { onLoadSuccess(response.data); },
			function (response) { onLoadFailure(response.data); }
		);
	};


	//#endregion

	return Page;
};

campaignPage.$inject = [];
