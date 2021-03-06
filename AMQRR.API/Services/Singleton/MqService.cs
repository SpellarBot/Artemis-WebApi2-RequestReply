﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AMQRR.Common.MQ;
using AMQRR.Common.Configuration;
using Apache.NMS;

namespace AMQRR.API.Services.Singleton
{
    public class MqService : IMqService
    {
        // static 
        private static MqService _mqService;
        public static MqService GetInstance() => _mqService ?? (_mqService = new MqService());

        // instance
        private MqSession _mqSession;
        public MqSession MqSession => _mqSession ?? (_mqSession = new MqSession(Url.BROKER_URL));
        public ISession Session => MqSession.Session;
        public IConnection Connection => MqSession.Connection;
    }
}