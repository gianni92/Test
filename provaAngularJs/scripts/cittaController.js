angular.module("myApp")
	.controller("cittaController", ["elencoCittaService", function ($scope, elencoCittaService) {
	    $scope.aggiungiCitta = function () {
	        elencoCittaService.aggiungi({ nome: $scope.nome, regione: $scope.regione });
	    };
	    $scope.next = function () {
	        elencoCittaService.elenco;
	    }
	}]);