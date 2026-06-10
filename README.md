# Reqnroll (NUnit) + Appium with BrowserStack App Automate

Run native Android app tests on real devices on [BrowserStack App Automate](https://app-automate.browserstack.com/)
using [Reqnroll](https://reqnroll.net/) (BDD) on top of NUnit + the Appium .NET client, integrated through the
[BrowserStack C# SDK](https://www.nuget.org/packages/BrowserStack.TestAdapter) (`BrowserStack.TestAdapter`).

The SDK reads `browserstack.yml`, uploads/uses the app, provisions the device, and routes the Appium session
to the BrowserStack cloud — no changes to your test logic are required.

## Prerequisites

- A [BrowserStack account](https://www.browserstack.com/users/sign_up) (username + access key).
- [.NET SDK](https://dotnet.microsoft.com/download) 8.0 (net6.0+ is supported).
- The sample app is the public **WikipediaSample.apk**, pre-uploaded to BrowserStack and referenced in
  `android/browserstack.yml` as a `bs://` URL. To use your own build, upload it via the
  [App Automate upload API](https://www.browserstack.com/app-automate/rest-api) and replace the `app:` value.

## Setup

```bash
git clone <this-repo>
cd reqnroll-nunit-appium

# Configure credentials (either edit browserstack.yml or export env vars)
export BROWSERSTACK_USERNAME="YOUR_USERNAME"
export BROWSERSTACK_ACCESS_KEY="YOUR_ACCESS_KEY"
```

Credentials can be set in `android/browserstack.yml` (`userName` / `accessKey`) or via the
`BROWSERSTACK_USERNAME` / `BROWSERSTACK_ACCESS_KEY` environment variables (env vars take precedence).

This is an App Automate (mobile) sample, so the Android platform lives in its own self-contained directory
(`android/`) with its own `browserstack.yml`.

## Run Sample Test

The sample test drives **WikipediaSample.apk**: it taps "Search Wikipedia", types "BrowserStack", and asserts
that search results are listed.

```bash
cd android
dotnet restore
dotnet test --filter "TestCategory=sample-test"
```

To run every scenario in the project:

```bash
cd android
dotnet test
```

## Run Local Test

The local test drives **LocalSample.apk** to prove the BrowserStack Local tunnel is connected. It is tagged
`@sample-local-test` and is skipped by default in the sample run above. To run it, point `app:` in
`android/browserstack.yml` at a pre-uploaded `LocalSample.apk`, set `browserstackLocal: true`, then:

```bash
cd android
dotnet test --filter "TestCategory=sample-local-test"
```

The BrowserStack SDK starts and manages the Local tunnel automatically when `browserstackLocal: true` is set
in `browserstack.yml`.

## Notes / Dashboard

- View runs, video, device logs, and network logs on the
  [App Automate dashboard](https://app-automate.browserstack.com/).
- `testObservability: true` also surfaces the build on
  [Test Observability](https://observability.browserstack.com/).
- The driver is created with an empty `AppiumOptions` object; all capabilities (app, device, `bstack:options`)
  are injected by the SDK from `browserstack.yml`.
