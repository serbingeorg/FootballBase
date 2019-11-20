using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;

namespace FootballBaseDB.Services
{
    public class MultyIncrementService
    {
        public void IncrementService()
        {
            List<int> list = new List<int>();
            list = Enumerable.Range(1, 1000).ToList();
            list.ForEach(x => ++x);

            ParallelLoopResult result = Parallel.
                ForEach<int>(list, x => ++x);

        }





    }
}