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
    public static class FeaturesInfo
    {

        /**
         * 
         * Features manipulations example
         * Example disables MDS in the target web
         * CSOM limitation should be in mind in case of SSOM features
         * 
         */
        public static FeatureDefinition DisableMinimalDownloadStrategy = BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(def =>
        {
            def.Enable = false;
        });
    }
}
