using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders;

public class Order
{
    private Order() {}
    private static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
        };

        return order;
    }

    private readonly HashSet<LineItem> _lineItems = new();

    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(
            new LineItemId(Guid.NewGuid()),
            Id,
            productId,
            price
        );

        _lineItems.Add(lineItem);
    }
}
