using System;
using System.Windows.Forms;

namespace rdpWrapper {
  internal sealed class LocalUserOption {
    private readonly string name;
    private readonly ToolStripMenuItem menuItem;
    private readonly LocalSettings settings;

    internal event EventHandler Changed;

    internal LocalUserOption(string name, bool defaultValue, ToolStripMenuItem menuItem, LocalSettings settings) {
      this.name = name;
      this.menuItem = menuItem;
      this.settings = settings;

      menuItem.Checked = string.Equals(settings.GetValue(name, defaultValue.ToString()), bool.TrueString, StringComparison.OrdinalIgnoreCase);
      menuItem.CheckOnClick = true;
      menuItem.CheckedChanged += (_, _) => {
        settings.SetValue(name, menuItem.Checked.ToString());
        Changed?.Invoke(this, EventArgs.Empty);
      };
    }

    internal bool Value => menuItem.Checked;
  }
}
