# Pet Store

## Contents

* [Introduction](#introduction)
* [Format](#format)
* [Custom Pets](#custom)
* [Existing Pets](#existing)

## Introduction<span id="introduction"></span>

This mod reads the `CustomFields` in `Data/Pets` in order to set a trade item ID and amount when building the pet adoption shop.<br>
The easiest way to modify that field is with Content Patcher and you can combine that with editing the `AdoptionPrice` in the fields listed under `Breeds` to change the prices however you see fit.

## Format<span id="format"></span>

The format for the `CustomFields` entries is:
```json
"CustomFields": {
  "rokugin.petstore.<breedId>": "<itemId> <amount>",
  "rokugin.petstore.<breedId>": "<itemId> <amount>"
}
```

Each entry must be separated with a comma and every key must start with `rokugin.petstore.` before the breed Id.<br>
Every breed you want to have trade items needs an entry of its own.<br>

Replace `<breedId>`(remove the `<>` brackets) with the `Id` from the entry in `Breeds` that you're setting trade item's for.<br>

Replace `<itemId>`(remove the `<>` brackets) with the qualified or unqualified item Id, a useful list can be found [here](https://mateusaquino.github.io/stardewids/), by checking in the unpacked data, or using a mod in-game.<br>

Replace `<amount>`(remove the `<>` brackets) with an integer amount.<br>

## Custom Pets<span id="custom"></span>



## Existing Pets<span id="existing"></span>

