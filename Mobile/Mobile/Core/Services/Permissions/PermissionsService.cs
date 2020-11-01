using Mobile.Core.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobile.Core.Services.Permissions
{
    public class PermissionsService : IPermissionsService
    {
        public Task<PermissionStatus> CheckPermissionStatusAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<Permission, PermissionStatus>> RequestPermissionsAsync(params Permission[] permissions)
        {
            throw new NotImplementedException();
        }

        public static PermissionsService Instance => new PermissionsService();
    }
}
