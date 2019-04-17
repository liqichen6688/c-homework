using NUnit.Framework;
using System;
using Order4;

namespace Order4Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase1()
        {
            OrderService oneService = new OrderService();
            oneService.AddOrder();
        }

        public void TestCase2()
        {
            OrderService oneService = new OrderService();
            oneService.SortOnMoney();
        }

        public void TestCase3()
        {
            OrderService oneService = new OrderService();
            oneService.Delete();
        }

    }

}
