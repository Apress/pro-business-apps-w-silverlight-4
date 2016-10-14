namespace AdventureWorksLOB.Web
{
    using System.Security.Authentication;
    using System.Threading;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;
    using System.ServiceModel.DomainServices.Hosting;

    /// <summary>
    ///    RIA Services DomainService responsible for authenticating users when
    ///    they try to log on to the application.
    ///    
    ///    Most of the functionality is already provided by the base class
    ///    AuthenticationBase
    /// </summary>
    [EnableClientAccess]
    public class AuthenticationService : AuthenticationBase<User> { }
}
