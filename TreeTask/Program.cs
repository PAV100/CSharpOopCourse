using System;

namespace TreeTask
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates...");

            BinaryTree<int> bt = new(500);

            Random randomNumberGenerator = new Random();

            for (int i = 1; i < 63; i++)
            {
                int randomNumber = randomNumberGenerator.Next(0, 1000 + 1);
                bt.Insert(randomNumber);
            }

            /*bt.Insert(240);
            bt.Insert(230);
            bt.Insert(220);
            bt.Insert(250);
            bt.Insert(260);
            bt.Insert(270);
            bt.Insert(280);
            bt.Insert(290);*/

            /*bt.Insert(13);
            bt.Insert(40);
            bt.Insert(2);
            bt.Insert(53);
            bt.Insert(70);
            bt.Insert(8);
            bt.Insert(181);
            bt.Insert(327);
            bt.Insert(422);
            bt.Insert(654);
            bt.Insert(718);
            bt.Insert(113);
            bt.Insert(156);
            bt.Insert(413);*/

            Console.WriteLine(bt.ToString());

            //Console.WriteLine(bt.GetTreeHeight());

            //Console.WriteLine("  123".IndexOf("123"));


        }
    }
}
