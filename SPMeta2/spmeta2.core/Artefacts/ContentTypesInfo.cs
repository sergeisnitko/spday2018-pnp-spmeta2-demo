using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ContentTypesInfo
    {
        /**
         * 
         * Content types nodes definitions with localization example
         * 
         */
        #region Content types definitions
        public static ContentTypeDefinition Contact()
        {
            return new ContentTypeDefinition
            {
                Name = "Demos Contact",
                Id = new Guid("1911b836-07cb-4b60-83d0-21f81ad894d4"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = ConstsInfo.DefaultGroupName,
                NameResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Demos Contact" },
                    new ValueForUICulture { CultureId = 1049, Value = "Demos Контакт" }
                }
            };
        }
        public static ContentTypeDefinition Function()
        {
            return new ContentTypeDefinition
            {
                Name = "Demos Function",
                Id = new Guid("a6805fa0-b205-4cd5-8fa5-b33768510c9d"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = ConstsInfo.DefaultGroupName,
                NameResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Demos Function" },
                    new ValueForUICulture { CultureId = 1049, Value = "Demos Функция" }
                }
            };
        }
        public static ContentTypeDefinition SubFunction()
        {
            return new ContentTypeDefinition
            {
                Name = "Demos SubFunction",
                Id = new Guid("ca80e492-4904-441c-b3c5-6f2648d150e7"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = ConstsInfo.DefaultGroupName,
                NameResource = new List<ValueForUICulture> {
                    new ValueForUICulture { CultureId = 1033, Value = "Demos SubFunction" },
                    new ValueForUICulture { CultureId = 1049, Value = "Demos дочерняя функция" }
                }
            };
        }
        #endregion

        /**
         * 
         * Content types data structure definition
         * Mapping with site columns (standard and from the model)
         * 
         */
        #region Content types mappings
        public static WebModelNode AddContactContentType(this WebModelNode node)
        {
            node
                .AddContentType(Contact(), contentType =>
                {
                    contentType
                        .AddContentTypeFieldLink(new ContentTypeFieldLinkDefinition
                        {
                            FieldId = BuiltInFieldId.Title,
                            DisplayName = "Name",
                            Required = true
                        })
                        .AddContentTypeFieldLink(FieldsInfo.Email())
                        .AddContentTypeFieldLink(FieldsInfo.PhoneNumber())
                        ;
                });
            return node;
        }

        public static WebModelNode AddFunctionContentType(this WebModelNode node)
        {
            node
                .AddContentType(Function(), contentType =>
                {
                    contentType
                        .AddContentTypeFieldLink(FieldsInfo.Owner())
                        .AddContentTypeFieldLink(FieldsInfo.EmployeesCount())
                        ;
                });
            return node;
        }

        public static WebModelNode AddSubFunctionContentType(this WebModelNode node)
        {
            node
                .AddContentType(SubFunction(), contentType =>
                {
                    contentType
                        .AddContentTypeFieldLink(FieldsInfo.Function())
                        .AddContentTypeFieldLink(FieldsInfo.Owner())
                        ;
                });
            return node;
        }
        #endregion
    }
}
