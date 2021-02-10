namespace Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShortcutNotFoundException : Exception
    {
        public ShortcutNotFoundException(int shortcutId)
            : base($"No shortcut found with Id {shortcutId}")
        {
        }
    }
}
