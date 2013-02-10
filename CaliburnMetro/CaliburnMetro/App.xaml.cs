using Windows.ApplicationModel.Activation;


namespace CaliburnMetro
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Caliburn.Micro;
    //using Views;

    sealed partial class App : CaliburnApplication
    {
        private WinRTContainer _container;

        public App()
        {
            this.InitializeComponent();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();
        }

        protected override object GetInstance(Type service, string key)
        {
            var obj = _container.GetInstance(service, key);

            // mimic previous behaviour of WinRT SimpleContainer
            if (obj == null && IsConcrete(service))
            {
                _container.RegisterPerRequest(service, key, service);
                obj = _container.GetInstance(service, key);
            }

            return obj;
        }

        private static bool IsConcrete(Type service)
        {
            var serviceInfo = service.GetTypeInfo();
            return !serviceInfo.IsAbstract && !serviceInfo.IsInterface;
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Windows.UI.Xaml.Controls.Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<Views.MainPage>();
        }
    }
}
