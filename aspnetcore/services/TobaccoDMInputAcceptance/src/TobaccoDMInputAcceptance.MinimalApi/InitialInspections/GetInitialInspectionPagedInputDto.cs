using Dedsi.Ddd.Application.Contracts.Dtos;

namespace TobaccoDMInputAcceptance.InitialInspections;

public class GetInitialInspectionPagedInputDto : DedsiPagedRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public string InitialName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string InitialInspectorUserName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string TobaccoGrowerName { get; set; }
}