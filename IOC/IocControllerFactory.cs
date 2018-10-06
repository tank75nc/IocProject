using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyIocContainer;

namespace IOC
{
    public class IocControllerFactory : DefaultControllerFactory
    {

        private readonly IMyContainer container;

        public IocControllerFactory(IMyContainer pContainer)
        {
            container = pContainer;
        }

        protected override IController GetControllerInstance(RequestContext pContext, Type pControllerType)
        {
            try
            {
                return container.Resolve(pControllerType) as Controller;
            }
            catch
            {
                return null; 
            }
        }

    }
}