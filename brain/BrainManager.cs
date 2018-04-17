internal static class BrainManager
{
    private static volatile IBrain _brain;

    public static IBrain Brain { get => _brain; private set => _brain = value; }

    private static void SetBrain(IBrain brain)
    {
        _brain = brain;
    }
}