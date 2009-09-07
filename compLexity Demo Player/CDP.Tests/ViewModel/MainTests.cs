﻿using System;
using NUnit.Framework;
using Moq;
using CDP.ViewModel;

namespace CDP.Tests.ViewModel
{
    [TestFixture]
    public class MainTests
    {
        private Main main;
        private Mock<Core.IDemoManager> demoManager;
        private Mock<Core.ViewModelBase> address;
        private Mock<Core.ViewModelBase> demos;
        private Mock<Core.ViewModelBase> demo;

        [SetUp]
        public void SetUp()
        {
            demoManager = new Mock<Core.IDemoManager>();
            address = new Mock<Core.ViewModelBase>();
            demos = new Mock<Core.ViewModelBase>();
            demo = new Mock<Core.ViewModelBase>();
            main = new Main(
                new Mock<Core.ISettings>().Object,
                demoManager.Object,
                address.Object,
                demos.Object,
                demo.Object);
        }

        [Test]
        public void Ctor_Ok()
        {
            Assert.That(main.Address, Is.EqualTo(address.Object));
            Assert.That(main.Demos, Is.EqualTo(demos.Object));
            Assert.That(main.Demo, Is.EqualTo(demo.Object));
        }
    }
}
