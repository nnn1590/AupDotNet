using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using Karoterra.AupDotNet.ExEdit.Effects;
using Karoterra.AupDotNet.Extensions;

namespace AupDotNetTests.ExEdit.Effects
{
    [TestClass]
    public class ScriptEffectTest
    {
        [TestMethod]
        public void Test_Read()
        {
            AviUtlProject aup = new AviUtlProject($"TestData{Path.DirectorySeparatorChar}Exedit{Path.DirectorySeparatorChar}EffectSet01.aup");
            ExEditProject exedit = ExeditTestUtil.GetExEdit(aup);

            var obj = ExeditTestUtil.GetObject(exedit, 0, 0, 45);
            var effect = obj.Effects[5] as ScriptEffect;
            Assert.IsNotNull(effect);
            Assert.AreEqual("a = 123\r\nlocal b = \"あいうえお\"", effect.Text, "Text");
        }

        public void CheckDumpExtData(CustomEffect custom, string message)
        {
            var script = new ScriptEffect(custom.Trackbars.ToArray(), custom.Checkboxes, custom.Data);
            var data = script.DumpExtData();
            int len = script.Text.GetUTF16ByteCount() + 1;
            Assert.IsTrue(data.Take(len).SequenceEqual(custom.Data.Take(len)), message);
        }

        [TestMethod]
        public void Test_DumpExtData()
        {
            AviUtlProject aup = new AviUtlProject($"TestData{Path.DirectorySeparatorChar}Exedit{Path.DirectorySeparatorChar}EffectSet01.aup");
            ExEditProject exedit = ExeditTestUtil.GetExEdit(aup, new CustomEffectFactory());

            var obj = ExeditTestUtil.GetObject(exedit, 0, 0, 45);
            CheckDumpExtData(obj.Effects[5] as CustomEffect, "1");
        }
    }
}
