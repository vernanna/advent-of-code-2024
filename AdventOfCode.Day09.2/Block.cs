namespace AdventOfCode.Day09._2;

public class Block(int length, long? fileId)
{
    public int Length { get; } = length;
    public long? FileId { get; private set; } = fileId;

    public bool IsEmpty => FileId == null;

    public void Clear() => FileId = null;

    public void Write(long fileId) => FileId = fileId;

    public static Block ForFile(int length, long fileId) => new(length, fileId);

    public static Block Empty(int length) => new(length, null);
}