using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureTogglesExemples.Test
{
    [TestClass]
    public class FeatureTogglesSqlData_Test
    {

        private readonly string _cn = @"Data Source=LUCY8\SQLEXPRESS;Initial Catalog=FeatureTogglesSqlData;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";

        [TestMethod]
        public void FeatureTogglesSqlData_Test_Consulta_with_value()
        {
            var data = new FeatureTogglesSqlData(_cn);
            var valor = Guid.NewGuid().ToString();
            data.Insere(valor, true.ToString());

            Assert.AreEqual(true.ToString(), data.ConsultaValor(valor));
        }

        [TestMethod]
        public void FeatureTogglesSqlData_Test_Consulta_without_value()
        {
            var data = new FeatureTogglesSqlData(_cn);
            var valor = Guid.NewGuid().ToString();

            Assert.AreEqual(string.Empty, data.ConsultaValor(valor));
        }

        [TestMethod]
        public void FeatureTogglesSqlData_Test_Altera()
        {
            var data = new FeatureTogglesSqlData(_cn);
            var valor = Guid.NewGuid().ToString();
            data.Insere(valor, false.ToString());

            data.Altera(valor, true.ToString());

            Assert.AreEqual(true.ToString(), data.ConsultaValor(valor));
        }

        [TestMethod]
        public void FeatureTogglesSqlData_Test_Insere()
        {
            var data = new FeatureTogglesSqlData(_cn);
            var valor = Guid.NewGuid().ToString();
            data.Insere(valor, false.ToString());

            Assert.AreEqual(false.ToString(), data.ConsultaValor(valor));
        }
    }
}
