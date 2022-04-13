using System.Reflection;

namespace FFMock
{
    public static class MockResponse
    {
        public static string GetFromResource(string name)
        {
            var assembly = typeof(MockResponse).GetTypeInfo().Assembly;
            var resources = assembly.GetManifestResourceNames();

            var resourceName = resources.First(s => s.Contains(name));

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }

            throw new InvalidOperationException("stream not found");
        }
    }
}
