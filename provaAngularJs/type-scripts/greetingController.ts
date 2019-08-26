angular.module("myApp").controller("greetingController",
        function ($scope) {
            $scope.saluta = function () {
                return "Buongiorno " +
                $scope.utente.name + " " + $scope.utente.surname + "!"
            };
        });