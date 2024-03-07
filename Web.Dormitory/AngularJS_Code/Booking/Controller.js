app.controller('BookingController', function ($scope, $http, $window, BookingService) {
    $scope.getAllBookings = function () {
        BookingService.getAllBookings()
            .then(function (bookings) {
                $scope.bookings = bookings;
                //console.log($scope.bookings);
            })
            .catch(function (error) {
                console.error('Error fetching bookings:', error);
            });
    };

    $scope.toggleApproveButton = function (BookingID) {
        BookingService.toggleApproval(BookingID)
            .then(function () {
                $scope.getAllBookings();
                showToast("success", "Success!", 'Approve student booking successfully!');
            })
            .catch(function (error) {
                console.error('Error setting approval:', error);
            });
    };

    $scope.toggleDenyButton = function (BookingID) {
        BookingService.toggleDeny(BookingID)
            .then(function () {
                $scope.getAllBookings();
                showToast("success", "Success!", 'Deny student booking successfully!');
            })
            .catch(function (error) {
                console.error('Error setting deny:', error);
            });
    };

    // Call the function to fetch all bookings when the controller is loaded
    $scope.getAllBookings();
});
