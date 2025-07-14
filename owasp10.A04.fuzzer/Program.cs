using owasp10.A04.library.wrapper;
using SharpFuzz;

namespace owasp10.A04.fuzzer;

public class Program
{
    public static void Main(string[] args)
    {
        Fuzzer.LibFuzzer.Run(bytes =>
        {
            try
            {
                var result = DllWrapper.FuzzOwaspWebApi(bytes);

                if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var responseMessage = result.Content.ReadAsStringAsync();

                    responseMessage.Wait();

                    throw new Exception(responseMessage.Result);
                }
            }
            catch (Exception) { throw; }
        });
    }
}