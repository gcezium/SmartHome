'use strict';


function AtmosphereSubscriber() {
	return {
		Subscribe: function (params, callback) {
			var socket = $.atmosphere;

			var url = params.url ? params.url : 'http://localhost:8080';

			var request = {
				url: url + '/rest/items/' + params.name + '/state',
				maxRequest: 256,
				timeout: 600000,
				attachHeadersAsQueryString: true,
				executeCallbackBeforeReconnect: false,
				transport: 'websocket',
				fallbackTransport: 'websocket',
				headers: [{ 'Accept': 'application/json' }, { 'X-Atmosphere-tracking-id': params.name }],
				dropHeaders: false
			};

			request.onError = function (response) {
				console.log('ERROR', response);
			};
			request.onOpen = function (response) {
				//console.log('OPEN', request, response);
			};
			request.onClose = function (response) {
				//console.log('CLOSE', response);
			};
			request.onMessage = function (response) {
				//console.log('MESSAGE', response);
				if (response.status == 200) {
					if (callback) {
						try {
							//console.log('try call callback');
							callback(response.responseBody);
						} catch (ex) { }
					}
				}
			};

			socket.subscribe(request);
		}
	};
};
