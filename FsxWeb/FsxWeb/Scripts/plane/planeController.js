(function (angular) {
    'use strict';

    angular
        .module('fsxWebApp')
        .controller('PlaneController', PlaneController);

    PlaneController.$inject = ['planeService', '$interval'];

    function PlaneController(planeService, $interval) {
        var vm = this;

        vm.map = { zoom: 13 };

        vm.planeData = {
            location:
                {
                    latitude: 0,
                    longitude: 0
                }
        };

        vm.marker = {
            id: 1,
            options: {
                draggable: false
            }
        };

        _acitvate();

        function _acitvate() {
            $interval(_getAndUpdatePlaneDta, 1000);
        }

        function _getAndUpdatePlaneDta() {
            planeService.getPlaneData()
                .success(function (planeData) {
                    vm.planeData = planeData;
                }).error(function(errorData) {
                console.log(errorData);
                });
        }
    }

})(window.angular)