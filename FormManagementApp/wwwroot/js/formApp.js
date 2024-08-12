var app = angular.module('formApp', []);

app.controller('FormController', function ($scope) {
    $scope.forms = [];

    $scope.newForm = {
        id: null,
        name: '',
        description: '',
        fields: []
    };

    $scope.addField = function () {
        $scope.newForm.fields.push({
            name: '',
            dataType: 'STRING',
            required: false
        });
    };

    $scope.saveForm = function () {
        // Form verisini kaydetme işlemi
        $scope.forms.push(angular.copy($scope.newForm));
        $scope.newForm = {
            id: null,
            name: '',
            description: '',
            formFields: []
        };
    };
});
