using System;

namespace TreeTask
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates...");

            //BinaryTree<string> bt = new("qwerty");
            BinaryTree<string> bt = new();
            bt.Insert("100000000");
            bt.Insert("200000000");
            bt.Insert("3");
            bt.Insert("4");
            bt.Insert("5");
            bt.Insert("6");
            bt.Insert("70000");

            Console.WriteLine(bt.ToString());

            //bt.Contain(0);

        }
    }
}
