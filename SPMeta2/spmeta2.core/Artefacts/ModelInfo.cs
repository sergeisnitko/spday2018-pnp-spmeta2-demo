using spmeta2.demo.Common;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Syntax.Default;
using SPMeta2.Syntax.Default.Utils;
using SPMeta2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ModelInfo
    {

        /**
         * 
         * SPSite model assembly example
         * 
         */
        public static SiteModelNode SiteDemoModel()
        {
            return SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddUserCustomAction(ActionsInfo.M2ArtefactsAction())
                    .AddRootWeb(new RootWebDefinition(), RootWeb =>
                    {
                        RootWeb
                            .AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
                            {
                                var FolderPath = Path.Combine(ConstsInfo.SystemPath, ConstsInfo.DynamicAssets);
                                if (Directory.Exists(FolderPath))
                                {
                                    JSInfo.FillApplytoFile();
                                    ModuleFileUtils.LoadModuleFilesFromLocalFolder(list, FolderPath);
                                }

                            })
                            ;
                    });
            });
        }

        /**
         * 
         * SPWeb model assembly example
         * 
         */
        public static WebModelNode WebDemoModel()
        {
            return SPMeta2Model.NewWebModel(Web =>
            {
                Web
                    .AddWelcomePage(new WelcomePageDefinition
                    {
                        Url = ListsInfo.Contacts().CustomUrl
                    })
                    .AddWebFeature(FeaturesInfo.DisableMinimalDownloadStrategy)
                    .AddDemosFields()
                    .AddContactContentType()
                    .AddFunctionContentType()
                    .AddSubFunctionContentType()
                    .AddList(ListsInfo.Contacts(), List =>
                    {
                        List
                            .AddRemoveStandardContentTypes()
                            .AddContentTypeLink(ContentTypesInfo.Contact())
                            .AddListView(ViewsInfo.ContactsView())
                            ;
                    })
                    .AddList(ListsInfo.Functions(), List =>
                    {
                        List
                            .AddRemoveStandardContentTypes()
                            .AddContentTypeLink(ContentTypesInfo.Function())
                            .AddListView(ViewsInfo.FunctionsView())
                            ;
                    })
                    .AddList(ListsInfo.SubFunctions(), List =>
                    {
                        List
                            .AddRemoveStandardContentTypes()
                            .AddContentTypeLink(ContentTypesInfo.SubFunction())
                            .AddListView(ViewsInfo.SubFunctionsView())
                            ;
                    })
                    ;
            });
        }

        /**
         * 
         * SPWeb model data population example
         * The model example with data feeding nodes only 
         * 
         */
        public static WebModelNode WebDemoDataModel()
        {
            return SPMeta2Model.NewWebModel(Web =>
            {
                Web
                    .AddHostList(ListsInfo.Contacts(), List =>
                    {
                        List
                            .ImportContactsItems();
                        ;
                    })
                    .AddHostList(ListsInfo.Functions(), List =>
                    {
                        List
                            .ImportFunctionsItems()
                            ;
                    })
                    .AddHostList(ListsInfo.SubFunctions(), List =>
                    {
                        List
                            .ImportSubFunctionsItems()
                            ;
                    })
                    ;
            });
        }

    }
}
