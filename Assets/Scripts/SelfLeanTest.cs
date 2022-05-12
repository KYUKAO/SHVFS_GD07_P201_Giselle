using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfLearn
{
    public class SelfLeanTest : MonoBehaviour
    {
        //报社发报纸
        private void Start()
        {
            var publisher = new Publisher("出版社x");
            var p1 = new Person("a");
            var p2 = new Person("b");
            var p3 = new Person("c");
            publisher.persons.Add(p1);
            publisher.persons.Add(p2);
            publisher.persons.Add(p3);
            publisher.SendNewspaper(new Newspaper() { Title = "出版社x的标题", Content = "内容xxx" });
        }
    }
    interface ISubscriber//接口,面向对象，多态
    {
        void SetNewspaper(Newspaper news);
        void ReadNewspaper();
    }
   class Company:ISubscriber
    {
        public string Name { get; set; }
        public Newspaper newspaper { get; set; }
        public Company(string name)
        {
            this.Name = name;
        }
        public void SetNewspaper(Newspaper news)
        {
            this.newspaper = news;
        }
        public void ReadNewspaper()
        {
            Console.WriteLine($"{this.Name}正在读报纸，标题是：{this.newspaper.Title}," +
                $"内容是：{ this.newspaper.Content}");
        }
    }
    class Person : ISubscriber
    {
        public string Name { get; set; }
        public Newspaper newspaper { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
        public void SetNewspaper(Newspaper news)
        {
            this.newspaper = news;
        }
        public void ReadNewspaper()
        {
            Console.WriteLine($"{this.Name}正在读报纸，标题是：{this.newspaper.Title}," +
                $"内容是：{ this.newspaper.Content}");
        }
    }
    class Newspaper
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
    class Publisher
    {
        public string Name { get; set; }
        public Publisher(string name)
        {
            this.Name = name;
        }
        public List<ISubscriber> persons = new List<ISubscriber>();
        public void SendNewspaper(Newspaper newspaper)
        {
            persons.ForEach(person=>person.SetNewspaper(newspaper));
            
        }
    }
    class SelfLearn:MonoBehaviour
    {
        Dictionary<string,string>openWith=new Dictionary<string, string>();
        private void Start()
        {
            openWith.Add("txt", "notepad.exe");//添加元素
            //取值
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            //更改值
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            
            //遍历key
            foreach (string key in openWith.Keys)
            {
                Console.WriteLine("Key = {0}", key);
            }
            //遍历value
            foreach (string value in openWith.Values)
            {
                Console.WriteLine("value = {0}", value);
            }
            //遍历字典
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            // 添加存在的元素
    try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }
            //删除元素
            openWith.Remove("doc");
            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }

}
