using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Day09._1;

public class DiskMap(List<Block> blocks)
{
    public static DiskMap Create(string input)
    {
        var blocks = input
            .Select(character => int.Parse(character.ToString()))
            .SelectMany(
                (number, index) => index % 2 == 0
                    ? Enumerable.Range(0, number).Select(_ => Block.ForFile(index / 2))
                    : Enumerable.Range(0, number).Select(_ => Block.Empty()))
            .ToList();

        return new DiskMap(blocks);
    }

    public void Compress()
    {
        foreach (var block in blocks)
        {
            if (block.IsEmpty)
            {
                var lastNonEmptyBlock = blocks.SkipWhile(b => b != block).LastOrDefault(b => !b.IsEmpty);
                if (lastNonEmptyBlock != null)
                {
                    block.Write(lastNonEmptyBlock.FileId!.Value);
                    lastNonEmptyBlock.Clear();
                }
                else
                {
                    break;
                }
            }
        }
    }

    public long Checksum => blocks
        .Select((block, index) => block.FileId * index ?? 0)
        .Sum();

    public override string ToString() =>
        blocks.Select(block => block.IsEmpty ? "." : block.FileId!.Value.ToString()).Join("");
}