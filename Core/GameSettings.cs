using System.Configuration;

namespace Core
{
    public sealed class GameSettings : IGameSettings
    {
        public int GetUpperLimitNumber()
        {
            int upperLimitNumber = 0;

            if (ConfigurationSettings.AppSettings["UpperLimitNumber"] != null)
            {
                if ( !int.TryParse(ConfigurationSettings.AppSettings["UpperLimitNumber"], out upperLimitNumber))
                {
                    upperLimitNumber = 100;
                }                
            }

            return upperLimitNumber;
        }
    }
}
