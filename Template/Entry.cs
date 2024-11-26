namespace Template;

public class Entry<T>(string Id, T Value)
{
    public string Id { get; } = Id.Trim();

    public T Value { get; } = Value;
}
