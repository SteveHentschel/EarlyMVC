﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStore.Services
{
    public class MessageService : IMessageService
    {
        public string Message { get; set; }

        public string ImageUrl { get; set; }
    }
}