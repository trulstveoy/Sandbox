using System;
using System.Linq;
using System.Reflection;
using Autofac;
using MassTransit;
using Topshelf;

namespace MassTransitHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running MassTransitHost with arguments {0}", string.Join(" ", args));

            if (args.Length != 1)
            {
                throw new InvalidOperationException("Arguments should contain entry point assembly name");
            }
            
            string assemblyName = args[0];
            //string classFullName = args[1];

            var assembly = Assembly.Load(assemblyName);
            if (assembly == null)
            {
                throw new InvalidOperationException(string.Format("Could not load assembly {0}", assemblyName));
            }

            //string bootstrapperName = assembly.GetTypes().First(x => x.GetInterface(typeof(IBootstrapper).Name) != null).FullName;
            //var bootstrapper = (IBootstrapper)assembly.CreateInstance(bootstrapperName);
            //if (bootstrapper == null)
            //{
            //    throw new InvalidOperationException("Assembly should contain a bootstrapper");
            //}

            Type commandHandlerType = assembly.GetTypes().FirstOrDefault(x => x.GetInterface(typeof(IHandleCommand).Name) != null);
            if (commandHandlerType != null)
            {
                string queueName = commandHandlerType.FullName;

                var builder = new ContainerBuilder();
                builder.RegisterType(commandHandlerType).As(typeof (IHandleCommand));
                builder.Register(c =>
                                 (
                                     ServiceBusFactory.New(sbc =>
                                                               {
                                                                   //sbc.ReceiveFrom(string.Format("msmq://localhost/{0}", queueName));
                                                                   sbc.ReceiveFrom(string.Format("msmq://localhost/{0}", "FooBarServer"));
                                                                   sbc.UseMsmq();
                                                                   sbc.UseControlBus();
                                                                   sbc.Subscribe(subs => subs.LoadFrom(c.Resolve<ILifetimeScope>()));
                                                               })
                                 )).As<IServiceBus>().SingleInstance();

                IContainer container = builder.Build();
                var handleCommand = container.Resolve<IHandleCommand>();

                Console.WriteLine("Press any key");
                Console.ReadKey();
                return;
            }

            Type commandSenderType = assembly.GetTypes().FirstOrDefault(x => x.GetInterface(typeof (ISendCommand).Name) != null);
            if (commandSenderType != null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType(commandSenderType).As(typeof(ISendCommand));
                builder.Register(c =>
                                 (
                                     ServiceBusFactory.New(sbc =>
                                     {
                                         sbc.ReceiveFrom(string.Format("msmq://localhost/{0}", "FooBarClient"));
                                         sbc.UseMsmq();
                                         sbc.UseControlBus();
                                         //sbc.Subscribe(subs => subs.LoadFrom(c.Resolve<ILifetimeScope>()));
                                     })
                                 )).As<IServiceBus>().SingleInstance();

                IContainer container = builder.Build();

                var bus = container.Resolve<IServiceBus>();
                var sendCommand = container.Resolve<ISendCommand>();
                sendCommand.Start(bus);

                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}
