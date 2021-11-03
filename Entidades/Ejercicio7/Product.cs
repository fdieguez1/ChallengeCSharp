using System.Collections.Generic;
using System.Text;

namespace Entidades.Ejercicio7
{
    public class Product
    {
        int id;
        string description;
        double price;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        static List<Product> productList;
        public static List<Product> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
            }
        }
        public Product this[int id]
        {
            get
            {
                if (id > 0)
                {
                    foreach (Product prod in ProductList)
                    {
                        if (prod.id == id)
                        {
                            return prod;
                        }
                    }
                }
                return null;
            }
        }
        public Product()
        {
        }
        public Product(int id, string description, double price) : this()
        {
            this.id = id;
            this.description = description;
            this.price = price;
        }
        public static bool operator ==(Product product1, Product product2) => product1.id == product2.id;
        public static bool operator !=(Product product1, Product product2) => !(product1 == product2);

        public override bool Equals(object obj)
        {
            if (typeof(Product) == obj.GetType())
            {
                return (Product)this == (Product)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"--Product--\nId: {id}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Price: {Price}");
            return sb.ToString();
        }
    }



}
