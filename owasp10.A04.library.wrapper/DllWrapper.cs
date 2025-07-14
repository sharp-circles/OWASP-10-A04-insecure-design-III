using System.Text.Json;
using System.Text;

namespace owasp10.A04.library.wrapper
{
    public static class DllWrapper
    {
        public static void FuzzJsonSerializer(ReadOnlySpan<byte> bytes)
        {
            var jsonString = Encoding.UTF8.GetString(bytes);

            _ = JsonSerializer.Deserialize<ExampleDto>(jsonString);
        }

        public static void FuzzPath(ReadOnlySpan<byte> bytes)
        {
            var relativePath = Encoding.UTF8.GetString(bytes);

            _ = Path.GetFullPath(relativePath);
        }

        public static HttpResponseMessage FuzzOwaspWebApi(ReadOnlySpan<byte> bytes)
        {
            var queryParameter = Encoding.UTF8.GetString(bytes);

            using var client = new HttpClient();

            var response = client.GetAsync($"http://localhost:5003/Tests?username={queryParameter}");

            var result = response.Result;

            return result;
        }
    }
}
