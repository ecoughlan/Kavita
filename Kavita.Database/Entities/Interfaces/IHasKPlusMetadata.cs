using System.Collections.Generic;
using Kavita.Database.Entities.MetadataMatching;

namespace Kavita.Database.Entities.Interfaces;

public interface IHasKPlusMetadata
{
    /// <summary>
    /// Tracks which metadata has been set by K+
    /// </summary>
    public IList<MetadataSettingField> KPlusOverrides { get; set; }
}
