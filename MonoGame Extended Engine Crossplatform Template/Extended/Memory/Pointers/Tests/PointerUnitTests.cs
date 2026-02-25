using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers.Tests
{
    [TestClass]
    public class PointerUnitTests
    {
        [TestMethod]
        public void Test_PointerReference() {
            TestPointerReference pointerReference = new();
            IPointer<TestPointerReference> pointer = new LoudSafePointer<TestPointerReference>();
            pointerReference.AddPointer(pointer);
            pointerReference.OnDeallocate();
            try
            {
                pointer.Apply(x => { });
                Assert.Fail();
            } catch (NullReferenceException e) { }
        }
    }
}
