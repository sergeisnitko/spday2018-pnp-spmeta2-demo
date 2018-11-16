using SPMeta2.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spmeta2.demo.Artefacts
{
    public static class ActionsInfo
    {
        public static UserCustomActionDefinition M2ArtefactsAction()
        {
            /**
             * 
             * Script link custom action example definition
             * The JS provisioned to a web here represents data model in JS object for util perposes
             * 
             */
            return new UserCustomActionDefinition
            {
                Name = "Demos.Portal.M2Artefacts",
                Location = "ScriptLink",
                Sequence = 100,
                ScriptSrc = "~sitecollection/_catalogs/masterpage/Demos/M2.Demo/spmeta2.artefacts.js"
            };
        }
    }
}
