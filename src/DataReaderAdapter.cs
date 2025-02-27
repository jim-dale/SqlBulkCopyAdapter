namespace SqlBulkCopyPrototype;

using System.Data;
using System.Diagnostics.CodeAnalysis;

public class DataReaderAdapter<T> : IDataReader
    where T : class
{
    private readonly IEnumerator<T> items;
    protected T? item;

    protected DataReaderAdapter(IEnumerable<T> items)
    {
        this.items = items.GetEnumerator();
    }

    /// <inheritdoc/>
    public object this[int i] => throw new NotImplementedException();

    /// <inheritdoc/>
    public object this[string name] => throw new NotImplementedException();

    /// <inheritdoc/>
    public int Depth => throw new NotImplementedException();

    /// <inheritdoc/>
    public bool IsClosed => throw new NotImplementedException();

    /// <inheritdoc/>
    public int RecordsAffected => throw new NotImplementedException();

    public virtual int FieldCount => throw new NotImplementedException();

    /// <inheritdoc/>
    public void Close()
    {
    }

    /// <inheritdoc/>
    public bool GetBoolean(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public byte GetByte(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public long GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferoffset, int length)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public char GetChar(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public long GetChars(int i, long fieldoffset, char[]? buffer, int bufferoffset, int length)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IDataReader GetData(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string GetDataTypeName(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public DateTime GetDateTime(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public decimal GetDecimal(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public double GetDouble(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)]
    public Type GetFieldType(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public float GetFloat(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Guid GetGuid(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public short GetInt16(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int GetInt32(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public long GetInt64(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string GetName(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int GetOrdinal(string name)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public DataTable? GetSchemaTable()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string GetString(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public virtual object GetValue(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public int GetValues(object[] values)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool IsDBNull(int i)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool NextResult()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Read()
    {
        bool result = this.items.MoveNext();

        this.item = this.items.Current;

        return result;
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
