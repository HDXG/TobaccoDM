using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace TobaccoDMInputAcceptance.InitialInspections;

/// <summary>
/// 初验
/// </summary>
public class InitialInspection : Entity<Guid>
{
    protected InitialInspection()
    {
        
    }
    
    public InitialInspection(Guid id, string initialName, string initialDescription, InitialInspector initialInspector): base(id)
    {
        ChangeInitialName(initialName);
        ChangeDescription(initialDescription);
        ChangeInitialInspector(initialInspector);
    }
    
    /// <summary>
    /// 初验名称
    /// </summary>
    public string InitialName { get; private set; }

    public void ChangeInitialName(string newInitialName)
    {
        InitialName = Check.NotNullOrWhiteSpace(newInitialName, nameof(newInitialName));
    }
    
    /// <summary>
    /// 初验描述
    /// </summary>
    public string InitialDescription { get; private set; }

    public void ChangeDescription(string newDescription)
    {
        InitialDescription = Check.NotNullOrWhiteSpace(newDescription, nameof(newDescription));
    }
    
    /// <summary>
    /// 初验员
    /// </summary>
    public InitialInspector InitialInspector { get; private set; }

    public void ChangeInitialInspector(InitialInspector newInspector)
    {
        InitialInspector = newInspector;
    }
   
    /// <summary>
    /// 验收的烟农
    /// </summary>
    public ICollection<TobaccoGrower> TobaccoGrowers { get; private set; } = new List<TobaccoGrower>();

    /// <summary>
    /// 添加烟农并设置投入验收Id
    /// </summary>
    /// <param name="tobaccoGrowers"></param>
    public void AddTobaccoGrowerAndSetInitialInspectionId(IEnumerable<TobaccoGrower> tobaccoGrowers)
    {
        foreach (var tobaccoGrower in TobaccoGrowers)
        {
            tobaccoGrower.ChangeInitialInspectionId(Id);
            
            AddTobaccoGrower(tobaccoGrower);
        }
    }
    
    public void AddTobaccoGrower(TobaccoGrower tobaccoGrower)
    {
        TobaccoGrowers.Add(tobaccoGrower);
    }

    public void ClearTobaccoGrowers()
    {
        TobaccoGrowers.Clear();
    }
}