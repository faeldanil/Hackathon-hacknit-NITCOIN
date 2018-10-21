using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreClass.Web.Models.Incentivos;
using System;

namespace ScoreClass.Testes
{
    [TestClass]
    public class TestandoVoucher
	{
        [TestMethod]
        public void TestMethod1()
        {
			var voucher = new Voucher();
			Assert.IsNotNull(voucher);
			Assert.IsNotNull(voucher.Codigo);
			Assert.IsFalse(String.IsNullOrWhiteSpace(voucher.Codigo));
		}
    }
}
