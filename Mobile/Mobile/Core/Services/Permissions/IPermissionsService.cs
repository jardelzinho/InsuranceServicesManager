﻿using Mobile.Core.Models.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobile.Core.Services.Permissions
{
    public interface IPermissionsService
    {
        Task<PermissionStatus> CheckPermissionStatusAsync(Permission permission);
        Task<Dictionary<Permission, PermissionStatus>> RequestPermissionsAsync(params Permission[] permissions);
    }
}
