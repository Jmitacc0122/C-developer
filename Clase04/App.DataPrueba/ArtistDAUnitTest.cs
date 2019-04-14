using System;
using App.Data;
using App.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.DataPrueba
{
    [TestClass]
    public class ArtistDAUnitTest
    {
        [TestMethod]
        public void Count()
        {
            var DA = new ArtistDA();
            Assert.IsTrue(DA.GetCount() > 0);
        }
    }
}
