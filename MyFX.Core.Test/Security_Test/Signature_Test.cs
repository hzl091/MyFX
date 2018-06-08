using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFX.Core.Test.Security_Test
{
    [TestClass]
    public class Signature_Test
    {
        [TestMethod]
        public void Sign_Test()
        {
            string rs = MyFX.Core.Security.Signature.Sign(
                "10010|3c895bff2b524569aecdcdfgd3343434|20180604192327|1|30", "19567b5ae0134267a38931a0089b3196");
            Console.WriteLine(rs);
        }

        [TestMethod]
        public void Verify_Test()
        {
            bool isSuccess = MyFX.Core.Security.Signature.Verify("10010|3c895bff2b524569aecdcdfgd3343434|20180604192327|1|30",
                "19567b5ae0134267a38931a0089b3196", "C39232599A436ADA9A4813E7F4FB7644");
           Console.WriteLine(isSuccess);
         Assert.IsTrue(isSuccess);
        }
    }
}
