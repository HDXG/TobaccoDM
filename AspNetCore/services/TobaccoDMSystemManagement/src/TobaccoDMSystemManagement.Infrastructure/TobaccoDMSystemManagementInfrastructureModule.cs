﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using TobaccoDMSystemManagement.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Infrastructure;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule)
)]
public class TobaccoDMSystemManagementInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        var connectionConfig = new ConnectionConfig
        {
            DbType = DbType.SqlServer,
            ConnectionString = configuration.GetConnectionString(TobaccoDMSystemManagementConsts.ConnectionStringName),
            IsAutoCloseConnection = true
        };
        context.Services.AddScoped<ISqlSugarClient>(s => new SqlSugarClient(connectionConfig));
    }
}
