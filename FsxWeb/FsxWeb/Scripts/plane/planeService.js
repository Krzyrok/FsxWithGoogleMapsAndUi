(function (angular) {
    'use strict';

    angular
        .module('fsxWebApp')
        .service('planeService', planeService);

    planeService.$inject = ['$http'];

    function planeService($http) {
        var service = this;
        var planeApiUrl = '/api/Plane/';
    }

})(window.angular)