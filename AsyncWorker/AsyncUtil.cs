using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Phm.AsyncWorker
{
    public static class AsyncUtil
    {
        public static void ExecuteAsync(List<Action> actions, Action<Exception> exceptionHandler)
        {
            foreach (var action in actions)
            {
                var actionToExecute = action;
                ThreadPool.QueueUserWorkItem(state =>
                {
                    try
                    {
                        actionToExecute();
                    }
                    catch (Exception e)
                    {
                        exceptionHandler(e);
                    }
                }, null);
            }
        }
    }
}
