using HotChocolate.Types;

namespace GraphQlApi.GraphQl.Types.InputTypes
{
    public class AddProductInput
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int? OrderId { get; set; }
    }

    public class AddProductInputType : InputObjectType<AddProductInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddProductInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Product.");

            descriptor
                .Field(c => c.Name)
                .Description("Represents the Name.");
            descriptor
                .Field(c => c.Price)
                .Description("Represents the Price.");
            descriptor
                .Field(c => c.OrderId)
                .Description("Represents the OrderId.");

            base.Configure(descriptor);
        }
    }
}