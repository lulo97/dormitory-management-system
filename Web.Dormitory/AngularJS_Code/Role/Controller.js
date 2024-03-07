app.controller('RoleController', function ($scope, $window, RoleService) {
    // Fetch roles from the API
    function getAllRolesSimplify() {
        RoleService.getAllRolesSimplify()
            .then(function (response) {
                $scope.roles = response.data;
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }
    getAllRolesSimplify();

    // Fetch users from the API
    function getAllUsersSimplify() {
        RoleService.getAllUsersSimplify()
            .then(function (response) {
                $scope.users = response.data;
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }
    getAllUsersSimplify();

    //Create new role
    $scope.newRoleName = '';
    $scope.handleCreateRoleClick = function() {
        RoleService.createRole($scope.newRoleName)
            .then(function (response) {
                //console.log(response.data)
                $scope.setShowAddRoleModal('hide');
                showToast("success", "Sucess!", response.data)
                waitForToastAfterClick(window);
            })
            .catch(function (error) {
                //console.error('Error:', error.data.Message);
                showToast("error", "Error!", error.data.Message)
            });
    }

    //Open add role modal
    $scope.setShowAddRoleModal = function (state) {
        $('#AddRoleModal').modal(state); // Use jQuery to show the Bootstrap modal
    };

    //Delete role
    $scope.handleDeleteRoleClick = function (roleName) {
        RoleService.deleteRole(roleName)
            .then(function (response) {
                showToast("success", "Sucess!", response.data)
                waitForToastAfterClick(window);
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }

    //Edit role name
    $scope.handleEditRoleClick = function () {
        RoleService.editRole($scope.oldRoleName, $scope.editRoleName)
            .then(function (response) {
                showToast("success", "Sucess!", response.data)
                waitForToastAfterClick(window);
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }

    //Open edit role modal
    $scope.setShowEditRoleModal = function (state, role) {
        $scope.oldRoleName = role;
        $scope.editRoleName = '';
        $('#EditRoleModal').modal(state);
    }

    //Add role to user
    $scope.addRoleToUser = function (userId, roleName) {
        RoleService.addRoleToUser(userId, roleName)
            .then(function (response) {
                showToast("success", "Sucess!", response.data)
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }

    //Open User Role Management Modal
    $scope.openUserRoleManagementModal = function (state, current_user) {
        $scope.current_user = current_user
        $scope.newUserRoleName = ''
        $('#UserRoleManagementModal').modal(state);
    } 

    $scope.handleAddUserRoleClick = function () {
        userId = $scope.current_user.Id;
        roleName = $scope.newUserRoleName;
        var isRoleExist = $scope.roles.some(function (role) {
            return role.Name === roleName;
        });

        if (!isRoleExist) {
            console.log("Role name unknow: ", roleName)
            return
        }

        RoleService.addRoleToUser(userId, roleName)
            .then(function (response) {
                showToast("success", "Sucess!", response.data)
                waitForToastAfterClick(window);
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }

    $scope.handleRemoveRoleFromUserClick = function (roleName) {
        userId = $scope.current_user.Id;
        RoleService.removeRoleFromUser(userId, roleName)
            .then(function (response) {
                showToast("success", "Sucess!", response.data)
                waitForToastAfterClick(window);
            })
            .catch(function (error) {
                showToast("error", "Error!", error.data.Message)
            });
    }
});