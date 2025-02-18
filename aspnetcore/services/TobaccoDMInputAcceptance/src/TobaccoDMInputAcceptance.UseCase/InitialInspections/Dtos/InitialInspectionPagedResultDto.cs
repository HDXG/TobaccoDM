using Dedsi.Ddd.Application.Contracts.Dtos;

namespace TobaccoDMInputAcceptance.InitialInspections.Dtos;

public class InitialInspectionPagedResultDto : DedsiPagedResultDto<InitialInspectionPagedItemDto>;

public class InitialInspectionPagedItemDto
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// 初验名称
    /// </summary>
    public string InitialName { get; set; }
    
    /// <summary>
    /// 初验描述
    /// </summary>
    public string InitialDescription { get; set; }
    
    /// <summary>
    /// 初验员名称
    /// </summary>
    public string InitialInspectorUserName { get; set; }
    
    /// <summary>
    /// 烟农
    /// </summary>
    public TobaccoGrowerPagedItemDto[] TobaccoGrowers { get; set; }
}

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="IdCard"></param>
/// <param name="ImplementationQuantity"></param>
/// <param name="InitialInspectionQuantity"></param>
/// <param name="InitialInspectionTime"></param>
public record TobaccoGrowerPagedItemDto(string Name, string IdCard, decimal ImplementationQuantity, decimal? InitialInspectionQuantity, DateTime? InitialInspectionTime);