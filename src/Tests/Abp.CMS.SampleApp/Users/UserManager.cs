﻿using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Channels;
using Abp.Runtime.Caching;
using Abp.CMS.Configuration;
using Abp.CMS.SampleApp.MultiTenancy;
using Abp.CMS.SampleApp.Roles;

namespace Abp.CMS.SampleApp.Users
{
    public class UserManager : AbpUserManager<Tenant, Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IRepository<Tenant> tenantRepository,
            IMultiTenancyConfig multiTenancyConfig,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            ICacheManager cacheManager,
            IRepository<Channel, long> ChannelRepository, 
            IRepository<UserChannel, long> userChannelRepository,
            IChannelSettings ChannelSettings,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository)
            : base(
                userStore,
                roleManager,
                tenantRepository,
                multiTenancyConfig,
                permissionManager,
                unitOfWorkManager,
                settingManager,
                userManagementConfig,
                iocResolver,
                cacheManager,
                ChannelRepository,
                userChannelRepository,
                ChannelSettings,
                userLoginAttemptRepository)
        {
        }
    }
}