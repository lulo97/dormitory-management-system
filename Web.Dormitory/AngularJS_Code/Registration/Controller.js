app.controller('RegistrationController', function ($scope, $http, $q,
    PanigationService,
    MutipleSelectService,
    BookingService
) {
    const Pani = PanigationService;
    const MuSe = MutipleSelectService;
    const Bo = BookingService;
    
    $scope.currentPage = 1;
    $scope.itemsPerPage = 5;
    $scope.roomToShow = []; //array, pagination

    $scope.rooms = []; //array
    $scope.totalItems = 0; //int, size(room)

    $scope.buildings = []; //array, mutiple select
    $scope.selectedBuilding = []; //array, mutiple select
    $scope.selectedRoom = []; //array, mutiple select

    $scope.showAlreadyInRoomWarning = null; //bool
    $scope.studentInRoomData = null; //object

    // API URL
    var apiUrlGetAllRoomOfABuilding = 'api/room/getAllRoomOfABuilding';
    var apiGetAllBulding = 'api/building/getAll';
    var apiUrlIsBooked = 'api/booking/isBooked';
    var apiUrlSentBookingForm = 'api/booking/sentBookingForm';
    var apiUrlGetStudentInRoom = 'api/studentinroom/getOne';

    // Fetch building from the API
    Pani.fetchBuildings($scope, apiGetAllBulding);

    // Fetch room from the API
    const buildingIDs = [1];
    Pani.fetchDataForBuildingIDs(buildingIDs, $scope, apiUrlGetAllRoomOfABuilding);

    //Mutiple selected
    $scope.getSelectedOptionsText = function () {
        return MuSe.getSelectedOptionsText($scope);
    };

    $scope.toggleSelectAll = function () {
        return MuSe.toggleSelectAll($scope);
    };

    $scope.toggleSelection = function (option) {
        return MuSe.toggleSelection($scope, option);
    };

    $scope.isSelected = function (option) {
        return $scope.selectedBuilding.indexOf(option) > -1;
    };

    $scope.$watch('selectedBuilding', function (newVal, oldVal) {
        MuSe.handleSelectedBuildingChange(newVal, oldVal, $scope, apiUrlGetAllRoomOfABuilding, Pani.fetchDataForBuildingIDs);
    }, true);

    //Booking
    $scope.isBooked = function (RoomID) {
        return Bo.isBooked(RoomID, $q, apiUrlIsBooked);
    };

    $scope.openConfirmBookingForm = function (room) {
        $scope.selectedRoom = room;
    }

    $scope.bookRoom = function (room) {
        return Bo.bookRoom($scope, room, apiUrlSentBookingForm);
    };

    $scope.getStudentInRoom = function () {
        return Bo.getStudentInRoom($scope, apiUrlGetStudentInRoom)
    }
    $scope.getStudentInRoom();
});