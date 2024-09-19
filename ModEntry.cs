using StardewModdingAPI;
using StardewValley.GameData.Pets;
using StardewValley;
using StardewValley.Internal;
using StardewValley.Objects;
using StardewModdingAPI.Events;
using StardewValley.GameData.Shops;

namespace PetStore;

internal class ModEntry : Mod {

    static IMonitor? SMonitor;

    public override void Entry(IModHelper helper) {
        SMonitor = Monitor;

        ItemQueryResolver.Register("PET_STORE", PET_STORE);

        helper.Events.Content.AssetRequested += OnAssetRequested;
    }

    private void OnAssetRequested(object? sender, AssetRequestedEventArgs e) {
        if (e.NameWithoutLocale.IsEquivalentTo("Data/Shops")) {
            e.Edit(asset => {
                var data = asset.AsDictionary<string, ShopData>().Data;

                data.TryGetValue("PetAdoption", out ShopData? shop);
                if (shop!.Items[0].ItemId == "PET_ADOPTION") {
                    shop!.Items[0].ItemId = "PET_STORE";
                }
            });
        }
    }

    public static IEnumerable<ItemQueryResult> PET_STORE(string key, string arguments, ItemQueryContext context, bool avoidRepeat, HashSet<string> avoidItemIds, Action<string, string> logError) {
        List<ItemQueryResult> stock = new List<ItemQueryResult>();

        foreach (KeyValuePair<string, PetData> pair in Game1.petData) {
            foreach (PetBreed breed in pair.Value.Breeds) {
                int tradeItemAmount = 1;
                string tradeItemId = null!;

                if (breed.CanBeAdoptedFromMarnie) {
                    if (pair.Value.CustomFields != null) {
                        pair.Value.CustomFields.TryGetValue($"rokugin.petstore.{breed.Id}", out string? values);
                        if (values != null) {
                            string[] splitValues = ItemQueryResolver.Helpers.SplitArguments(values);

                            tradeItemId = splitValues[0];
                            int.TryParse(splitValues[1], out tradeItemAmount);
                        }
                    }

                    stock.Add(new ItemQueryResult(new PetLicense {
                        Name = pair.Key + "|" + breed.Id
                    }) {
                        OverrideBasePrice = breed.AdoptionPrice,
                        OverrideTradeItemId = tradeItemId,
                        OverrideTradeItemAmount = tradeItemAmount
                    });
                }
            }
        }
        return stock;
    }

}