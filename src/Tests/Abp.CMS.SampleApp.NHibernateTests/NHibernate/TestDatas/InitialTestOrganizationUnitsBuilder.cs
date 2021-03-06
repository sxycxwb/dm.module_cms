﻿using System.Linq;
using Abp.Channels;
using NHibernate;
using NHibernate.Linq;

namespace Abp.CMS.SampleApp.NHibernate.TestDatas
{
    /* Creates OU tree for default tenant as shown below:
     * 
     * - OU1
     *   - OU11
     *     - OU111
     *     - OU112
     *   - OU12
     * - OU2
     *   - OU21
     */
    public class InitialTestChannelsBuilder
    {
        private readonly ISession _session;

        public InitialTestChannelsBuilder(ISession session)
        {
            _session = session;
        }

        public void Build()
        {
            CreateOUs();
        }

        private void CreateOUs()
        {
            var ou1 = CreateOU("OU1", Channels.Channel.CreateCode(1));
            var ou11 = CreateOU("OU11", Channels.Channel.CreateCode(1, 1), ou1.Id);
            var ou111 = CreateOU("OU111", Channels.Channel.CreateCode(1, 1, 1), ou11.Id);
            var ou112 = CreateOU("OU112", Channels.Channel.CreateCode(1, 1, 2), ou11.Id);
            var ou12 = CreateOU("OU12", Channels.Channel.CreateCode(1, 2), ou1.Id);
            var ou2 = CreateOU("OU2", Channels.Channel.CreateCode(2));
            var ou21 = CreateOU("OU21", Channels.Channel.CreateCode(2, 1), ou2.Id);
        }

        private Channels.Channel CreateOU(string displayName, string code, long? parentId = null)
        {
            var ou = new Channels.Channel(1, displayName, parentId) {Code = code};
            _session.Save(ou);
            return ou;
        }
    }
}
