using FlowerShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ConsoleApi
{
    public class Engine
    {
        private MainService main;
        private OutputService output;
        public Engine()
        {
            main = new MainService();
            output = new OutputService();
        }


    }
}
