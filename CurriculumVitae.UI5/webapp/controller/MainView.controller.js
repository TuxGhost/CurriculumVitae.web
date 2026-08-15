sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"
], function(Controller,JSONModel) {
    "use strict";

    return Controller.extend("my.ui5.app.controller.MainView", {
        onInit: function() {
            // code die uitgevoerd wordt bij het laden van de view
            console.log("Controller geladen");
            var oModel = new JSONModel();            
            console.log(oModel);
            oModel.loadData("http://localhost:5208/CurriculumVitae/current")
            this.getView().setModel(oModel);
        },

        onPressButton: function(oEvent) {
            // code voor knopklik
            alert("Knop is ingedrukt!");
        }
    });
});
