using FluentValidation;

namespace TobaccoDMSystemManagement.AppService.SystemMenus.Dtos;

/// <summary>
/// 创建菜单
/// https://abp.io/docs/latest/framework/fundamentals/fluent-validation
/// https://fluentvalidation.net/
/// </summary>
public class CreateSystemMenuInputDto
{
    public string MenuName { get; set; }
    
    public string MenuPath { get; set; }
    
    public string Icon { get; set; }
    
    public string PermissionKey { get; set; }
    
    public string RouteName { get; set; }
    
    public string ComponentPath { get; set; }
    
    /// <summary>
    /// 排序字段
    /// </summary>
    public int OrderIndex { get; set; }

    /// <summary>
    /// 子菜单
    /// </summary>
    public CreateSystemMenuInputDto[] Childrens { get; set; }
}

public class CreateSystemMenuInputDtoValidator : AbstractValidator<CreateSystemMenuInputDto>
{
    public CreateSystemMenuInputDtoValidator()
    {
        RuleFor(x => x.MenuName).Must(x => !x.IsNullOrWhiteSpace());
    }
}
