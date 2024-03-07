// Update the controller to use the service
app.controller('OnboardingController', function ($scope, $window, OnboardingService) {
    $scope.submitForm = function () {
        // Use the service to make the HTTP POST request
        OnboardingService.BindUsernameWithID($scope.studentID)
            .then(respond => {
                showToast("success", "Sucess!", respond.data)
                waitForToastAfterGoToDashboard($window)
            })
            .catch(respond => {
                showToast("error", "Error!", respond.data.Message)
            })
    };
});