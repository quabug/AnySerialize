# unity-package-template
template repo for unity package developer

- [Unity unit tests](.github/workflows/unity-test.yaml) for both Mono and IL2CPP backend trigger by PR. ([follow those steps](https://game.ci/docs/github/test-runner#personal-license) to get your personal lisence of Unity)
- [Release](.github/workflows/publish-upm-package.yml) [.unitypackage](https://github.com/quabug/unity-package-template/releases/tag/v0.0.1) in Release page and publish to [OpenUPM](https://openupm.com/).
- [.NET unit tests](.github/workflows/dotnet-unit-test.yml) for Windows, Linux and MacOS.
- [Publish NuGET package](.github/workflows/publish-nuget-package.yml).
