using Microsoft.VisualStudio.TestTools.UnitTesting;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using Karoterra.AupDotNet.ExEdit.Effects;

namespace AupDotNetTests.ExEdit.Effects
{
    [TestClass]
    public class SharpenEffectTest
    {
        [TestMethod]
        public void Test_Read()
        {
            AviUtlProject aup = new AviUtlProject(@"TestData\Exedit\EffectSet01.aup");
            ExEditProject exedit = ExeditTestUtil.GetExEdit(aup);

            var obj = ExeditTestUtil.GetObject(exedit, 0, 0, 15);
            var effect = obj.Effects[4] as SharpenEffect;
            Assert.IsNotNull(effect);
            Assert.AreEqual(500, effect.Intensity.Current, "Intensity.Current");
            Assert.AreEqual(5, effect.Size.Current, "Size.Current");
        }
    }
}
