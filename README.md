# emoji-uid-dotnet 🚚👻🍊

[![Build, Test & Coverage](https://github.com/bolorundurowb/emoji-uid-dotnet/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/bolorundurowb/emoji-uid-dotnet/actions/workflows/build-and-test.yml)
[![codecov](https://codecov.io/gh/bolorundurowb/emoji-uid-dotnet/graph/badge.svg?token=VEUYE5ZTAH)](https://codecov.io/gh/bolorundurowb/emoji-uid-dotnet)

A .NET port of the [emoji-uid](https://github.com/Noviny/emoji-uid) project

> This package is probably not a safe way to generate IDs in production

This package generates unique identifiers, but the identifiers are a string of emoji.

```csharp
using EmojiDotNet;

var id = EmojiUid.Generate();
// 😷💩🌖 or similar
```

If you want to specify the ID length, you can provide that as an argument:

```csharp
using EmojiDotNet;

var id = EmojiUid.Generate(10);
// 🥋🥒😅⛳️⏳😷💩🌖😎👩‍👩‍👦‍👦 or similar
```

This library includes 858 emojis, or more than 631 million possible unique ids,

This project is inspired by emoji-uid.
