using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Order4
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("初始化订单管理系统");
            OrderService oneService = new OrderService();
            while (true)
            {
                Console.WriteLine("1:添加订单，2：查找订单，3：修改订单，4：删除订单 5：按金额排序输出订单,6序列化，7反序列化");
                int lookIndex = Convert.ToInt16(Console.ReadLine());
                switch (lookIndex)
                {
                    case 1:
                        Console.WriteLine("请输入新的订单编号，名字,客户名称以及金额");
                        string inid = Console.ReadLine();
                        string inname = Console.ReadLine();
                        string inclient = Console.ReadLine();
                        double money = Convert.ToDouble(Console.ReadLine());
                        oneService.AddOrder(inid, inname, inclient, money);
                        break;
                    case 2:
                        Console.WriteLine("1:按编号查询，2：按名字查询，3：按客户名称查询");
                        int lookIndex2 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("输入查找数据");
                        string lookContent = Console.ReadLine();
                        oneService.LookForOrder(lookIndex2, lookContent);
                        break;
                    case 3:
                        Console.WriteLine("请输入要修改订单信息");
                        Console.WriteLine("1:按编号查询，2：按名字查询，3：按客户名称查询");
                        int lookIndex3 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("输入查找数据");
                        string lookContent3 = Console.ReadLine();
                        IEnumerable<Order> LookList3 = oneService.LookForOrder(lookIndex3, lookContent3);
                        oneService.ModifyOrder(LookList3);
                        break;
                    case 4:
                        Console.WriteLine("请输入要删除订单信息");
                        Console.WriteLine("1:按编号查询，2：按名字查询，3：按客户名称查询");
                        int lookIndex4 = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("输入查找数据");
                        string lookContent4 = Console.ReadLine();
                        IEnumerable<Order> LookLis4 = oneService.LookForOrder(lookIndex4, lookContent4);
                        oneService.Delete(LookLis4);
                        break;
                    case 5:
                        oneService.SortOnMoney();
                        break;
                    case 6:
                        oneService.export();
                        break;
                    case 7:
                        oneService.import();
                        break;
                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }

        }
    }

    [Serializable]
    public class Order : IComparable
    {
        public string id;
        public string name;
        public string client;
        public double money;
        public Order() { }
        public Order(string inid, string inname, string inclient, double money)
        {
            this.id = inid;
            this.name = inname;
            this.client = inclient;
            this.money = money;
        }
        public void print()
        {
            Console.WriteLine("订单编号:" + this.id);
            Console.WriteLine("订单名字:" + this.name);
            Console.WriteLine("客户名称:" + this.client);
            Console.WriteLine("订单金额:" + this.money);
        }
        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order m = (Order)obj;
                if (m.id == id && m.name == name && m.client == client)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(id);
        }

        public override string ToString()
        {
            return id + " " + name + " " + client + " " + money;
        }
        int IComparable.CompareTo(object obj)
        {
            Order m = (Order)obj;
            return Convert.ToInt32(id) - Convert.ToInt32(m.id);
        }

    }

    public class OrderService
    {
        List<Order> Orderlist = new List<Order>();
        IEnumerable<Order> found = new List<Order>();
        public void AddOrder(string inid, string inname, string inclient, double money)
        {
            Order newOrder = new Order(inid, inname, inclient, money);
            foreach (Order old in Orderlist)
            {
                if (old.Equals(newOrder))
                {
                    Console.WriteLine("订单重复");
                    return;
                }
            }
            Orderlist.Add(newOrder);
            Orderlist.Sort();
        }
        public void SortOnMoney()
        {
            Orderlist.Sort((o1, o2) => Convert.ToInt32(o1.money - o2.money));
            foreach (Order item in Orderlist)
            {
                Console.WriteLine(item);
            }
        }
        public IEnumerable<Order> LookForOrder(int lookIndex, string lookContent)
        {
            IEnumerable<Order> found = new List<Order>();
            try
            {
                switch (lookIndex)
                {
                    case 1:
                        found = from order in Orderlist where order.id == lookContent select order;
                        break;
                    case 2:
                        found = from order in Orderlist where order.name == lookContent select order;
                        break;
                    case 3:
                        found = from order in Orderlist where order.client == lookContent select order;
                        break;
                    default:
                        Console.WriteLine("输入无效！");
                        break;
                }
                foreach (Order s in found)
                {
                    Console.WriteLine(s);
                }
                return found;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("无订单！" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("错误！" + e.Message);
                return null;
            }

        }

        public void ModifyOrder(IEnumerable<Order> LookList)
        {
            try
            {
                foreach (Order order in LookList)
                {
                    order.print();
                    Console.WriteLine("1:修改编号，2：修改名字，3：修改客户名");
                    int lookIndex = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("输入修改后的值");
                    string modi = Console.ReadLine();
                    switch (lookIndex)
                    {
                        case 1:
                            order.id = modi;
                            break;
                        case 2:
                            order.name = modi;
                            break;
                        case 3:
                            order.client = modi;
                            break;
                        default:
                            Console.WriteLine("输入无效！");
                            break;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("未找到数据！" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("错误！" + e.Message);
            }
        }

        public void Delete(IEnumerable<Order> LookList)
        {
            try
            {
                foreach (Order order in LookList)
                {
                    Orderlist.Remove(order);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("未找到数据！" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("错误！" + e.Message);
            }

        }


        public void export()
        {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream("orderlist.xml", FileMode.Create))
            {
                binary.Serialize(fs, Orderlist);
            }

        }

        public void import()
        {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream("orderlist.xml", FileMode.Open))
            {
                Orderlist = (List<Order>)binary.Deserialize(fs);

            }

        }

    }
}