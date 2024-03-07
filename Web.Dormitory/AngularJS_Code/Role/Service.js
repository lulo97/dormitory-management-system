const baseURL = '/api/role/';

app.service("RoleService", function ($http) {

    this.getAllRolesSimplify = function () {
        var response = $http({
            method: "get",
            url: baseURL + "getAllRolesSimplify",
        });
        return response;
    }

    this.getAllUsersSimplify = function () {
        var response = $http({
            method: "get",
            url: baseURL + "getAllUsersSimplify",
        });
        return response;
    }

    this.createRole = function (roleName) {
        var response = $http({
            method: "post",
            url: baseURL + "createRole",
            params: {
                roleName: roleName,
            }
        });
        return response;
    }

    this.deleteRole = function (roleName) {
        var response = $http({
            method: "delete",
            url: baseURL + "deleteRole",
            params: {
                roleName: roleName,
            }
        });
        return response;
    }

    this.editRole = function (oldRoleName, editRoleName) {
        var response = $http({
            method: "put",
            url: baseURL + "editRole",
            params: {
                oldRoleName: oldRoleName,
                editRoleName: editRoleName
            }
        });
        return response;
    }

    this.addRoleToUser = function (userId, roleName) {
        var response = $http({
            method: "post",
            url: baseURL + "addRoleToUser",
            params: {
                userId: userId,
                roleName: roleName
            }
        });
        return response;
    }

    this.removeRoleFromUser = function (userId, roleName) {
        var response = $http({
            method: "delete",
            url: baseURL + "removeRoleFromUser",
            params: {
                userId: userId,
                roleName: roleName
            }
        });
        return response;
    }
});