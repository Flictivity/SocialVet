namespace SoVet.Domain.Extensions;

public static class StringExtensions
{
    public static async Task<Stream> GenerateStreamAsync(this string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        await writer.WriteAsync(s);
        await writer.FlushAsync();
        stream.Position = 0;
        return stream;
    }

    public static Stream GenerateStream(this string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}