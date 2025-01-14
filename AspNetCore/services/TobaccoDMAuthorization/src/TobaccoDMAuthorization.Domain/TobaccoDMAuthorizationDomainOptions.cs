using Dedsi.CleanArchitecture.Domain;

namespace TobaccoDMAuthorization;

public class TobaccoDMAuthorizationDomainOptions : DedsiCleanArchitectureDomainOptions
{
    public const string ApplicationName = "ProjectName";
    
    public const string MobileApplicationName = "ProjectName.Mobile";
    
    public const string ConnectionStringName = "ProjectNameDB";
    
    public const string DbSchemaName  = "ProjectName";

    public const string DbTablePrefix = "ProjectName";
}