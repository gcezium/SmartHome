'use strict';


function openhabItemValueCtrl(atmosphereSubscriber, openhabApiService, $timeout) {
	var self = this;

	this.formatValue = function (value, type) {
		switch (type) {
			case "temperature":
				return '' + parseFloat(value).toFixed(1);
			case "humidity":
				return '' + parseFloat(value).toFixed(0);
		}
	};

	this.callback = function (message) {
		$timeout(function () { self.state = self.formatValue(message, self.type); });
	};

	this.$onInit = function () {
		openhabApiService.item(self.itemName).then(function (response) {
			self.state = self.formatValue(response.data, self.type);
		});
		atmosphereSubscriber.Subscribe({ name: self.itemName }, self.callback);
	};
};

openhabItemValueCtrl.$inject = ['atmosphereSubscriber', 'openhabApiService', '$timeout'];

var openhabItemValue = {
	bindings: {
		itemName: '@',
		type: '@'
	},
	template: '<span data-ng-bind="$ctrl.state"></span>',
	controller: openhabItemValueCtrl
};