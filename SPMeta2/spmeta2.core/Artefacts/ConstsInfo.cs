using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    /**
     * 
     * Class with constants example 
     * The constants can bring some dynamic to provisioning workflow
     * 
     */
    public class ConstsInfo
    {
        public static string DefaultGroupName = "Demos M2";
        public static string DynamicAssets = @"DynamicAssets";
        public static string SystemPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string ApplyToPath = @"DynamicAssets\Demos\M2.Demo\spmeta2.artefacts.js";

        public static string ImportDelimiter = ";";
        public static string ContactsImportPath = @"DemoData\Contacts.csv";
        public static string FunctionsImportPath = @"DemoData\Functions.csv";
        public static string SubFunctionsImportPath = @"DemoData\SubFunctions.csv";
    }
}
