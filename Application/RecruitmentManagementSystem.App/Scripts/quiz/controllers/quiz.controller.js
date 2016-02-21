﻿(function(app) {
    "use strict";

    app.controller("QuizController", [
        "$http", "$uibModal", function($http, $uibModal) {

            var vm = this;

            vm.pages = [];

            vm.create = function() {
                vm.form.submitted = true;

                var model = {
                    title: vm.title,
                    courseId: vm.courseId,
                    quizPages: angular.copy(vm.pages),
                    __RequestVerificationToken: angular.element(":input:hidden[name*='RequestVerificationToken']").val()
                };

                if (vm.form.$valid) {
                    angular.forEach(model.quizPages, function(p) {
                        p.questions = _.map(p.questions, function(x) {
                            return {
                                questionId: x.id,
                                point: x.point
                            };
                        });
                    });
                    console.log(model);

                    $http.post("/quiz/create", model);
                }
            };

            vm.addNewPage = function() {
                vm.pages.push({
                    questions: []
                });
            };

            vm.findCourses = function() {
                $http.get("/Course/List/").success(function(data) {
                    vm.courses = data;
                });
            };

            vm.openQuestionModal = function(pageIndex) {
                var questionsInAllPages = [];

                vm.pages.forEach(function(p) {
                    questionsInAllPages.push.apply(questionsInAllPages, p.questions);
                });

                var modalInstance = $uibModal.open({
                    animation: true,
                    backdrop: "static",
                    templateUrl: "/Scripts/quiz/templates/question-modal.html",
                    controller: "QuestionModalController",
                    controllerAs: "modalCtrl",
                    resolve: {
                        questionsInAllPages: function() { return questionsInAllPages; }
                    }
                });

                modalInstance.result.then(function(questions) {
                    var questionsInAllButThisPage = [];
                    for (var i = 0; i < vm.pages.length; i++) {
                        if (i === pageIndex) {
                            continue;
                        }
                        questionsInAllButThisPage.push.apply(questionsInAllButThisPage, vm.pages[i].questions);
                    }

                    vm.pages[pageIndex].questions = _.filter(questions, function(q) {
                        return !_.find(questionsInAllButThisPage, { id: q.id });
                    });
                });
            };

            vm.discardQuestion = function(page, index) {
                page.questions.splice(index, 1);
            };
        }
    ]);
})(angular.module("quiz"));