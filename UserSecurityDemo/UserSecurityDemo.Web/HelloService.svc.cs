using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace UserSecurityDemo.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloService
    {
        [OperationContract]
        public string HelloWorld()
        {
            // Add your operation implementation here
            return string.Format("Hello, {0} at {1}", HttpContext.Current.User.Identity.Name, DateTime.Now);
        }
    }
}
