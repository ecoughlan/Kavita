using System.ComponentModel.DataAnnotations;
using Kavita.Database.Entities.Enums;
using Kavita.Database.Entities.Interfaces;

namespace Kavita.Database.Entities;

public class ServerSetting : IHasConcurrencyToken
{
    [Key]
    public required ServerSettingKey Key { get; set; }
    /// <summary>
    /// The value of the Setting. Converter knows how to convert to the correct type
    /// </summary>
    public required string Value { get; set; }

    /// <inheritdoc />
    [ConcurrencyCheck]
    public uint RowVersion { get; private set; }

    /// <inheritdoc />
    public void OnSavingChanges()
    {
        RowVersion++;
    }
}
