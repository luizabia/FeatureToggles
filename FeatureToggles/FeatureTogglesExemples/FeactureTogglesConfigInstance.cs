using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureTogglesExemples
{
    public class FeactureTogglesConfigInstance
    {
        private readonly string _cn = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=FeatureTogglesSqlData;Integrated Security=False;User ID=LogicalMinds;Password=logicaldb@2014";


        private static FeactureTogglesConfigInstance _instance;

        public FeactureTogglesConfig Config { get; }

        protected FeactureTogglesConfigInstance()
        {
            Config = new FeactureTogglesConfig(new FeatureTogglesSqlData(_cn), false);
        }

        public static FeactureTogglesConfigInstance Instance()
        {
            return _instance ?? (_instance = new FeactureTogglesConfigInstance());
        }
    }
}
