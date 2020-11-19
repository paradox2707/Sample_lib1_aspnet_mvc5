using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task25.BLL.Interfaces.IServices;
using Task25.BLL.Services;
using Task25.Controllers;

namespace Task25.Infrustructure
{
    public class NinjectRegistrations : NinjectModule
    {

        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IAnketService>().To<AnketService>();
            Bind<ITegService>().To<TegService>();
        }
    }
}