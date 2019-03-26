using System;
using System.Collections.Generic;

namespace OrderManagement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("初始化订单管理系统");
            OrderService oneService = new OrderService();
            while (true)
            {
                Console.WriteLine("1:添加订单，2：查找订单，3：修改订单，4：删除订单 5：按金额排序输出订单");
                int lookIndex = Convert.ToInt16(Console.ReadLine());
                switch (lookIndex)
                {
                    case 1:
                        oneService.AddOrder();
                        break;
                    case 2:
                        oneService.LookForOrder();
                        break;
                    case 3:
                        oneService.ModifyOrder();
                        break;
                    case 4:
                        oneService.Delete();
                        break;
                    case 5:
                        oneService.SortOnMoney();
                        break;
                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }

        }
    }


    class Order:IComparable
    {
        public string id;
        public string name;
        public string client;
        public double money;
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

    class OrderService
    {
        List<Order> Orderlist = new List<Order>();
        public void AddOrder()
        {
            Console.WriteLine("请输入新的订单编号，名字,客户名称以及金额");
            string inid = Console.ReadLine();
            string inname = Console.ReadLine();
            string inclient = Console.ReadLine();
            double money = Convert.ToDouble(Console.ReadLine());
            Order newOrder = new Order(inid, inname, inclient, money);
            foreach (Order old in Orderlist)
            {
                if (old.Equals(newOrder)){
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
            foreach(Order item in Orderlist)
            {
                Console.WriteLine(item);
            }
        }

        public List<Order> LookForOrder()
        {
            Console.WriteLine("1:按编号查询，2：按名字查询，3：按客户名称查询");
            int lookIndex = Convert.ToInt16(Console.ReadLine());
            List<Order> LookList = new List<Order>();
            Console.WriteLine("输入查找数据");
            string lookContent = Console.ReadLine();
            try
            {
                switch (lookIndex)
                {
                    case 1:
                        foreach (Order order in Orderlist)
                        {
                            if (order.id == lookContent)
                            {
                                order.print();
                                LookList.Add(order);
                            }
                        }
                        break;
                    case 2:
                        foreach (Order order in Orderlist)
                        {
                            if (order.name == lookContent)
                            {
                                order.print();
                                LookList.Add(order);
                            }
                        }
                        break;
                    case 3:
                        foreach (Order order in Orderlist)
                        {
                            if (order.client == lookContent)
                            {
                                order.print();
                                LookList.Add(order);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("输入无效！");
                        break;
                }
                return LookList;
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

        public void ModifyOrder()
        {
            Console.WriteLine("请输入要修改订单信息");
            List<Order> LookList = this.LookForOrder();
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

        public void Delete()
        {
            Console.WriteLine("请输入要删除订单信息");
            List<Order> LookList = this.LookForOrder();
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
    }
}