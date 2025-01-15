using Dedsi.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using TobaccoDMSystemManagement.Core;

namespace TobaccoDMSystemManagement;

[ApiController]
[Area(TobaccoDMSystemManagementCoreOptions.ApplicationName)]
[Route("api/TobaccoDMSystemManagement/[controller]/[action]")]
public abstract class TobaccoDMSystemManagementController: DedsiControllerBase;
