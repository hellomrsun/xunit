using System;
using System.Diagnostics.CodeAnalysis;

namespace Xunit.Extensions
{
    /// <summary>
    /// Provides a data source for a data theory, with the data coming a Microsoft SQL Server.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "The values are available indirectly on the base class.")]
    public class SqlServerDataAttribute : OleDbDataAttribute
    {
        const string sqlWithTrust =
            "Provider=SQLOLEDB; Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI;";

        const string sqlWithUser =
            "Provider=SQLOLEDB; Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};";

        /// <summary>
        /// Creates a new instance of <see cref="SqlServerDataAttribute"/>, using a trusted connection.
        /// </summary>
        /// <param name="serverName">The server name of the Microsoft SQL Server</param>
        /// <param name="databaseName">The database name</param>
        /// <param name="selectStatement">The SQL SELECT statement to return the data for the data theory</param>
        public SqlServerDataAttribute(string serverName,
                                      string databaseName,
                                      string selectStatement)
            : base(string.Format(sqlWithTrust, serverName, databaseName), selectStatement) { }

        /// <summary>
        /// Creates a new instance of <see cref="SqlServerDataAttribute"/>, using the provided username and password.
        /// </summary>
        /// <param name="serverName">The server name of the Microsoft SQL Server</param>
        /// <param name="databaseName">The database name</param>
        /// <param name="username">The username for the server</param>
        /// <param name="password">The password for the server</param>
        /// <param name="selectStatement">The SQL SELECT statement to return the data for the data theory</param>
        public SqlServerDataAttribute(string serverName,
                                      string databaseName,
                                      string username,
                                      string password,
                                      string selectStatement)
            : base(string.Format(sqlWithUser, serverName, databaseName, username, password),
                   selectStatement) { }
    }
}