using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FeatureTogglesExemples.Test
{
    [TestClass]
    public class FeactureTogglesConfigInstance_Teste
    {
        [TestMethod]
        public void FeactureTogglesConfigInstance_teste_teste()
        {
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
            FeactureTogglesConfigInstance.Instance().Config.IsEnabled(EnumFeactureToggles.MyFeacture);
        }
    }
}
