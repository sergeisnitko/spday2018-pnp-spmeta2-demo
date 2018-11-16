using spmeta2.demo.Artefacts;
using spmeta2.demo.Common;
using SPF.M2;
using Microsoft.SharePoint.Client;
using SPMeta2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo
{
    public static class Deploy
    {
        /**
         * 
         * ======================
         * Deploy scenarious demo
         * ======================
         * 
         */


        /**
        * 
        * Base provisioning example
        * Usually a provisioning project contains one provisioning scenario
        * 
        */
        public static void Demo(ClientContext Ctx)
        {
            var SiteDemoModel = ModelInfo.SiteDemoModel();
            var WebDemoModel = ModelInfo.WebDemoModel();

            SiteDemoModel.SetIncrementalProvisionModelId("Demos Site Demo");
            WebDemoModel.SetIncrementalProvisionModelId("Demos Web Demo");

            Ctx.DeployModel(SiteDemoModel);
            Ctx.DeployModel(WebDemoModel);
        }

        /**
        * 
        * Import data example as a stand along process
        * 
        */
        public static void ImportDemo(ClientContext Ctx)
        {
            var WebDemoDataModel = ModelInfo.WebDemoDataModel();
            WebDemoDataModel.SetIncrementalProvisionModelId("Demos Web Demo Data");
            Ctx.DeployModel(WebDemoDataModel);
        }

        /**
        * 
        * Example for force retraction model
        * The example removes custom action
        * 
        */
        public static void DemoRetractLite(ClientContext Ctx)
        {
            var Site = Ctx.Site;

            var CustomActions = Site.UserCustomActions;
            Ctx.Load(CustomActions);
            Ctx.ExecuteQuery();
            var SettingsLinkAction = CustomActions.Where(x => x.Name == ActionsInfo.M2ArtefactsAction().Name).FirstOrDefault();
            if (SettingsLinkAction != null)
            {
                SettingsLinkAction.DeleteObject();
                Ctx.ExecuteQuery();
            }
        }
    }
}
