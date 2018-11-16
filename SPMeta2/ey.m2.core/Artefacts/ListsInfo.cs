using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ListsInfo
    {

        /**
         * 
         * Lists definition as containers example
         * 
         */
        public static ListDefinition Contacts()
        {
            return new ListDefinition
            {
                Title = "Contacts",
                CustomUrl = "Lists/Contacts",
                ContentTypesEnabled = true,
                EnableFolderCreation = true,
                Hidden = false,
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                EnableVersioning = true,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Contacts" },
                    new ValueForUICulture { CultureId = 1049, Value = "Контакты" }
                }
            };
        }

        public static ListDefinition Functions()
        {
            return new ListDefinition
            {
                Title = "Functions",
                CustomUrl = "Lists/Functions",
                ContentTypesEnabled = true,
                EnableFolderCreation = true,
                Hidden = false,
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                EnableVersioning = true,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Functions" },
                    new ValueForUICulture { CultureId = 1049, Value = "Функции" } }
            };
        }

        public static ListDefinition SubFunctions()
        {
            return new ListDefinition
            {
                Title = "Sub Functions",
                CustomUrl = "Lists/SubFunctions",
                ContentTypesEnabled = true,
                EnableFolderCreation = true,
                Hidden = false,
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                EnableVersioning = true,
                TitleResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Sub Functions" },
                    new ValueForUICulture { CultureId = 1049, Value = "Подчиненные функции" } }
            };
        }
    }
}
