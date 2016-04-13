﻿using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Abp.CMS.Configuration
{
    public class AbpCMSSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new List<SettingDefinition>
                   {
                       new SettingDefinition(
                           AbpCMSSettingNames.Channel.MaxUserMembershipCount,
                           int.MaxValue.ToString(),
                           new FixedLocalizableString("Maximum allowed channel membership count for a user."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           )
                   };
        }
    }
}
