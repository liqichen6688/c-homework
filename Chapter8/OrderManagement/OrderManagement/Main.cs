using AppKit;
using System;
using Foundation;

namespace OrderManagement
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }

    [Register("OrderModel")]
    public class OrderModel : NSObject
    {
        private string _id = "";
        private string _name = "";
        private int _values = 0;
        private bool _isManager = false;
        private NSMutableArray _orders = new NSMutableArray();

        [Export("ID")]
        public string ID
        {
            get { return _id; }
            set
            {
                WillChangeValue("ID");
                _id = value;
                DidChangeValue("ID");
            }
        }

        [Export("Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                WillChangeValue("Name");
                _name = value;
                DidChangeValue("Name");
            }
        }

        [Export("Values")]
        public int Values
        {
            get { return _values; }
            set
            {
                WillChangeValue("Values");
                _values = value;
                DidChangeValue("Values");
            }
        }

        [Export("isManager")]
        public bool isManager
        {
            get { return _isManager; }
            set
            {
                WillChangeValue("isManager");
                _isManager = value;
                DidChangeValue("isManager");
            }
        }

        [Export("isCommody")]
        public bool isCommody
        {
            get { return (NumberOfCommody == 0); }
        }

        [Export("orderModelArray")]
        public NSArray Orders
        {
            get { return _orders; }
        }

        [Export("NumberOfCommody")]
        public nint NumberOfCommody
        {
            get { return (nint)_orders.Count; }
        }





        public OrderModel()
        {
        }

        public OrderModel(string id, string name, int value)
        {
            this.ID = id;
            this.Name = name;
            this.Values = value;
        }

        public OrderModel(string id, string name, int value, bool manager)
        {
            this.ID = id;
            this.Name = name;
            this.Values = value;
            this.isManager = manager;
        }



        [Export("addObject:")]
        public void AddOrder(OrderModel order)
        {
            WillChangeValue("orderModelArray");
            isManager = true;
            _orders.Add(order);
            DidChangeValue("orderModelArray");
        }

        [Export("insertObject:inOrderModelArrayAtIndex:")]
        public void InsertPerson(OrderModel order, nint index)
        {
            WillChangeValue("orderModelArray");
            _orders.Insert(order, index);
            DidChangeValue("orderModelArray");
        }

        [Export("removeObjectFromOrderModelArrayAtIndex:")]
        public void RemovePerson(nint index)
        {
            WillChangeValue("orderModelArray");
            _orders.RemoveObject(index);
            DidChangeValue("orderModelArray");
        }

        [Export("setOrdernModelArray:")]
        public void SetPeople(NSMutableArray array)
        {
            WillChangeValue("orderModelArray");
            _orders = array;
            DidChangeValue("orderModelArray");
        }
    }
}
