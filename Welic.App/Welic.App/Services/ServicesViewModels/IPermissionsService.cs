using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Permissions;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IPermissionsService
    {
        Task<PermissionStatus> CheckPermissionStatusAsync(Permission permission);
        Task<Dictionary<Permission, PermissionStatus>> RequestPermissionsAsync(params Permission[] permissions);
    }
}
