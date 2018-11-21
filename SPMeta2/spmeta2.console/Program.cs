using spmeta2.demo;
using SPExec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var execFunctions = new SPFunctions
            {
                {"deploy",options=>
                    {
                        Deploy.Demo(options.Context);
                        Deploy.ImportDemo(options.Context);
                    }
                },{"demo",options=>
                    {
                        Deploy.ImportDemo(options.Context);
                    }
                },{"retract",options=>
                    {
                        Deploy.DemoRetractLite(options.Context);
                    }
                }
            };


            var forcePropmts = true;

            SharePoint.RunCSOM("--configPath='./configs/private.demo.json' --forcePrompts=" + forcePropmts, execFunctions);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
