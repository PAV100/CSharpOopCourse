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
            bt.Insert("1");
            bt.Insert("2200");
            bt.Insert("24000");
            bt.Insert("330000");
            bt.Insert("3600000");
            bt.Insert("45000000");
            bt.Insert("470000000");

            Console.WriteLine(bt.ToString());

            //bt.Contain(0);

        }
    }
}
