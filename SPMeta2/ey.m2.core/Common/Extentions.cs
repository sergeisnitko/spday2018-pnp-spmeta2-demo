using spmeta2.demo.Artefacts;
using Microsoft.SharePoint.Client;
using SPMeta2.Common;
using SPMeta2.CSOM.Standard.Services;
using SPMeta2.Definitions.ContentTypes;
using SPMeta2.Extensions;
using SPMeta2.Services;
using SPMeta2.Syntax.Default;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Common
{
    public static class Extentions
    {

        /**
         * 
         * Frequently used extentions and helpers which are not the part of M2 library
         * 
         */
        public static string GetFileText(string Path)
        {
            var text = "";
            if (System.IO.File.Exists(Path))
            {
                using (TextReader tw = new StreamReader(Path, Encoding.UTF8))
                {
                    text = tw.ReadToEnd();
                    tw.Close();
                }
            }
            return text;
        }

        public static DataTable ImportFromFile(string path)
        {
            var ImportText = Extentions.GetFileText(path);

            var ImportTable = new DataTable();

            var Rows = ImportText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (Rows.Length > 0)
            {
                var Header = Rows[0].Split(new string[] { ConstsInfo.ImportDelimiter }, StringSplitOptions.None);
                for (int i = 0, ilen = Header.Length; i < ilen; i += 1)
                {
                    var ColumnName = Header[i];
                    if (String.IsNullOrEmpty(ColumnName))
                    {
                        ColumnName = "Column_" + i;
                    }
                    ImportTable.Columns.Add(ColumnName);
                }
            }

            if (Rows.Length > 1)
            {
                for (int j = 1, jlen = Rows.Length; j < jlen; j += 1)
                {
                    var Item = Rows[j].Split(new string[] { ConstsInfo.ImportDelimiter }, StringSplitOptions.None);
                    var CurrentRow = ImportTable.NewRow();

                    for (int i = 0, ilen = Item.Length; i < ilen; i += 1)
                    {
                        CurrentRow[i] = Item[i];
                    }
                    ImportTable.Rows.Add(CurrentRow);
                }

            }
            return ImportTable;
        }


        public static ListModelNode AddRemoveStandardContentTypes(this ListModelNode node)
        {
            node
                .AddRemoveContentTypeLinks(new RemoveContentTypeLinksDefinition
                {
                    ContentTypes = new List<ContentTypeLinkValue>
                    {
                        new ContentTypeLinkValue{ ContentTypeName = "Элемент" },
                        new ContentTypeLinkValue{ ContentTypeName = "Item" }
                    }
                })

                ;
            return node;
        }

    }
}
