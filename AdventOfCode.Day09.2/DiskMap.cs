using AdventOfCode.Shared;

namespace AdventOfCode.Day09._2;

public class DiskMap(List<Block> blocks)
{
    public IEnumerable<long> FileIds => blocks
        .Select(block => block.FileId)
        .WhereNotNull();

    public static DiskMap Create(string input)
    {
        var blocks = input
            .Select(character => int.Parse(character.ToString()))
            .Select(
                (number, index) => index % 2 == 0
                    ? Block.ForFile(number, index / 2)
                    : Block.Empty(number))
            .ToList();

        return new DiskMap(blocks);
    }

    public void Compress()
    {
        foreach (var fileId in FileIds.Reverse())
        {
            var fileBlockIndex = blocks.FindIndex(block => block.FileId == fileId);
            var fileBlock = blocks.ElementAt(fileBlockIndex);
            var emptyBlock = blocks
                .TakeWhile(block => block != fileBlock)
                .FirstOrDefault(block => block.IsEmpty && block.Length >= fileBlock.Length);
            if (emptyBlock == null)
            {
                continue;
            }

            var emptyBlockIndex = blocks.IndexOf(emptyBlock);
            blocks.Remove(emptyBlock);
            if (emptyBlock.Length > fileBlock.Length)
            {
                blocks.Insert(emptyBlockIndex, Block.Empty(emptyBlock.Length - fileBlock.Length));
            }

            blocks.Insert(emptyBlockIndex, Block.ForFile(fileBlock.Length, fileBlock.FileId!.Value));
            fileBlock.Clear();
        }
    }

    public long Checksum => blocks
        .SelectMany(block => Enumerable.Range(0, block.Length).Select(_ => block.IsEmpty ? 0 : block.FileId!.Value))
        .Select((fileId, index) => fileId * index)
        .Sum();

    public override string ToString() =>
        blocks.SelectMany(
            block => Enumerable.Range(0, block.Length)
                .Select(_ => block.IsEmpty ? "." : block.FileId!.Value.ToString())).Join("");
}