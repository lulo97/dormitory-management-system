app.service('PanigationService', function ($http) {
    var self = this;

    this.setPagingData = function (page, scope) {
        var pagedData = scope.rooms.slice(
            (page - 1) * scope.itemsPerPage,
            page * scope.itemsPerPage
        );
        scope.roomToShow = pagedData;
    };

    this.fetchBuildings = function (scope, apiGetAllBulding) {
        console.log("apiGetAllBulding = ", apiGetAllBulding)
        $http.get(apiGetAllBulding)
            .then(function (response) {
                scope.buildings = response.data.map(item => ({
                    "ID": item.ID,
                    "BuildingName": item.BuildingName,
                    "Price": item.Price
                }));
            })
            .catch(function (error) {
                console.error('Error fetching data:', error);
            });
    };

    this.fetchRoomsByBuildingID = function (buildingID, apiUrlGetAllRoomOfABuilding) {
        return $http.get(apiUrlGetAllRoomOfABuilding, { params: { BuildingID: buildingID } })
            .then(response => response.data)
            .catch(error => {
                console.error('Error fetching data:', error);
                throw error; // Rethrow the error to be caught by the Promise.all
            });
    };

    this.combineRooms = function (scope, results) {
        console.log("combineRooms: scope = ", scope)
        scope.$apply(function () {
            scope.rooms = results.reduce((accumulator, currentRooms) => accumulator.concat(currentRooms), []);
            scope.rooms.sort((a, b) => a.BuildingID - b.BuildingID);
            scope.roomToShow = scope.rooms;
            scope.totalItems = scope.rooms.length;
            //setPagingData(1);
            self.setPagingData(1, scope)
        });

        scope.$watch("currentPage", function () {
            //setPagingData($scope.currentPage);
            self.setPagingData(scope.currentPage, scope);
        });
    };

    this.fetchDataForBuildingIDs = function (buildingIDs, scope, apiUrlGetAllRoomOfABuilding) {
        const fetchPromises = buildingIDs.map(buildingID => self.fetchRoomsByBuildingID(
            buildingID, apiUrlGetAllRoomOfABuilding
        ));

        Promise.all(fetchPromises)
            .then(results => {
                console.log("fetchDataForBuildingIDs: scope = ", scope)
                self.combineRooms(scope, results)
            })
            .catch(error => {
                console.error('Error:', error);
            });
    };
});

app.service('BookingService', function ($http, $q) {
    this.isBooked = function (RoomID, q, apiUrlIsBooked) {
        var deferred = q.defer();

        $http.post(apiUrlIsBooked + `/?RoomID=${RoomID}`)
            .then(function (response) {
                // Handle success
                deferred.resolve(response.data);
            })
            .catch(function (error) {
                console.error('Error', error);
                deferred.reject(error);
            });

        return deferred.promise;
    };

    this.handleIsBookedFalse = function (apiUrlSentBookingForm, room) {
        //showToast("success", "Success!", 'Booking room successfully!')
        //return;

        // Proceed with the booking logic here

        // Make an HTTP POST request to the API endpoint
        $http.post(apiUrlSentBookingForm + `/?RoomID=${room.RoomID}`)
            .then(function (response) {
                // Handle success
                showToast("success", "Success!", 'Booking room successfully!')
                //console.log('Booking successful', response);
            })
            .catch(function (error) {
                // Handle error
                console.error('Error booking room', error);
            });
    };

    this.bookRoom = function (scope, room, apiUrlSentBookingForm) {
        scope.isBooked(room.RoomID).then(function (isBooked) {
            if (isBooked) {
                showToast("error", "Error!", `You already book this room (RoomID=${room.RoomID})!`)
            } else {
                handleIsBookedFalse(apiUrlSentBookingForm, room)
            }
        }).catch(function (error) {
            console.error("Error checking if the room is booked:", error);
        });
    };

    this.getStudentInRoom = function (scope, apiUrlGetStudentInRoom) {
        scope.showAlreadyInRoomWarning = false;
        $http.get(apiUrlGetStudentInRoom)
            .then(function (response) {
                scope.studentInRoomData = response.data;
                if (scope.studentInRoomData != null) {
                    scope.showAlreadyInRoomWarning = true;
                } else {
                    console.log(scope.studentInRoomData.RoomID)
                }
            })
            .catch(function (error) {
                console.log("Current student not in anyroom");
            });
    };
});

app.service('MutipleSelectService', function ($http, $q) {
    this.getSelectedOptionsText = function (scope) {
        if (scope.selectedBuilding.length === 0) {
            return 'Select options';
        } else if (scope.selectedBuilding.length <= 2) {
            return scope.selectedBuilding.join(', ');
        } else {
            return scope.selectedBuilding.length + ' options selected';
        }
    };

    this.toggleSelectAll = function (scope) {
        if (scope.selectedBuilding.length === scope.buildings.length) {
            scope.selectedBuilding = [];
        } else {
            scope.selectedBuilding = scope.buildings.map(item => item.BuildingName);
        }
    };

    this.toggleSelection = function (scope, option) {
        var index = scope.selectedBuilding.indexOf(option);
        if (index > -1) {
            scope.selectedBuilding.splice(index, 1);
        } else {
            scope.selectedBuilding.push(option);
        }
    };

    this.handleSelectedBuildingChange = function (newVal, oldVal, scope, apiUrlGetAllRoomOfABuilding, fetchDataForBuildingIDs) {
        const selectedBuildingIDs = newVal.map(ele => {
            return scope.buildings.find(building => building.BuildingName === ele).ID;
        });
        fetchDataForBuildingIDs(selectedBuildingIDs, scope, apiUrlGetAllRoomOfABuilding);
    };
});