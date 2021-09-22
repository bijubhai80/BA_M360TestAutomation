using Newtonsoft.Json.Linq;

namespace M360.Pages
{
    public class PolicyRiskScreen : BaseScreen
    {
        public void setRisk(JToken testData)
        {
            SchemesScreen schemesRiskTab;
            switch (testData["Scheme"].ToString())
            {
                case "Bike Dealers Arrangement (LVS)":
                    schemesRiskTab = new BikeDealersArrangment();
                    schemesRiskTab.completeRisk(testData);
                    break;
                case "Dirt Bike Insurance":
                    schemesRiskTab = new DirtBikesInsurance();
                    schemesRiskTab.completeRisk(testData);
                    break;
                default:
                    break;
            }
        }
    }
}
