//angular.module("myApp").factory("myService", function () { });
angular.module("myApp")
	.service("elencoCittaService", function () {
	    this.elenco = [
			{ nome: "Roma", regione: "Lazio" },
			{ nome: "Latina", regione: "Lazio" },
			{ nome: "Milano", regione: "Lombardia" },
			{ nome: "Napoli", regione: "Campania" },
			{ nome: "Como", regione: "Lombardia" },
			{ nome: "Palermo", regione: "Sicilia" },
			{ nome: "Caserta", regione: "Campania" },
			{ nome: "Avellino", regione: "Campania" },
			{ nome: "Trapani", regione: "Sicilia" },
			{ nome: "Agrigento", regione: "Sicilia" }
	    ];
	    this.aggiungi = function (citta) {
	        this.elenco.push(citta);
	    };
	});