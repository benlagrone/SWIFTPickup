var app = angular.module("myApp", ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "pickupHomeController",
       templateUrl: "/templates/driver/PickupHome.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.factory("dataService", function ($http, $q) {
    var _pickups = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }

    var _getPickups = function () {
        var deferred = $q.defer();

        $http.get("/api/v1/pickups/0")
        .then(function (result) {
            angular.copy(result.data, _pickups);
            _isInit = true;

            deferred.resolve()
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };

    var _addPickup = function (newPickup) {
        var deferred = $q.defer();

        $http.post("/api/v1/pickups, newPickup")
        .then(function (result) {
            var newlyCreatedPickup = result.data;
            _pickups.splice(0, 0, newlyCreatedPickup);
            console.log(newlyCreatedPickup);
            deferred.resolve(newlyCreatedPickup);
        }, function () {
            deferred.reject();
        });

    };


    function _findPickup(id) {
        var found = null;
        $.each(_pickups, function (i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }
        })
        return found;
    };

    return {
        addPickup: _addPickup,
        getPickups: _getPickups
    };
});

app.controller("pickupHomeController", function ($scope, $http, $interval) {

   
});