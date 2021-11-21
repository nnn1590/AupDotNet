using Microsoft.VisualStudio.TestTools.UnitTesting;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using Karoterra.AupDotNet.ExEdit.Effects;

namespace AupDotNetTests.ExEdit.Effects
{
    [TestClass]
    public class DiffuseEffectTest
    {
        [TestMethod]
        public void Test_Read()
        {
            AviUtlProject aup = new AviUtlProject(@"TestData\Exedit\EffectSet01.aup");
            ExEditProject exedit = ExeditTestUtil.GetExEdit(aup);

            var obj = ExeditTestUtil.GetObject(exedit, 0, 0, 5);
            var effect = obj.Effects[5] as DiffuseEffect;
            Assert.IsNotNull(effect);
            Assert.AreEqual(8, effect.Intensity.Current, "Intensity.Current");
            Assert.AreEqual(9, effect.Diffusion.Current, "Diffusion.Current");
            Assert.AreEqual(false, effect.FixSize, "FixSize");

            effect = obj.Effects[6] as DiffuseEffect;
            Assert.IsNotNull(effect);
            Assert.AreEqual(true, effect.FixSize, "FixSize");
        }
    }
}
