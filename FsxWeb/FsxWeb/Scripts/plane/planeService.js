(function (angular) {
    'use strict';

    angular
        .module('fsxWebApp')
        .service('planeService', planeService);

    planeService.$inject = ['$http'];

    function planeService($http) {
        var service = this;
        var planeApiUrl = '/api/Plane/';

        service.getPlaneData = getPlaneData;

        function getPlaneData() {
            return $http.get(planeApiUrl);
        }
    }

})(window.angular)