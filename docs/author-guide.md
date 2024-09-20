# Pet Store

## Contents

* [Introduction](#introduction)
* [Format](#format)
* [Custom Pets](#custom)
* [Existing Pets](#existing)
* [Afterword](#afterword)

## Introduction<span id="introduction"></span>

This mod reads the `CustomFields` in `Data/Pets` in order to set a trade item ID and amount when building the pet adoption shop.<br>
The easiest way to modify that field is with [Content Patcher](https://github.com/Pathoschild/StardewMods/blob/develop/ContentPatcher/docs/author-guide.md) and you can combine that with editing the `AdoptionPrice` in the fields listed under `Breeds` to change the prices however you see fit.

## Format<span id="format"></span>

The format for the `CustomFields` entries is:
```json
"CustomFields": {
  "rokugin.petstore.<breedId>": "<itemId> <amount>",
  "rokugin.petstore.<breedId>": "<itemId> <amount>"
}
```

Each entry must be separated with a comma and every key must start with `rokugin.petstore.` before the breed Id. You must match capitilization of this exactly.<br>
Every breed you want to have trade items needs an entry of its own.<br>

Replace `<breedId>`(remove the `<>` brackets) with the `Id` from the entry in `Breeds` that you're setting trade item's for. This must match capitilization with the breed Id listed in `Breeds`.<br>

Replace `<itemId>`(remove the `<>` brackets) with the qualified or unqualified item Id, a useful list can be found [here](https://mateusaquino.github.io/stardewids/), by checking in the unpacked data, or using a mod in-game.<br>

Replace `<amount>`(remove the `<>` brackets) with an integer amount.

## Custom Pets<span id="custom"></span>

A super basic example of adding a new pet with various costs:
```jsonc
{
  "Action": "EditData",
  "Target": "Data/Pets",
  "Entries": {
    "{{ModId}}_ExamplePet": {
      "DisplayName": "Example Pet",
      "BarkSound": "cat",
      "ContentSound": "cat",
      // whatever other pet data fields you're using
      "Breeds": [
        {
          "Id": "0",
          // more breed fields
          "AdoptionPrice": 4000,
        },
        {
          "Id": "Orange",
          // more breed fields
          "AdoptionPrice": 400,
        },
        {
          "Id": "blue",
          // more breed fields
          "AdoptionPrice": 0,
        }
      ],
      "CustomFields": {
        "rokugin.petstore.0": "(O)80 2",
        "rokugin.petstore.Orange": "(W)13 1",
        "rokugin.petstore.blue": "74 1"
      }
    }
  }
}
```

This would add three breeds of this pet to the shop with varying prices and trade item requirements.<br>
Assuming you haven't changed the currency type of that shop, one would cost 4000 gold and require 2 Diamonds, another would cost 400 gold and require 1 Insect Sword, and the last would cost no gold but require 1 Prismatic Shard.

## Existing Pets<span id="existing"></span>

In order to add trade item requirements to existing pets all you need to do is:
```jsonc
{
  "Action": "EditData",
  "Target": "Data/Pets",
  "Fields": {
    "Cat": {
      "CustomFields": {
        "rokugin.petstore.0": "(W)13 1"
      }
    }
  }
}
```

This will add the requirement of 1 Insect Sword to the Orange Cat, resulting in a total cost of 40,000 gold and 1 Insect Sword.<br>

If you want to remove the currency price from an existing pet:
```jsonc
{
  "Action": "EditData",
  "Target": "Data/Pets",
  "TargetField": [
    "Cat",
    "Breeds",
    "0"
  ],
  "Entries": {
    "AdoptionPrice": 0
  }
}
```

Using this in combination with the previous block will result in the Orange Cat only requiring 1 Insect Sword to purchase.

## Afterword<span id="afterword"></span>

If you have any other questions you can ping me on the [SDV Discord](https://discord.gg/stardewvalley) in the `making-mods-general` channel or send me a message on Nexus.
