using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyIocContainer
{
    public class IocContainer : IMyContainer
    {

        private readonly List<RegisteredObject> lstRegisteredObjects = new List<RegisteredObject>();
        private Dictionary<object, RegisteredObject> dicResolvedObjects = new Dictionary<object, RegisteredObject>();


        public void Register<TTypeToResolve, TConcrete>()
        {
            Register<TTypeToResolve, TConcrete>(LifeCycle.Transient);
        }

        public void Register<TTypeToResolve, TConcrete>(LifeCycle pLifeCycle)
        {
            lstRegisteredObjects.Add(new RegisteredObject(typeof(TTypeToResolve), typeof(TConcrete), pLifeCycle));
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }


        public object Resolve(Type pTypeToResolve)
        {
            return ResolveObject(pTypeToResolve);
        }


        private object ResolveObject(Type pTypeToResolve)
        {
            var registeredObject = lstRegisteredObjects.FirstOrDefault(o => o.TypeToResolve == pTypeToResolve);
            if (registeredObject == null)
            {
                throw new Exception(string.Format(
                    "The type {0} has not been registered", pTypeToResolve.Name));
            }
            return GetInstance(registeredObject);
        }


        private object GetInstance(RegisteredObject pRegisteredObject)
        {
            if (pRegisteredObject.Instance == null ||
                pRegisteredObject.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(pRegisteredObject);
                pRegisteredObject.CreateInstance(parameters.ToArray());
                dicResolvedObjects.Add(pRegisteredObject.Instance, pRegisteredObject);
            }
            return pRegisteredObject.Instance;
        }


        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject pRegisteredObject)
        {
            var constructorInfo = pRegisteredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }    
}