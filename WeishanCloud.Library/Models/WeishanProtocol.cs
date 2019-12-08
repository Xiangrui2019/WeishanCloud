using System.Collections.Generic;

namespace WeishanCloud.Library.Models
{
    public enum ErrorType
    {
        Success = 0,
        WrongKey = -1,
        Pending = -2,
        RequireAttention = -3,
        NotFound = -4,
        UnknownError = -5,
        HasDoneAlready = -6,
        NotEnoughResources = -7,
        Unauthorized = -8,
        InvalidInput = -10,
        Timeout = -11
    }
    
    public class WeishanProtocol
    {
        public virtual ErrorType Code { get; set; }
        public virtual string Message { get; set; }
    }

    public class WeishanValue<T> : WeishanProtocol
    {
        public WeishanValue(T value)
        {
            Value = value;
        }
        
        public T Value { get; set; }
    }

    public class WeishanCollection<T> : WeishanProtocol
    {
        public WeishanCollection(List<T> items)
        {
            Items = items;
        }
        
        public List<T> Items { get; set; }
    }

    public class WeishanPagedCollection<T> : WeishanCollection<T>
    {
        public WeishanPagedCollection(List<T> items) : base(items) { }
        public int TotalCount { get; set; }
    }
}