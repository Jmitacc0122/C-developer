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

        [TestMethod]
        public void GetAll()
        {
            var DA = new ArtistDA();
            var listado = DA.GetAll("AEROSMITH");

            Assert.IsTrue(listado.Count  > 0);
        }

        [TestMethod]
        public void GetAllSP()
        {
            var DA = new ArtistDA();
            var listado = DA.GetAllSP("AEROSMITH");

            Assert.IsTrue(listado.Count > 0);
        }
        //[TestMethod]
        //public void Get()
        //{
        //    var DA = new ArtistDA();
        //    var entity = DA.Get(1);

        //    Assert.IsTrue(entity.ArtisId > 0);
        //}
    }
}
