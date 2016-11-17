'use strict';


function openhabSimpleSwitchCtrl(atmosphereSubscriber, openhabApiService, $timeout) {
	var self = this;

	this.callback = function (message) {
		$timeout(function () { self.state = message; });
	};

	this.switch = function () {
		this.state = this.state == 'ON' ? 'OFF' : 'ON';
	};

	this.cssClass = function () {
		return {
			'na': this.state != 'ON' && this.state != 'OFF',
			'off': this.state == 'OFF',
			'on': this.state == 'ON'
		}
	};

	this.$onInit = function () {
		console.log('init');
		openhabApiService.item(self.itemName).then(function (response) {
			self.state = response.data;
		});
		atmosphereSubscriber.Subscribe({ name: self.itemName }, self.callback);
	};
};

openhabSimpleSwitchCtrl.$inject = ['atmosphereSubscriber', 'openhabApiService', '$timeout'];

var openhabSimpleSwitch = {
	bindings: {
		itemName: '@'
	},
	template: '<span data-ng-class="$ctrl.cssClass()" data-ng-click="$ctrl.switch()" data-ng-bind="$ctrl.state"></span>',
	controller: openhabSimpleSwitchCtrl
};