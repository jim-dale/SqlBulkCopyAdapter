namespace SqlBulkCopyPrototype;

using Microsoft;

public sealed class PeopleDataReaderAdapter(IEnumerable<Person> items)
    : DataReaderAdapter<Person>(items)
{
    /// <inheritdoc/>
    public override int FieldCount => 2;

    /// <inheritdoc/>
    public override object GetValue(int i)
    {
        Assumes.NotNull(this.item);

        return i switch
        {
            0 => this.item.Id,
            1 => this.item.Name,
            _ => throw new NotImplementedException(),
        };
    }
}
