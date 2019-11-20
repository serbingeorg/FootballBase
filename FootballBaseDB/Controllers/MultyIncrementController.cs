using FootballBaseDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FootballBaseDB.Controllers
{
    public class MultyIncrementController : ApiController
    {
        MultyIncrementService multyIncrementService = new MultyIncrementService();
       
        public MultyIncrementController ()
        {
            List<int> list = new List<int>();
            list = Enumerable.Range(1, 1000).ToList();
            list.ForEach(x=>++x);

            ParallelLoopResult result = Parallel.ForEach<int>(list,x=>++x);

        }
      
        //инкрементировать List из 1000 элементов паралельно
        // с максимальным количеством потоков
    }
} 
