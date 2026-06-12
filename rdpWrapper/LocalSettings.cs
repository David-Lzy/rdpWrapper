using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace rdpWrapper {
  internal sealed class LocalSettings {
    private const string RegistryPath = @"Software\rdpWrapper";
    private readonly Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    internal bool IsPortable { get; set; }

    internal void Load() {
      using (var key = Registry.CurrentUser.OpenSubKey(RegistryPath)) {
        if (key == null) return;

        foreach (var name in key.GetValueNames()) {
          values[name] = Convert.ToString(key.GetValue(name));
        }
      }
    }

    internal string GetValue(string name, string defaultValue) {
      return values.TryGetValue(name, out var value) ? value : defaultValue;
    }

    internal int GetValue(string name, int defaultValue) {
      return int.TryParse(GetValue(name, null), out var value) ? value : defaultValue;
    }

    internal void SetValue(string name, string value) {
      values[name] = value;
      using (var key = Registry.CurrentUser.CreateSubKey(RegistryPath)) {
        key?.SetValue(name, value ?? string.Empty, RegistryValueKind.String);
      }
    }
  }
}
