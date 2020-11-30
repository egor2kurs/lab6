﻿using System;
using System.Collections.Generic;
using System.Text;

namespace laba6_9
{

    partial class Product
    {
        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return ((this.OrganizationName == product.OrganizationName) && (this.ProductName == product.ProductName));
        }

        public override int GetHashCode()
        {
            return this.OrganizationName.GetHashCode() + this.ProductName.GetHashCode();
        }

        public override string ToString()
        {
            return this.OrganizationName + " " + this.ProductName;
        }
    }

    enum list//перечисление
    {
        one = 1,
        two,
        three,
        nine = 9,
        ten
    }

    public class Gift//контейнер
    {
        public Base[] elems;
        public int count = 0;
        public int size;
        list list = new list();

        public Gift()
        {
            size = 100;
            elems = new Base[100];
        }

        public Gift(int c)
        {
            size = c;
            elems = new Base[c];
        }

        public bool isFull()
        {
            return (count == size);
        }

        public bool isEmpty()
        {
            return (count == 0);
        }

        public void Add(Base el)
        {
            if (isFull())
                return;
            elems[count++] = el;
        }

        public void Del(Base el)

        {
            int num = 0;
            if (isEmpty())
                return;
            for (int i = 0; i < count; i++)
            {
                if (elems[i] == el)
                    num = i;
            }
            for (int i = num; i < count; i++)
            {
                elems[i] = elems[i + 1];
            }
            count--;
        }

        public void show()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(elems[i].ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public abstract class Base
    {
        public struct Info//структура
        {
            public int price;
            public int mas;
        }
        public Info info = new Info();
    }

    public static class controller//статический со статическими методами,чтобы мы смогли вызывать их ранее созданными объектами 
    {
        public static void sort(Gift gift)
        {
            Base elem;
            for (int i = 0; i < gift.count - 1; i++)
            {
                for (int j = 0; j < gift.count - i - 1; j++)
                {
                    if (gift.elems[j].info.mas < gift.elems[j + 1].info.mas)
                    {
                        elem = gift.elems[j];
                        gift.elems[j] = gift.elems[j + 1];
                        gift.elems[j + 1] = elem;
                    }
                }
            }
        }

        public static void minmas(Gift gift)
        {
            Base elem;
            elem = gift.elems[0];
            int massa = 99999;
            for (int i = 0; i < gift.count; i++)
            {
                if (gift.elems[i].info.mas < massa)
                {
                    massa = gift.elems[i].info.mas;
                    elem = gift.elems[i];

                }

            }
            Console.Write(elem);
            Console.WriteLine(" " + massa);
            Console.ReadKey();
        }

        public static void show(Gift gift)
        {
            string[] products = new string[6];
            int[] count = new int[6];
            int pos = 0;
            bool b = false;
            for (int j = 0; j < gift.count; j++)
            {
                for (int i = 0; i < pos; i++)
                {
                    if (products[i] == (gift.elems[j].GetType()).Name)
                    {
                        b = true;
                        count[i]++;
                        break;
                    }
                }
                if (!b)
                {
                    products[pos] = gift.elems[j].GetType().Name;
                    count[pos]++;
                    pos++;
                }
                b = false;
            }

            Console.WriteLine("Lab elements:");
            for (int i = 0; i < pos; i++)
            {
                Console.WriteLine($"{products[i]} - {count[i]}");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
