using NorthwindConsoleApplication.Data;
using NorthwindConsoleApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsoleApplication
{

    class Program
    {
        private static CustomerManager customerManager;
        private static ProductManager productManager;
        private static OrderManager orderManager;

        static void Main(string[] args)
        {            
            Console.WriteLine("Hello Worlds!!!");
            Console.WriteLine("Welcome to NorthWind e-Commerce");
            Console.WriteLine("Enter 1 for Customers \nEnter 2 to Get Customers \nEnter 3 to Get Customer by id\nEnter 4 to add a product\nEnter 5 to Find an Order");

            string input = Console.ReadLine();

            if (input != null)
            {
                input = input.Trim();
                if (input == "1")
                {
                    GetCustomers("Al");
                }
                
                else if (input == "4")
                {
                    EnterProduct();
                }
                else if(input == "5")
                {
                    FindOrder();
                }
            }            
            Console.ReadKey();
           
        }

        #region METHODS
        private static void GetCustomers(string id = null)
        {
            customerManager = new CustomerManager();
            List<Customer> customers = null;
            if (string.IsNullOrEmpty(id))
            {
                customers = customerManager.GetCustomers();
            }
            else
            {
                customers = customerManager.SearchCustomerById(id);
            }
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID} {customer.ContactName} {customer.Phone}\n");
            }


        }

        private static void GetCustomer(string id)
        {
            var customer = customerManager.GetCustomerById(id);
            if(customer != null)
            {
                Console.WriteLine($"{customer.CustomerID} {customer.ContactName} {customer.Phone}");
            }

            else
            {
                Console.WriteLine($"Cannot find customer with {id} as an id");
            }
        }

        private static void EnterProduct()
        {
            Console.WriteLine("Enter the Product Name");
            var productName = Console.ReadLine();
                       
            Console.WriteLine("Enter the SupplierId:");
            int supplierId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the CategoryId:");
            int categoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the QuantityPerUnit:");
            string qtyPerUnit = Console.ReadLine();

            Console.WriteLine("Enter the Unit Price:");
            decimal unitPrice = decimal.Parse(Console.ReadLine());

            Product product = new Product()
            {
                ProductName = productName,
                SupplierID = supplierId,
                CategoryID = categoryId,
                QuantityPerUnit = qtyPerUnit,
                UnitPrice = unitPrice,
                Discontinued = false
                
            };

            productManager = new ProductManager();
            var productAddSuccess =  productManager.AddProduct(product);
            if (productAddSuccess > 0)
            {
                Console.WriteLine($"You have successfully added a new product. Product Id is:{product.ProductID}");

            }
            else
            {
                Console.WriteLine("\aProduct Addition Failed!!!");
            }
        }

        private static void FindOrder()
        {
            orderManager = new OrderManager();
            Console.WriteLine("Enter OrderId to search for");
            var orderId = (Console.ReadLine());
            var foundOrder = orderManager.GetOrderById(int.Parse(orderId));
            int count = 1;
            decimal total = 0;
            
            
            Console.WriteLine($"\n\nHere are the details of Order {orderId}\n");
            Console.WriteLine("Order Id\tCustomer Contact Name\tEmployee Name");
            Console.WriteLine($"{foundOrder.OrderID} {foundOrder.Customer.ContactName} {foundOrder.Employee.FirstName}");
            Console.WriteLine(" Product Name\tUnit Price\tQuantity\tTotal");
            foreach(var detail in foundOrder.Order_Details)
            {
                Console.WriteLine($"{count}. {detail.Product.ProductName} {detail.UnitPrice} {detail.Quantity} {detail.UnitPrice * detail.Quantity}");
                total += detail.Quantity * detail.UnitPrice;
                count++;
            }
            Console.WriteLine($"\nTotal is {total}");

        }
        #endregion
    }
}
