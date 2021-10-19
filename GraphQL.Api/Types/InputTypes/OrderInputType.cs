using HotChocolate.Types;
using System;
using System.Collections.Generic;

namespace GraphQlApi.GraphQl.Types.InputTypes
{
    public class AddOrderInput
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<AddProductInput> Products { get; set; } = new List<AddProductInput>();
    }

    public class AddOrderInputType : InputObjectType<AddOrderInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddOrderInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Product.");

            descriptor
                .Field(c => c.CustomerName)
                .Description("Represents the CustomerName.");
            descriptor
                .Field(c => c.OrderDate)
                .Description("Represents the OrderDate.");
            descriptor
                .Field(c => c.TotalAmount)
                .Description("Represents the TotalAmount.");

            descriptor
                .Field(c => c.Products)
                .Description("Represents the Products.");

            base.Configure(descriptor);
        }
    }
}