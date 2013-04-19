using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using Autofac;
using Topshelf;

namespace MassTransitHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running MassTransitHost with arguments {0}", string.Join(" ", args));

            if (args.Length != 2)
            {
                throw new InvalidOperationException("Arguments should contain entry point assembly name");
            }
            
            string assemblyName = args[0];
            string classFullName = args[1];

            var assembly = Assembly.Load(assemblyName);
            if (assembly == null)
            {
                throw new InvalidOperationException(string.Format("Could not load assembly {0}", assemblyName));
            }

            string bootstrapperName = assembly.GetTypes().First(x => x.GetInterface(typeof(IBootstrapper).Name) != null).FullName;
            var bootstrapper = (IBootstrapper)assembly.CreateInstance(bootstrapperName);
            if (bootstrapper == null)
            {
                throw new InvalidOperationException("Assembly should contain a bootstrapper");
            }

            Type publisherType = assembly.GetTypes().First(x => x.GetInterface(typeof (IPublisher).Name) != null);
            var builder = new ContainerBuilder();
            builder.RegisterType(publisherType).As<IPublisher>();
            bootstrapper.Initialize(builder);

            HostFactory.Run(c =>
                                {
                                    c.SetServiceName(classFullName);
                                    c.SetDisplayName(classFullName);
                                    c.RunAsLocalSystem();
                                    c.DependsOnMsmq();
                                });


        }
    }
}
