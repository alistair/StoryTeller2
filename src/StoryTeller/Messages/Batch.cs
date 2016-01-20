﻿using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Messages
{
    public class Batch : ClientMessage
    {
        private readonly IList<ClientMessage> _messages = new List<ClientMessage>();


        public Batch() : base("batch")
        {
        }

        public Batch(params ClientMessage[] messages) : this()
        {
            _messages.AddRange(messages);
        }

        public ClientMessage[] messages
        {
            get { return _messages.ToArray(); }
            set
            {
                _messages.Clear();
                _messages.AddRange(value);
            }
        }
    }
}