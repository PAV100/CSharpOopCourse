using System;

namespace TreeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates...");

            //BinaryTree<string> bt = new("qwerty");
            BinaryTree<string> bt = new();
            bt.Insert("qwerty");
            bt.Insert("asddf");
            bt.Insert("zxcvb");

            Console.WriteLine(bt.ToString());

        }
    }
}
