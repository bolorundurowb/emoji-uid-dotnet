# emoji-uid-dotnet 🚚👻🍊

[![Build, Test & Coverage](https://github.com/bolorundurowb/emoji-uid-dotnet/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/bolorundurowb/emoji-uid-dotnet/actions/workflows/build-and-test.yml)
[![codecov](https://codecov.io/gh/bolorundurowb/emoji-uid-dotnet/graph/badge.svg?token=VEUYE5ZTAH)](https://codecov.io/gh/bolorundurowb/emoji-uid-dotnet)
[![NuGet](https://img.shields.io/nuget/v/emoji-uid-dotnet?logo=nuget)](https://www.nuget.org/packages/emoji-uid-dotnet)
[![License](https://img.shields.io/github/license/bolorundurowb/emoji-uid-dotnet)](LICENSE)

A .NET port of [emoji-uid](https://github.com/Noviny/emoji-uid) for generating emoji-based IDs.

> This package is not intended for security-sensitive identifiers.

## Install

```bash
dotnet add package emoji-uid-dotnet
```

## Quick start

```csharp
using EmojiDotNet;

var id = EmojiUid.Generate();
// 😷💩🌖 or similar
```

Generate a longer ID by passing a length:

```csharp
using EmojiDotNet;

var id = EmojiUid.Generate(10);
// 🥋🥒😅⛳️⏳😷💩🌖😎👩‍👩‍👦‍👦 or similar
```

## Notes

- The library includes 858 emojis, resulting in over 631 million possible 3-emoji IDs.
- IDs are fun and compact, but they are not guaranteed to be collision-free.

## For contributors

- Source lives in `src\emoji-uid-dotnet`.
- Tests live in `src\emoji-uid-dotnet.tests`.
- CI runs with GitHub Actions; coverage is published to Codecov.
