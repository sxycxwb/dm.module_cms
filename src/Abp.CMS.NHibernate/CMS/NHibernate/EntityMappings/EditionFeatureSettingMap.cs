using Abp.Application.Features;
using FluentNHibernate.Mapping;

namespace Abp.CMS.NHibernate.EntityMappings
{
    public class EditionFeatureSettingMap : SubclassMap<EditionFeatureSetting>
    {
        public EditionFeatureSettingMap()
        {
            DiscriminatorValue("EditionFeatureSetting");

            References(x => x.Edition).Column("EditionId").Not.Nullable(); //TODO: Need to Map EditionId column?
        }
    }
}