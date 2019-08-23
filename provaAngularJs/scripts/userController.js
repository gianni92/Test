angular.module("myApp").controller("userController",
            function ($scope) {
                $scope.utente = { name: "", surname: "" };
                $scope.persone = [
	                { nome: "Andrea", cognome: "Rossi", citta: "Roma" },
	                { nome: "Marco", cognome: "Verdi", citta: "Milano" },
	                { nome: "Giovanni", cognome: "Neri", citta: "Napoli" },
	                { nome: "Roberto", cognome: "Gialli", citta: "Palermo" }
                ];
                $scope.elencoCitta = [
	                { codice: "RM", nome: "Roma", regione: "Lazio" },
                    { codice: "LT", nome: "Latina", regione: "Lazio" },
                    { codice: "MI", nome: "Milano", regione: "Lombardia" },
                    { codice: "NA", nome: "Napoli", regione: "Campania" },
                    { codice: "CO", nome: "Como", regione: "Lombardia" },
                    { codice: "PA", nome: "Palermo", regione: "Sicilia" },
                    { codice: "CA", nome: "Caserta", regione: "Campania" },
                    { codice: "AV", nome: "Avellino", regione: "Campania" },
                    { codice: "TP", nome: "Trapani", regione: "Sicilia" },
                    { codice: "AG", nome: "Agrigento", regione: "Sicilia" }
                ];
                $scope.selectedItem = $scope.elencoCitta[0];

                $scope.invia = function (utente) {
                    var promise = $http.post("/elaboraForm", utente);
                    promise.success(function () {
                        alert("Dati correttamente inviati!");
                    })
                    .error(function () {
                        alert("Si è verificato un errore!");
                    });
                };

                $scope.somma = function () {
                    $scope.risultato = $scope.numero1 + $scope.numero2 + $scope.numero3;
                };
            });