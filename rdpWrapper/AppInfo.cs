using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace rdpWrapper {
  internal static class AppInfo {
    internal const string ApplicationName = "rdpWrapper";
    internal const string ApplicationTitle = "RDP Wrapper";
    internal static readonly string CurrentFileLocation = Assembly.GetExecutingAssembly().Location;
    internal static readonly Version CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version;

    internal static void VisitAppSite() {
      Process.Start(new ProcessStartInfo {
        FileName = "https://github.com/sergiye/rdpWrapper",
        UseShellExecute = true
      });
    }

    internal static void ShowAbout(IWin32Window owner = null) {
      MessageBox.Show(owner,
        $"{ApplicationTitle}\nVersion {CurrentVersion}",
        ApplicationTitle,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}
