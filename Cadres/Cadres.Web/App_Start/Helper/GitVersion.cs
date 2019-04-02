namespace Cadres.Web.App_Start.Helper
{
    public static class GitVersion
    {
        public static string GetVersion()
        {
            return Properties.Resources.CurrentCommit;
        }
    }
}