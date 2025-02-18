using Dedsi.Ddd.Domain.Queries;
using Dedsi.EntityFrameworkCore.Queries;
using Microsoft.EntityFrameworkCore;
using TobaccoDMInputAcceptance.EntityFrameworkCore;
using TobaccoDMInputAcceptance.InitialInspections.Dtos;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMInputAcceptance.InitialInspections.Queries;

public interface IInitialInspectionQuery : IDedsiQuery
{
    /// <summary>
    /// 获取初验分页数据
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <param name="initialName"></param>
    /// <param name="initialInspectorUserName"></param>
    /// <param name="tobaccoGrowerName"></param>
    /// <returns></returns>
    Task<InitialInspectionPagedResultDto> GetInitialInspectionPagedAsync(CancellationToken cancellationToken, int skipCount, int maxResultCount, string initialName, string initialInspectorUserName, string tobaccoGrowerName);
}

public class InitialInspectionQuery(IDbContextProvider<TobaccoDMInputAcceptanceDbContext> dbContextProvider) 
    : DedsiEfCoreQuery<TobaccoDMInputAcceptanceDbContext>(dbContextProvider), 
        IInitialInspectionQuery
{
    /// <inheritdoc />
    public async Task<InitialInspectionPagedResultDto> GetInitialInspectionPagedAsync(
        CancellationToken cancellationToken, 
        int skipCount, 
        int maxResultCount, 
        string initialName, 
        string initialInspectorUserName,
        string tobaccoGrowerName)
    {
        var dbContext = await GetDbContextAsync();

        var queryable = dbContext
            .InitialInspections
            .Include(x => x.InitialInspector)
            .Include(x => x.TobaccoGrowers)
            .AsNoTracking()
            .WhereIf(!string.IsNullOrEmpty(initialName), x => x.InitialName.Contains(initialName))
            .WhereIf(!string.IsNullOrEmpty(initialInspectorUserName), x => x.InitialInspector.UserName.Contains(initialInspectorUserName))
            .WhereIf(!string.IsNullOrEmpty(initialName), x => x.TobaccoGrowers.Any(y => y.Name.Contains(tobaccoGrowerName)));
        
        var totalCount = await queryable.LongCountAsync(cancellationToken);
        var items = await queryable
            .PageBy(skipCount, maxResultCount)
            .Select(a => new InitialInspectionPagedItemDto()
            {
                Id = a.Id,
                InitialName = a.InitialName,
                InitialDescription = a.InitialDescription,
                InitialInspectorUserName = a.InitialInspector.UserName,
                TobaccoGrowers = a.TobaccoGrowers
                                    .Select(x => new TobaccoGrowerPagedItemDto(x.Name, x.IdCard, x.ImplementationQuantity, x.InitialInspectionQuantity, x.InitialInspectionTime))
                                    .ToArray()
            })
            .ToListAsync(cancellationToken);
        
        return new InitialInspectionPagedResultDto
        {
            TotalCount = totalCount,
            Items = items
        };
    }
}