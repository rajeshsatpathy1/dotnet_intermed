using System;

public abstract class DbConnection
{
    public string ConnectionString { get; private set; }
    public TimeSpan Timeout { get; set; }

    public DbConnection(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string cannot be null or empty.");
        }

        ConnectionString = connectionString;
    }

    public abstract void OpenConnection();
    public abstract void CloseConnection();
}

public class SqlConnection : DbConnection
{
    public SqlConnection(string connectionString) : base(connectionString) { }

    public override void OpenConnection()
    {
        Console.WriteLine("Opening SQL Server connection.");
    }

    public override void CloseConnection()
    {
        Console.WriteLine("Closing SQL Server connection.");
    }
}

public class OracleConnection : DbConnection
{
    public OracleConnection(string connectionString) : base(connectionString) { }

    public override void OpenConnection()
    {
        Console.WriteLine("Opening Oracle connection.");
    }

    public override void CloseConnection()
    {
        Console.WriteLine("Closing Oracle connection.");
    }
}

public class DbCommand
{
    public string Instruction { get; private set; }
    public DbConnection Connection { get; private set; }

    public DbCommand(DbConnection connection, string instruction)
    {
        if (connection == null || string.IsNullOrEmpty(instruction))
        {
            throw new InvalidOperationException("Connection and instruction cannot be null.");
        }

        Connection = connection;
        Instruction = instruction;
    }

    public void Execute()
    {
        Connection.OpenConnection();
        Console.WriteLine("Running instruction: " + Instruction);
        Connection.CloseConnection();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var sqlConnection = new SqlConnection("SQL Connection String");
        var dbCommand = new DbCommand(sqlConnection, "SELECT * FROM Customers");
        dbCommand.Execute();

        var oracleConnection = new OracleConnection("Oracle Connection String");
        dbCommand = new DbCommand(oracleConnection, "SELECT * FROM Employees");
        dbCommand.Execute();

        try
        {
            dbCommand = new DbCommand(null, "SELECT * FROM Employees");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            dbCommand = new DbCommand(sqlConnection, null);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
