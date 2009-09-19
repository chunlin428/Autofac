﻿using System;
using NUnit.Framework;
using System.Linq;
using Autofac.Core.Activators.ProvidedInstance;
using Autofac.Core;

namespace Autofac.Tests.Component.Activation
{
    [TestFixture]
    public class ProvidedInstanceActivatorFixture
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructNull()
        {
            ProvidedInstanceActivator target =
                new ProvidedInstanceActivator(null);
        }

        [Test]
        public void ActivateInstance()
        {
            object instance = new object();

            ProvidedInstanceActivator target =
                new ProvidedInstanceActivator(instance);

            Assert.AreSame(instance, target.ActivateInstance(new Container(), Enumerable.Empty<Parameter>()));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ActivateInstanceTwice()
        {
            object instance = new object();

            ProvidedInstanceActivator target =
                new ProvidedInstanceActivator(instance);

            IComponentContext container = new Container();

            target.ActivateInstance(container, Enumerable.Empty<Parameter>());
            target.ActivateInstance(container, Enumerable.Empty<Parameter>());
        }
    }
}