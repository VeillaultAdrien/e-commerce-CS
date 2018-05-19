using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.e_commerce;

namespace Modele.Console.e_commerce
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            c.Clients.ToList();
        }
    }
}
