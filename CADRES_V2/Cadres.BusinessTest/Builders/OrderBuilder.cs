using Cadres.Domain.Entity;
using System;
using System.Runtime.CompilerServices;

namespace Cadres.BusinessTest
{
    public class OrderBuilder
    {
        private string _customerName { get; set; }
        private string _customerPhone { get; set; }
        private string _note { get; set; }

        internal OrderBuilder(string customerName, string customerPhone)
        {
            _customerName = customerName;
            _customerPhone = customerPhone;
        }

        internal OrderBuilder WithNote(string note)
        {
            _note = note;
            return this;
        }

        internal Order Build() => new Order(_customerName, _customerPhone, _note);

        public static implicit operator Order(OrderBuilder builder) => builder.Build();
    }
}
