using Ninject;

namespace WPFChatApp.Core
{
    public static class IoC
    {

        /// <summary>
        /// Kernel for IoC Container
        /// </summary>
        public static IKernel Kernel {get; private set; } = new StandardKernel();

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// Sets up the IoC container as soon as your application starts up
        /// Binds all info required, and is ready to use
        /// </summary>
        public static void SetUp()
        {
            //Bind all required View Models
            BindViewModel();
        }

        private static void BindViewModel()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

     
    }
}
