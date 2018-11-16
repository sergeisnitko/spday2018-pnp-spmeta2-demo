using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ViewsInfo
    {

        /**
         * 
         * Views model definition
         * 
         */
        public static ListViewDefinition ContactsView()
        {
            return new ListViewDefinition
            {
                Title = "All Items",
                Url = "AllItems.aspx",
                RowLimit = 25,
                Query = "<OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy>",
                IsDefault = true,
                Fields = new Collection<string>
                    {
                        BuiltInInternalFieldNames.Edit,
                        BuiltInInternalFieldNames.ID,
                        BuiltInInternalFieldNames.LinkTitle,
                        FieldsInfo.Email().InternalName,
                        FieldsInfo.PhoneNumber().InternalName,
                        BuiltInInternalFieldNames.Editor,
                        BuiltInInternalFieldNames.Modified
                    },
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "All Items" },
                    new ValueForUICulture { CultureId = 1049, Value = "Все элементы" }
                }
            };
        }


        public static ListViewDefinition FunctionsView()
        {
            return new ListViewDefinition
            {
                Title = "All Items",
                Url = "AllItems.aspx",
                RowLimit = 25,
                Query = "<OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy>",
                IsDefault = true,
                Fields = new Collection<string> {
                    BuiltInInternalFieldNames.Edit,
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.LinkTitle,
                    FieldsInfo.Owner().InternalName,
                    FieldsInfo.EmployeesCount().InternalName,
                    BuiltInInternalFieldNames.Editor,
                    BuiltInInternalFieldNames.Modified
                },
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "All Items" },
                    new ValueForUICulture { CultureId = 1049, Value = "Все элементы" }
                }
            };
        }

        public static ListViewDefinition SubFunctionsView()
        {
            return new ListViewDefinition
            {
                Title = "All Items",
                Url = "AllItems.aspx",
                RowLimit = 25,
                Query = "<OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy>",
                IsDefault = true,
                Fields = new Collection<string> {
                    BuiltInInternalFieldNames.Edit,
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.LinkTitle,
                    FieldsInfo.Owner().InternalName,
                    FieldsInfo.Function().InternalName,
                    BuiltInInternalFieldNames.Editor,
                    BuiltInInternalFieldNames.Modified
                },
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "All Items" },
                    new ValueForUICulture { CultureId = 1049, Value = "Все элементы" }
                }
            };
        }
    }
}
