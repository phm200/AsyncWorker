using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phm.AsyncWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            List<Action> actionsToExecuteAsync = new List<Action>() 
            {
                () =>  System.Console.WriteLine("executed action 1"),
                () =>  System.Console.WriteLine("executed action 2"),
                () =>  System.Console.WriteLine("exception time: {0}", 1/i),
                () =>  System.Console.WriteLine("executed action 4")
            };
            AsyncUtil.ExecuteAsync(actionsToExecuteAsync, HandleException);
            System.Console.ReadLine();
        }

        static void HandleException(Exception e)
        {
            System.Console.WriteLine("exception: {0}", e);
        }
    }
}
