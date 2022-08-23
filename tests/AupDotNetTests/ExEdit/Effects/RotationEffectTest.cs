using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using Karoterra.AupDotNet.ExEdit.Effects;

namespace AupDotNetTests.ExEdit.Effects
{
    [TestClass]
    public class RotationEffectTest
    {
        [TestMethod]
        public void Test_Read()
        {
            AviUtlProject aup = new AviUtlProject($"TestData{Path.DirectorySeparatorChar}Exedit{Path.DirectorySeparatorChar}EffectSet01.aup");
            ExEditProject exedit = ExeditTestUtil.GetExEdit(aup);

            var obj = ExeditTestUtil.GetObject(exedit, 0, 0, 25);
            var effect = obj.Effects[6] as RotationEffect;
            Assert.IsNotNull(effect);
            Assert.AreEqual(20, effect.X.Current, "X.Current");
            Assert.AreEqual(30, effect.Y.Current, "Y.Current");
            Assert.AreEqual(40, effect.Z.Current, "Z.Current");
        }
    }
}
