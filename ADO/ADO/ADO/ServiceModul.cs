using ADO.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO
{
    class ServiceModul : NinjectModule
    {
        readonly string connectionString;
        public ServiceModul(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public override void Load()
        {
            Bind(typeof(IParser<string[]>)).To(typeof(ParametersParser));
            Bind<ICommanderADO>().To<CommanderADO>().WithConstructorArgument(connectionString);
        }
    }
}
