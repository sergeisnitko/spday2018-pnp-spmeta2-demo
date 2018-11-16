using spmeta2.demo.Common;
using SPMeta2.Definitions;
using SPMeta2.Syntax.Default;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ImportItems
    {

        /**
         * 
         * Data feed within the model definition example
         * 
         */

        public static ListModelNode ImportContactsItems(this ListModelNode node)
        {
            var ContactsPath = Path.Combine(ConstsInfo.SystemPath, ConstsInfo.ContactsImportPath);
            return node.ImportItemsFromFile(ContentTypesInfo.Contact().GetContentTypeId(), ContactsPath);
        }

        public static ListModelNode ImportFunctionsItems(this ListModelNode node)
        {
            var FunctionsPath = Path.Combine(ConstsInfo.SystemPath, ConstsInfo.FunctionsImportPath);
            return node.ImportItemsFromFile(ContentTypesInfo.Function().GetContentTypeId(), FunctionsPath);
        }

        public static ListModelNode ImportSubFunctionsItems(this ListModelNode node)
        {
            var SubFunctionsPath = Path.Combine(ConstsInfo.SystemPath, ConstsInfo.SubFunctionsImportPath);
            return node.ImportItemsFromFile(ContentTypesInfo.SubFunction().GetContentTypeId(), SubFunctionsPath);
        }

        public static ListModelNode ImportItemsFromFile(this ListModelNode node, string ContentTypeId, string FilePath)
        {
            var Table = Extentions.ImportFromFile(FilePath);
            foreach (DataRow Row in Table.Rows)
            {
                node.AddRowItem(ContentTypeId, Row);
            }
            return node;
        }

        public static ListModelNode AddRowItem(this ListModelNode node, string ContentTypeId, DataRow Row)
        {
            var ItemDef = DemoItemDefinition(Row["Title"].ToString(),ContentTypeId);
            var Fields = new List<FieldValue>();
            foreach(DataColumn Column in Row.Table.Columns)
            {
                var CurrentValue = Row[Column.ColumnName].ToString();
                if (!String.IsNullOrEmpty(CurrentValue))
                {
                    var CurrentFieldValue = new FieldValue { FieldName = Column.ColumnName, Value = CurrentValue };
                    Fields.Add(CurrentFieldValue);
                }

            }
            var ItemValues = DemoItemValues(Fields);
            return node.AddDemoItem(ItemDef, ItemValues);
        }

        public static ListItemDefinition DemoItemDefinition(string ContentTypeId)
        {
            return DemoItemDefinition("Untitled", ContentTypeId);
        }

        public static ListItemDefinition DemoItemDefinition(string Title, string ContentTypeId)
        {
            return new ListItemDefinition()
            {
                Title = Title,
                ContentTypeId = ContentTypeId,
            };
        }

        public static ListItemFieldValuesDefinition DemoItemValues(List<FieldValue> Values)
        {
            return new ListItemFieldValuesDefinition()
            {
                Values = Values
            };
        }

        public static ListModelNode AddDemoItem(this ListModelNode node, ListItemDefinition DemoItemDefinition, ListItemFieldValuesDefinition DemoItemValues)
        {
            node.AddListItem(DemoItemDefinition, item =>
            {
                item.AddListItemFieldValues(DemoItemValues);
            });
            return node;
        }

    }
}
