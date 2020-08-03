using System.Configuration;

namespace SubmarinesGameBL
{
    public static class ConfigIssues
    {
        public static int BoardClassicHeight => int.Parse(ConfigurationManager.AppSettings.Get("BOARD_HEIGHT"));
        public static int BoardClassicWidth => int.Parse(ConfigurationManager.AppSettings.Get("BOARD_WIDTH"));
        public static int ShortestSubmarine => int.Parse(ConfigurationManager.AppSettings.Get("SHORTEST_SUBMARINE"));
        public static int LongestSubmarine => int.Parse(ConfigurationManager.AppSettings.Get("LONGEST_SUBMARINE"));
    }
}
