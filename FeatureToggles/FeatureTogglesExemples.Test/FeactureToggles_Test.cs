using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FeatureTogglesExemples.Test
{
    [TestClass]
    public class FeactureToggles_Test
    {
        [TestMethod]
        public void FeactureToggles_Test_IsEnabled_True()
        {
            Mock<IFeatureTogglesData> mock = new Mock<IFeatureTogglesData>();
            mock.Setup(m => m.ConsultaValor("MyFeacture")).Returns(true.ToString());

            var config = new FeactureTogglesConfig(mock.Object, false);
            var v = config.IsEnabled(EnumFeactureToggles.MyFeacture);
            Assert.IsTrue(v);
        }

        [TestMethod]
        public void FeactureToggles_Test_IsEnabled_False()
        {
            Mock<IFeatureTogglesData> mock = new Mock<IFeatureTogglesData>();
            mock.Setup(m => m.ConsultaValor("MyFeacture")).Returns(false.ToString());

            var config = new FeactureTogglesConfig(mock.Object, false);
            var v = config.IsEnabled(EnumFeactureToggles.MyFeacture);
            Assert.IsFalse(v);
        }

        [TestMethod]
        public void FeactureToggles_Test_IsEnabled_not_registered_in_dataBase()
        {
            Mock<IFeatureTogglesData> mock = new Mock<IFeatureTogglesData>();
            mock.Setup(m => m.ConsultaValor("MyFeacture")).Returns(string.Empty);

            var config = new FeactureTogglesConfig(mock.Object, false);
            var v = config.IsEnabled(EnumFeactureToggles.MyFeacture);
            Assert.IsFalse(v);

            mock.Verify(m => m.Insere("MyFeacture", false.ToString()));

        }

        [TestMethod]
        public void FeactureToggles_Test_IsEnabled_registered_with_invalid_value()
        {
            Mock<IFeatureTogglesData> mock = new Mock<IFeatureTogglesData>();
            mock.Setup(m => m.ConsultaValor("MyFeacture")).Returns("inválid value");

            var config = new FeactureTogglesConfig(mock.Object, false);
            var v = config.IsEnabled(EnumFeactureToggles.MyFeacture);

            mock.Verify(m => m.Altera("MyFeacture", false.ToString()), Times.Once());

            Assert.IsFalse(v);
        }


        [TestMethod]
        public void FeactureToggles_Test_IsEnabled_with_cashe()
        {
            Mock<IFeatureTogglesData> mock = new Mock<IFeatureTogglesData>();
            mock.Setup(m => m.ConsultaValor("MyFeacture")).Returns(true.ToString());

            var config = new FeactureTogglesConfig(mock.Object, true);
            var v = config.IsEnabled(EnumFeactureToggles.MyFeacture);

            Assert.IsTrue(v);

            config.IsEnabled(EnumFeactureToggles.MyFeacture);

            Assert.IsTrue(v);

            mock.Verify(m => m.ConsultaValor("MyFeacture"), Times.Once());
        }
    }
}
