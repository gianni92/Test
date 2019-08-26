angular.module("myApp")
	.controller("elencoController", ["elencoCittaService", function ($scope, elencoCittaService) {
	    $scope.elencoCitta = elencoCittaService.elenco;
	}]);