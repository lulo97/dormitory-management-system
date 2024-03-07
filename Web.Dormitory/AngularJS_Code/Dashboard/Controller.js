app.controller('DashboardController', function ($scope, $http) {
    $http.get('/api/dashboard/getTotalFour')
        .then(function (response) {
            $scope.totals = [
                { label: 'Students', value: response.data.TotalStudents, iconClass: 'ion-bag' },
                { label: 'Managers', value: response.data.TotalManagers, iconClass: 'ion-stats-bars' },
                { label: 'Rooms', value: response.data.TotalRooms, iconClass: 'ion-person-add' },
                { label: 'Buildings', value: response.data.TotalBuildings, iconClass: 'ion-pie-graph' }
            ];
        })
        .catch(function (error) {
            console.error('Error fetching data:', error);
        });
});
