using FFConvert.Domain;

namespace FFConvert.DomainServices
{
    internal static class StateExtensions
    {
        public static void AddFiles(this State state, IEnumerable<string> items)
        {
            if (state.InputFiles is List<string> list)
            {
                list.AddRange(items);
            }
        }

        public static bool HasInputFiles(this State state)
        {
            return state.InputFiles.Count > 0;
        }
    }
}
