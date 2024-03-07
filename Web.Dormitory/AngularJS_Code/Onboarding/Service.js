// Create a service for handling API requests
app.service('OnboardingService', function ($http) {
    this.BindUsernameWithID = function (studentID) {
        var response = $http({
            method: 'post',
            url: "/api/onboarding/BindUsernameWithID",
            params: {
                studentID: studentID,
            }
        });
        return response;
    }
});
