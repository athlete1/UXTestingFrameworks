# UXTestingFrameworks

A .NET 10 UI testing framework with a Selenium WebDriver provider, an HtmlAgilityPack provider for browserless HTML tests, and example page-object projects.

## Projects

| Project | Description |
| --- | --- |
| `UX.Testing.Core` | Shared HTML controls, locators, configuration, logging, and test runner |
| `UX.Testing.Selenium` | Selenium 4 provider (Chrome, Firefox, Edge, Safari, Internet Explorer) |
| `UX.Testing.HtmlAgilityPack` | Browserless HTML document provider |
| `ExampleAbstractionProject` | Sample Bing.com page objects |
| `ExampleTestProject` | Sample MSTest tests |

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A supported browser for Selenium tests (Chrome is the default in the sample config)

Driver binaries are no longer embedded. Selenium Manager downloads matching drivers at runtime.

## Build

```bash
dotnet restore
dotnet build UXTestingFrameworks.sln
```

## Run the sample tests

```bash
dotnet test ExampleTestProject/ExampleTestProject.csproj
```

Configure the browser and site under test in `ExampleTestProject/App.config`:

```xml
<testSettings baseUrl="http://bing.com" browser="Chrome" timeout="30000" interval="50"
              debug="false" screencapture="true" autowaitforpageload="true">
  <provider assembly="UX.Testing.Selenium" type="UX.Testing.Selenium.TestingFramework" />
</testSettings>
```

Supported `browser` values: `Chrome`, `FireFox`, `Edge`, `Safari`, `InternetExplorer`.  
`PhantomJS` is obsolete and launches headless Chrome.

## Breaking changes in 2.0 (.NET 10)

- Target framework is `net10.0` (projects were previously .NET Framework 4.5 / 4.5.2).
- Selenium 2.47 was upgraded to Selenium 4. Drivers are resolved by Selenium Manager instead of copied `chromedriver.exe` / `IEDriverServer.exe` / `phantomjs.exe` binaries.
- MSTest uses `MSTest.TestFramework` / `MSTest.TestAdapter` instead of `Microsoft.VisualStudio.QualityTools.UnitTestFramework`.
- App.config remains the configuration source. Copy it to the test output directory so `testhost` can load the `testSettings` section.
- `System.Web.Mvc` and `RazorGenerator.Testing` were removed. HtmlAgilityPack HTTP mocks now use `Microsoft.AspNetCore.SystemWebAdapters`.
- `HttpUtility` helpers now use `System.Net.WebUtility`.

The MIT License (MIT)

Copyright (c) 2014 JR Cook

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
