function dashboardCtrl(dashboardPage, $scope) {
	var self = this;
	this.page = new dashboardPage();
	/*
	$scope.$watch('vm.page.Campaign.Id', function (newVal) {
		if (newVal != 0) {
			self.page.Load(newVal);
		}
	});
	*/
};

dashboardCtrl.$inject = ['campaignPage', '$scope'];