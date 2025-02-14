using Dedsi.Ddd.Domain.Repositories;
using TobaccoDMInputAcceptance.InitialInspections;
using Dedsi.EntityFrameworkCore.Repositories;
using TobaccoDMInputAcceptance.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TobaccoDMInputAcceptance.Repositories.InitialInspections;

public interface IInitialInspectionRepository : IDedsiCqrsRepository<InitialInspection, Guid>;

public class InitialInspectionRepository(IDbContextProvider<TobaccoDMInputAcceptanceDbContext> dbContextProvider) 
    : DedsiCqrsEfCoreRepository<TobaccoDMInputAcceptanceDbContext, InitialInspection, Guid>(dbContextProvider), IInitialInspectionRepository;