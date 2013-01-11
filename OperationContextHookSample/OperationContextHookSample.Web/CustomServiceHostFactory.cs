using System.ServiceModel;

namespace OperationContextHookSample.Web
{
    public class CustomServiceHostFactory : System.ServiceModel.Activation.ServiceHostFactory
    {
        public override System.ServiceModel.ServiceHostBase CreateServiceHost(string constructorString, System.Uri[] baseAddresses)
        {
            ServiceHostBase serviceHostBase = base.CreateServiceHost(constructorString, baseAddresses);

            return serviceHostBase;
        }

        protected override System.ServiceModel.ServiceHost CreateServiceHost(System.Type serviceType, System.Uri[] baseAddresses)
        {
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
}