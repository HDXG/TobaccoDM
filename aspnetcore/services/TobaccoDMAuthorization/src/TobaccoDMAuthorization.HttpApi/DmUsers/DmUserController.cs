using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Mvc;
using TobaccoDMAuthorization.DmUsers.Commands;
using TobaccoDMAuthorization.DmUsers.Requests;

namespace TobaccoDMAuthorization.DmUsers;

/// <summary>
/// 用户管理
/// </summary>
/// <param name="dedsiMediator"></param>
public class DmUserController(IDedsiMediator dedsiMediator) : TobaccoDMAuthorizationController
{
    /// <summary>
    /// 获得默认的密码
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string GetDefulatPpassWord() => DmUserConsts.DefulatPpassWord;

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> CreateDmUserAsync(CreateDmUserRequest request)
    {
        var dmUserRoles = new DmUserRoleItem[]
        {
            
        };
        
        return dedsiMediator.PublishAsync(new CreateDmUserCommand(request.UserName, request.LoginAccount, request.Email, dmUserRoles), HttpContext.RequestAborted);
    }
}