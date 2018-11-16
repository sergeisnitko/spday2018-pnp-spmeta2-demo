using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class FieldsInfo
    {

        /**
         * 
         * Site columns / fields definition
         * 
         */
        #region Main fields for provision
        public static TextFieldDefinition Email()
        {
            return new TextFieldDefinition
            {
                Id = new Guid("3d7d0c49-f609-4408-8061-17b08f10bcd3"),
                Title = "Email",
                InternalName = "DemosEmail",
                Group = ConstsInfo.DefaultGroupName,
                Required = true,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Email" },
                    new ValueForUICulture { CultureId = 1049, Value = "Email" }
                }
            };
        }

        public static TextFieldDefinition PhoneNumber()
        {
            return new TextFieldDefinition
            {
                Id = new Guid("4a8f48f6-6621-4ab1-9bc8-17aba1f2776c"),
                Title = "Phone Number",
                InternalName = "DemosPhoneNumber",
                Group = ConstsInfo.DefaultGroupName,
                Required = true,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Phone Number" },
                    new ValueForUICulture { CultureId = 1049, Value = "Телефонный номер" }
                }
            };
        }

        public static NumberFieldDefinition EmployeesCount()
        {
            return new NumberFieldDefinition
            {
                Id = new Guid("e08c3e0e-6a57-4bc6-bca3-4ad95e8d9eea"),
                Title = "# Employees",
                InternalName = "DemosEmployeesCount",
                Group = ConstsInfo.DefaultGroupName,
                Required = false,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "# Employees" },
                    new ValueForUICulture { CultureId = 1049, Value = "Число сотрудников" }
                }
            };
        }

        public static LookupFieldDefinition Owner()
        {
            return new LookupFieldDefinition
            {
                Id = new Guid("8a10aaec-481d-494c-b412-3a626851d20c"),
                Title = "Owner",
                InternalName = "DemosOwnerLookup",
                Group = ConstsInfo.DefaultGroupName,
                Required = false,
                AllowMultipleValues = false,
                LookupWebUrl = "~site",
                LookupListUrl = ListsInfo.Contacts().CustomUrl,
                LookupField = BuiltInInternalFieldNames.Title,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Owner" },
                    new ValueForUICulture { CultureId = 1049, Value = "Владелец" }
                }
            };
        }
        public static LookupFieldDefinition Function()
        {
            return new LookupFieldDefinition
            {
                Id = new Guid("06b7f721-66e7-45a7-8be2-ff64920c5331"),
                Title = "Function",
                InternalName = "DemosFunctionLookup",
                Group = ConstsInfo.DefaultGroupName,
                Required = true,
                AllowMultipleValues = false,
                LookupWebUrl = "~site",
                LookupListUrl = ListsInfo.Functions().CustomUrl,
                LookupField = BuiltInInternalFieldNames.Title,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Function" },
                    new ValueForUICulture { CultureId = 1049, Value = "Родительская функция" }
                }
            };
        }

        public static WebModelNode AddDemosFields(this WebModelNode node)
        {
            node
                .AddField(FieldsInfo.Email())
                .AddField(FieldsInfo.PhoneNumber())
                .AddField(FieldsInfo.EmployeesCount())
                .AddField(FieldsInfo.Owner())
                .AddField(FieldsInfo.Function())

                ;
            return node;
        }
        #endregion
    }
}
