using System.Security.Cryptography;
using System.Text;
using SoVet.Domain.Extensions;
using SoVet.Domain.Settings;

namespace SoVet.Domain.Services.Impl;

public sealed class EncryptionService : IEncryptionService
{
    private readonly HMACSHA256 _encryptor;

    public EncryptionService(EncryptionSettings encryptionSettings)
    {
        _encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(encryptionSettings.Secret));
    }

    public async Task<string> EncryptStringAsync(string content)
    {
        var stream = await content.GenerateStreamAsync();

        return Encoding.ASCII.GetString(await _encryptor.ComputeHashAsync(stream));
    }
}