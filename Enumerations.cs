
namespace slidegrid;

internal enum GridAdvanceMode
{
    Automatic = 0,
    Manual = 1
}

internal enum GridResizeMode
{
    LargestDimension = 0,
    ByWidth = 1,
    ByHeight = 2
}

internal enum PlaybackRandomizeMode
{
    Shuffle = 0,
    Sequential = 1,
    SequentialRandomStart = 2,
    ShuffleSequences = 3
}

internal enum PlaybackSequenceMode
{
    NotSequenced = 0,
    ByFilename = 1,
    ByTimestamp = 2
}

internal enum PlaybackStaggerMode
{
    NotShuffled = 0,
    Synchronized = 1,
    Staggered = 2
}
