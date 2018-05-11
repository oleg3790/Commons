using Prism.Events;

namespace Commons
{
    public class EventPublisher<T> : PubSubEvent<EventPublisherContext<T>>
    {
        private static readonly EventAggregator _eventAggregator;
        private static readonly EventPublisher<T> _event;

        static EventPublisher()
        {
            _eventAggregator = new EventAggregator();
            _event = _eventAggregator.GetEvent<EventPublisher<T>>();
        }

        public static EventPublisher<T> Instance
        {
            get { return _event; }
        }
    }

    public class EventPublisherContext<T>
    {
        public object EventIdentifier { get; set; }
        public T EventContext { get; set; }
    }
}
