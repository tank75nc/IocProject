using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIocContainer;
using Xunit;

namespace MyIocContainer.Tests
{
    public class IocContainerTests
    {
        [Fact]
        public void Register_AddSimpleTypeToContainer()
        {
            // test of registering a simple type to the container
            // resolving it, and comparing with a manually created object to 
            // show it is of the same type.
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();

            System.Xml.XmlDocument expected = new System.Xml.XmlDocument();

            System.Xml.XmlDocument actual = container.Resolve<System.Xml.XmlDocument>();            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Register_AddSimpleTypeToContainerNotEqual()
        {
            // test of registering a simple type to the container
            // resolving it and then comparing it against an object to show it  
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            
            object expected = new object();

            System.Xml.XmlDocument actual = container.Resolve<System.Xml.XmlDocument>();

            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void Register_AddComplexTypeToContainer()
        {
            // test of registering a type with a single dependent parameter type
            // comparing it with a manually created object of the same type
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<ComplexType, ComplexType>();

            ComplexType expected = new ComplexType(new System.Xml.XmlDocument());

            ComplexType actual = container.Resolve<ComplexType>();

            Assert.IsType<ComplexType>(expected);
            Assert.IsType<System.Xml.XmlDocument>(expected.xml);
            Assert.IsType<ComplexType>(actual);
            Assert.IsType<System.Xml.XmlDocument>(actual.xml);
        }

        [Fact]
        public void Register_AddVeryComplexTypeToContainer()
        {
            // test of registering a type with multiple dependent parameter types
            // comparing it with a manually created object of the same type
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<StringBuilder, StringBuilder>();
            container.Register<VeryComplexType, VeryComplexType>();

            VeryComplexType expected = new VeryComplexType(new System.Xml.XmlDocument(), new StringBuilder());

            VeryComplexType actual = container.Resolve<VeryComplexType>();

            Assert.IsType<VeryComplexType>(expected);
            Assert.IsType<System.Xml.XmlDocument>(expected.xml);
            Assert.IsType<StringBuilder>(expected.sb);
            Assert.IsType<VeryComplexType>(actual);
            Assert.IsType<System.Xml.XmlDocument>(actual.xml);
            Assert.IsType<StringBuilder>(actual.sb);
        }

        [Fact]
        public void Resolve_SimpleSameInstanceFromContainer()
        {
            // test of resolving a type with no dependent parameter types
            // to see if the LifeCycle is Singleton as specified
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>(LifeCycle.Singleton);

            System.Xml.XmlDocument expected = container.Resolve<System.Xml.XmlDocument>();

            System.Xml.XmlDocument actual = container.Resolve<System.Xml.XmlDocument>();

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Resolve_SimpleNotSameInstanceFromContainer()
        {
            // test of resolving a type with no dependent parameter types
            // to see if the LifeCycle is the default transient
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();

            System.Xml.XmlDocument expected = container.Resolve<System.Xml.XmlDocument>();

            System.Xml.XmlDocument actual = container.Resolve<System.Xml.XmlDocument>();

            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void Resolve_SimpleNotSameInstanceFromContainer2()
        {
            // test of resolving a type with no dependent parameter types
            // to see if the LifeCycle is Transient as specified
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>(LifeCycle.Transient);

            System.Xml.XmlDocument expected = container.Resolve<System.Xml.XmlDocument>();

            System.Xml.XmlDocument actual = container.Resolve<System.Xml.XmlDocument>();

            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void Resolve_ComplexSameInstanceFromContainer()
        {
            // test of resolving a type that has a single dependent parameter type
            // to see if the instance is singleton as specified
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>(LifeCycle.Singleton);
            container.Register<ComplexType, ComplexType>(LifeCycle.Singleton);

            ComplexType expected = container.Resolve<ComplexType>();

            ComplexType actual = container.Resolve<ComplexType>();

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Resolve_ComplexNotSameInstanceFromContainer()
        {
            // test of resolving a type that has a single dependent parameter type
            // to see if the instance is transient
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<ComplexType, ComplexType>();

            ComplexType expected = container.Resolve<ComplexType>();

            ComplexType actual = container.Resolve<ComplexType>();

            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void Resolve_VeryComplexSameInstanceFromContainer()
        {
            // test of resolving a type that has dependent parameter types
            // to see if the instance is singleton as specified
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>(LifeCycle.Singleton);
            container.Register<StringBuilder, StringBuilder>(LifeCycle.Singleton);
            container.Register<VeryComplexType, VeryComplexType>(LifeCycle.Singleton);

            VeryComplexType expected = container.Resolve<VeryComplexType>();

            VeryComplexType actual = container.Resolve<VeryComplexType>();

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Resolve_VeryComplexSameInstanceFromContainer2()
        {
            // test of resolving a type that has dependent parameter types
            // to see if the instance is singleton as specified
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<StringBuilder, StringBuilder>();
            container.Register<VeryComplexType, VeryComplexType>(LifeCycle.Singleton);

            VeryComplexType expected = container.Resolve<VeryComplexType>();

            VeryComplexType actual = container.Resolve<VeryComplexType>();

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Resolve_VeryComplexNotSameInstanceFromContainer()
        {
            // test of resolving a type that has dependent parameter types
            // to see if the instance is transient
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<StringBuilder, StringBuilder>();
            container.Register<VeryComplexType, VeryComplexType>();

            VeryComplexType expected = container.Resolve<VeryComplexType>();

            VeryComplexType actual = container.Resolve<VeryComplexType>();

            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void Resolve_VeryComplexNotSameInstanceFromContainer2()
        {
            // test of resolving a type that has dependent parameter types
            // to see if the instance is transient
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>(LifeCycle.Singleton);
            container.Register<StringBuilder, StringBuilder>(LifeCycle.Singleton);
            container.Register<VeryComplexType, VeryComplexType>();

            VeryComplexType expected = container.Resolve<VeryComplexType>();

            VeryComplexType actual = container.Resolve<VeryComplexType>();

            Assert.NotSame(expected, actual);
        }

        [Fact]
        public void ThrowException_TypeNotRegistered()
        {
            // test of exception if a dependent type is not registered
            IMyContainer container = new IocContainer();
            container.Register<System.Xml.XmlDocument, System.Xml.XmlDocument>();
            container.Register<VeryComplexType, VeryComplexType>();

            Exception ex = Assert.Throws<Exception>(() => container.Resolve<VeryComplexType>());

            Assert.Contains("StringBuilder", ex.Message);
        }
    }
}
