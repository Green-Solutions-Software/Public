namespace GS.OmniChannelSystem.Rest.SDK.Api.Args
{
    public class CreateShipmentOrderArgs
    {
        public int Quantity { get; set; }
        public double[] WeightsInKg { get; set; }
        public string[] Numbers { get; set; }
    }
}
