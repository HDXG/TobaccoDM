using Volo.Abp.Domain.Entities;

namespace TobaccoDMInputAcceptance.InitialInspections;

/// <summary>
/// 烟草种植户
/// </summary>
public class TobaccoGrower : Entity<Guid>
{
    protected TobaccoGrower(Guid id,Guid initialInspectionId,string name, string idCard, decimal implementationQuantity): base(id)
    {
        InitialInspectionId = initialInspectionId;
        Name = name;
        IdCard = idCard;
        ImplementationQuantity = implementationQuantity;
    }
    
    /// <summary>
    /// 初验Id
    /// </summary>
    public Guid InitialInspectionId { get; private set; }
    
    public string Name { get; private set; }
    
    public string IdCard { get; private set; }
    
    /// <summary>
    /// 实施数量
    /// </summary>
    /// <returns></returns>
    public decimal ImplementationQuantity { get; private set; }
    
    /// <summary>
    /// 初验数量
    /// </summary>
    public decimal? InitialInspectionQuantity { get; private set; }
    
    /// <summary>
    /// 初验时间
    /// </summary>
    public DateTime? InitialInspectionTime { get; private set; }

    public void ChangeInitialInspectionQuantity(decimal initialInspectionQuantity)
    {
        InitialInspectionQuantity = initialInspectionQuantity;
        InitialInspectionTime = DateTime.Now;
    }
}