﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEventAggregator.Core
{
    public class MessageSentEvent:PubSubEvent<string>
    {

    }
}
