using System.ServiceModel;

namespace OperationContextHookSample
{
    [ServiceContract]
    public interface IFooService
    {
        [OperationContract]
        string Foo(int value);

        [OperationContract]
        int Bar(string s);
    }
}
