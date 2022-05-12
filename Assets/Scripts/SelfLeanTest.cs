using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfLearn
{
    public class SelfLeanTest : MonoBehaviour
    {
        //���緢��ֽ
        private void Start()
        {
            var publisher = new Publisher("������x");
            var p1 = new Person("a");
            var p2 = new Person("b");
            var p3 = new Person("c");
            publisher.persons.Add(p1);
            publisher.persons.Add(p2);
            publisher.persons.Add(p3);
            publisher.SendNewspaper(new Newspaper() { Title = "������x�ı���", Content = "����xxx" });
        }
    }
    interface ISubscriber//�ӿ�,������󣬶�̬
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
            Console.WriteLine($"{this.Name}���ڶ���ֽ�������ǣ�{this.newspaper.Title}," +
                $"�����ǣ�{ this.newspaper.Content}");
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
            Console.WriteLine($"{this.Name}���ڶ���ֽ�������ǣ�{this.newspaper.Title}," +
                $"�����ǣ�{ this.newspaper.Content}");
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
            openWith.Add("txt", "notepad.exe");//���Ԫ��
            //ȡֵ
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            //����ֵ
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            
            //����key
            foreach (string key in openWith.Keys)
            {
                Console.WriteLine("Key = {0}", key);
            }
            //����value
            foreach (string value in openWith.Values)
            {
                Console.WriteLine("value = {0}", value);
            }
            //�����ֵ�
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            // ��Ӵ��ڵ�Ԫ��
    try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }
            //ɾ��Ԫ��
            openWith.Remove("doc");
            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }

}
