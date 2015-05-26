var app = angular.module("myApp", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/templates/topicsView.html"
    });

    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: "/templates/newTopicView.html"
    });

    $routeProvider.when("/message/:id", {
        controller: "singleTopicController",
        templateUrl: "/templates/singleTopicView.html"
    });

    $routeProvider.otherwise({redirectTo:"/"});
});

app.factory("dataService", function ($http, $q) {


    var _topics = [];
    var _isInit = false;

    var _isReady = function(){
        return _isInit   
    };

    var _getTopics = function () {

        var defferred = $q.defer();

        $http.get("/api/v1/topics?includeReplies=true")
            .then(function (result) {
            //Success
                angular.copy(result.data, _topics);
            _isInit = true;
            defferred.resolve();
        },
   function () {
       //Error
       defferred.reject();
   });
        return defferred.promise;
    };

    var _addTopic = function(newTopic){
        var deferred = $q.defer();

        $http.post("/api/v1/topics", newTopic)
            .then(function (result) {
            //success
            var newlyCreatedTopic = result.data;
            _topics.splice(0,0,newlyCreatedTopic);
                //TODO merge with existing list of topics
            console.log(newlyCreatedTopic)
            deferred.resolve(newlyCreatedTopic);
            
        }, function () {
            //error
            deferred.reject()
        });

        return deferred.promise;
    };



    var _getTopicById = function (id) {
        var deferred = $q.defer();

        if(_isReady()){
            var topic = _findTopic(id);
            if(topic){
                deferred.resolve(topic);
            } else {
                deferred.reject();
            }
        } else {
            _getTopics()
            .then(function(){
                //success
                var topic = _findTopic(id);
                if (topic){
                    deferred.resolve(topic)
                } else {
                    deferred.reject();
                }
            },
            function(){
                //error
                deferred.reject();
            })
        }

        return deferred.promise;
    };

    
    function _findTopic(id) {
        var found = null;

        $.each(_topics, function (i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }
        })

        return found;
    }

    var _saveReply = function (topic, newReply) {
        var deferred = $q.defer();

        $http.post("/api/v1/topics/" + topic.id + "/replies", newReply)
        .then(function (result) {
            //success
            if (topic.replies == null) topic.replies = [];
            topic.replies.push(result.data);
            deferred.resolve(result.data)
        }, function () {
            //error
            deffered.reject
        });

        return deferred.promise;
    };

    return {
        topics: _topics,
        getTopics: _getTopics,
        addTopic: _addTopic,
        isReady: _isReady,
        getTopicById: _getTopicById,
        saveReply: _saveReply
    };
});

app.controller("topicsController", function ($scope, dataService) {
    
    $scope.data = dataService;
    $scope.isBusy = true;

    if (dataService.isReady() == false) {
        dataService.getTopics().then(function () {
            //success
        }, function () {
            //error
        }).then(function () {
            $scope.isBusy = false;
        })
    }
});

app.controller("newTopicController", function ($scope, $window, dataService) {
    $scope.newTopic = {};

    $scope.save = function () {
        console.log(dataService)
        dataService.addTopic($scope.newTopic)
            .then(
            function () {
                //success
                $window.location = "#/";
            }, function () {
                //error
                alert("could not save new topic");
            }
            );
        //.success();
    };
});

app.controller("singleTopicController", function ($scope, dataService, $window, $routeParams) {
    $scope.topic = null;
    $scope.newReply = {};

    dataService.getTopicById($routeParams.id).then(function (topic) {
        //success
        $scope.topic = topic;
    }, function () {
        //error
        $window.location = "#/";
    });

    $scope.addReply = function () {
        dataService.saveReply($scope.topic.$scope.newReply)
        .then(function () {
            //success
            $scope.newReply.body = "";
        }, function () {
            //error
            alert("could not save the new reply");
        })
    };
})