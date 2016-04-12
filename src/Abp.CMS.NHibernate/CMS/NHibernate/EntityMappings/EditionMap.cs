﻿using Abp.Application.Editions;
using Abp.NHibernate.EntityMappings;

namespace Abp.CMS.NHibernate.EntityMappings
{
    public class EditionMap : EntityMap<Edition>
    {
        public EditionMap()
            : base("AbpEditions")
        {
            Map(x => x.Name);
            Map(x => x.DisplayName);
            
            this.MapFullAudited();
        }
    }
}