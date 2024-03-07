app.service('BookingService', function ($http) {
    'use strict';

    var baseUrl = 'api/booking/';
    var apiUrlGetAll = baseUrl + 'getAll';
    var apiUrlSetApprove = baseUrl + 'setApproveBookingForm';
    var apiUrlSetDeny = baseUrl + 'setDenyBookingForm';

    this.getAllBookings = function () {
        return $http.get(apiUrlGetAll)
            .then(function (response) {
                return response.data;
            });
    };

    this.toggleApproval = function (BookingID) {
        return $http.post(apiUrlSetApprove + '?BookingID=' + BookingID);
    };

    this.toggleDeny = function (BookingID) {
        return $http.post(apiUrlSetDeny + '?BookingID=' + BookingID);
    };
});
