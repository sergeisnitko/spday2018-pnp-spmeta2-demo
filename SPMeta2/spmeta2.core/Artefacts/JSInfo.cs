using spmeta2.demo.Common;
using SPF.M2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class JSInfo
    {

        /**
         * 
         * Model definition to JS example
         * For the cases when artifacts names should be received in the JS on client side
         * This is completely optional and shows a concept
         * 
         */
        public static void FillApplytoFile()
        {
            var SettingsArr = new string[]
            {
                "var spmeta2 = spmeta2 || {};",
                "spmeta2.Fields = spmeta2.Fields || {};",
                "spmeta2.Lists = spmeta2.Lists || {};",

                "spmeta2.Fields.Email = \""+FieldsInfo.Email().InternalName+"\";",
                "spmeta2.Fields.PhoneNumber = \""+FieldsInfo.PhoneNumber().InternalName+"\";",
                "spmeta2.Fields.EmployeesCount = \""+FieldsInfo.EmployeesCount().InternalName+"\";",
                "spmeta2.Fields.Owner = \""+FieldsInfo.Owner().InternalName+"\";",
                "spmeta2.Fields.Function = \""+FieldsInfo.Function().InternalName+"\";",

                "spmeta2.Lists.Contacts = \""+ListsInfo.Contacts().CustomUrl+"\";",
                "spmeta2.Lists.Functions = \""+ListsInfo.Functions().CustomUrl+"\";",
                "spmeta2.Lists.SubFunctions = \""+ListsInfo.SubFunctions().CustomUrl+"\";"

            };
            SPF.M2.Extentions.GenerateJavascriptFile(Path.Combine(ConstsInfo.SystemPath, ConstsInfo.ApplyToPath), SettingsArr);
        }
    }
}
