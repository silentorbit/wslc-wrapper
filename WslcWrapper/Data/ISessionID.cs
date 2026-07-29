using System;
using System.Collections.Generic;
using System.Text;

namespace SilentOrbit.WSLC.Data;

public interface ISessionID
{
    /// <summary>
    /// The WSLC session where the item is located.
    /// </summary>
    public string? Session { get; set; }
}
