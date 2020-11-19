using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task25.BLL.Interfaces.IServices;
using Task25.BLL.Services;
using Task25.DAL.Infrastructure.Entities;
using Task25.DAL.Infrastructure.Interfaces;

namespace Task25.BLL.Infrustructure
{
    public class NinjectRegistrationsBLL : NinjectModule
    {
        private string connectionString;
        public NinjectRegistrationsBLL(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);            
        }

    }
}