using System;

namespace Commons.DataAccess
{
    /// <summary>
    /// Various databases that are available
    /// </summary>
    [Obsolete("Old enum used for DbConnection, use DatabaseConnectionType from App.Commons")]
    public enum DatabaseConnectionType_Old
    {
        ProdDatabase1,
        ProdDatabase2,
        DevDatabase1,
        DevDatabase2
    }
}
