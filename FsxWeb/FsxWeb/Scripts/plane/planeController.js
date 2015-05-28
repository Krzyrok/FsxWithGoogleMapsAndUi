(function (angular) {
    'use strict';

    angular
        .module('fsxWebApp')
        .controller('PlaneController', PlaneController);

    PlaneController.$inject = ['planeService', '$interval'];

    function PlaneController(planeService, $interval) {
        var vm = this;

        // map zoom
        vm.map = {};
        vm.map.zoom = { zoom: 13 };

        // marker settings
        vm.marker = {
            id: 1,
            options: {
                draggable: false
            },
            icon: "Content/icons/planeIcon.png"
        };

        _acitvate();

        function _acitvate() {
            $interval(_getAndUpdatePlaneDta, 500);
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