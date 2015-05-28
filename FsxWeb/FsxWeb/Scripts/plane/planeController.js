(function (angular) {
    'use strict';

    angular
        .module('fsxWebApp')
        .controller('PlaneController', PlaneController);

    PlaneController.$inject = ['planeService', '$scope'];

    function PlaneController(planeService, $scope) {
        
    }

})(window.angular)