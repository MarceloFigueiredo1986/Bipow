using Bipow.Domain.Entities.Products;
using Bipow.Domain.Entities.Products.Bikes;
using System;

namespace Bipow.Domain.Aggregates;

public class BikeAggregate
{
    public BikeAggregate()
    {
        Bike = new ();
        FrameSize = new ();
        Product = new ();
    }

    public BikeEntity Bike { get; private set; }
    public FrameSizeEntity FrameSize { get; private set; }
    public ProductEntity Product { get; private set; }
}
