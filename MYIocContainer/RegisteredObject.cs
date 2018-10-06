using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyIocContainer
{
    public class RegisteredObject
    {
        public RegisteredObject(Type pTypeToResolve, Type pConcreteType, LifeCycle pLifeCycle)
        {
            objTypeToResolve = pTypeToResolve;
            objConcreteType = pConcreteType;
            objLifeCycle = pLifeCycle;
        }

        private Type objTypeToResolve;
        public Type TypeToResolve
        {
            get
            {
                return objTypeToResolve;
            }
        }

        private Type objConcreteType;
        public Type ConcreteType
        {
            get
            {
                return objConcreteType;
            }
        }

        private object objInstance;
        public object Instance
        {
            get
            {
                return objInstance;
            }
        }

        private LifeCycle objLifeCycle;
        public LifeCycle LifeCycle
        {
            get
            {
                return objLifeCycle;
            }
        }
                

        public void CreateInstance(params object[] args)
        {
            objInstance = Activator.CreateInstance(objConcreteType, args);
        }
    }
}