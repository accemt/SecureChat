using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SChat.Models.Domain.ContentTypes
{
    public enum ReceiverType
    {
        [Description("Получатель сообщения - чат-группа.")]
        Chat = 0,

        [Description("Получатель сообщения - один юзер.")]
        User = 1
    }
}