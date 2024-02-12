using System;
using System.Collections.Generic;

namespace DoorProblemEventAggregator
{
    public sealed class EventAggregator
    {
        private static readonly Lazy<EventAggregator> lazyInstance = new Lazy<EventAggregator>(() => new EventAggregator());
        public static EventAggregator Instance => lazyInstance.Value;

        private EventAggregator() { }

        private readonly List<Action<object>> subscribers = new List<Action<object>>();

        public void Publish<TEvent>(TEvent eventMessage)
        {
            foreach (var subscriber in subscribers)
            {
                var handler = subscriber as Action<TEvent>;
                handler?.Invoke(eventMessage);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            subscribers.Add(obj => handler((TEvent)obj));
        }
    }
}


