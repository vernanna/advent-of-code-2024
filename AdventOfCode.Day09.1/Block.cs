namespace AdventOfCode.Day09._1;

public class Block(long? fileId)
{
    public long? FileId { get; private set; } = fileId;

    public bool IsEmpty => FileId == null;

    public void Clear() => FileId = null;

    public void Write(long fileId) => FileId = fileId;

    public static Block ForFile(long fileId) => new(fileId);

    public static Block Empty() => new(null);
}