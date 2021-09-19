<h1 align="center">
  <a href="https://github.com/GintasS/tax-management-municipalities">
    <!-- Please provide path to your logo here -->
    <img src="docs/images/logo.svg" alt="Logo" width="100" height="100">
  </a>
</h1>

<div align="center">
  Tax Management Municipalities
  <br />
  <a href="#about"><strong>Explore the screenshots »</strong></a>
  <br />
  <br />
  <a href="https://github.com/GintasS/tax-management-municipalities/issues/new?assignees=&labels=bug&template=01_BUG_REPORT.md&title=bug%3A+">Report a Bug</a>
  ·
  <a href="https://github.com/GintasS/tax-management-municipalities/issues/new?assignees=&labels=enhancement&template=02_FEATURE_REQUEST.md&title=feat%3A+">Request a Feature</a>
  .
  <a href="https://github.com/GintasS/tax-management-municipalities/issues/new?assignees=&labels=question&template=04_SUPPORT_QUESTION.md&title=support%3A+">Ask a Question</a>
</div>

<div align="center">
<br />

[![license](https://img.shields.io/github/license/GintasS/tax-management-municipalities.svg?style=flat-square)](LICENSE)

[![PRs welcome](https://img.shields.io/badge/PRs-welcome-ff69b4.svg?style=flat-square)](https://github.com/GintasS/tax-management-municipalities/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)
[![code with hearth by GintasS](https://img.shields.io/badge/%3C%2F%3E%20with%20%E2%99%A5%20by-GintasS-ff1414.svg?style=flat-square)](https://github.com/GintasS)

</div>

<details open="open">
<summary>Table of Contents</summary>

- [About](#about)
- [Features](#features)
- [Assumptions](#assumptions)
- [Notes](#notes)
- [Authors & contributors](#authors--contributors)
- [Security](#security)
- [License](#license)
- [Acknowledgements](#acknowledgements)

</details>

---

## About

This is a task for managing taxes for municipalities.

## Features

This project has a couple of features:
- .NET 5
- Some unit tests.
- DDD
- EF Core Database.
- Swagger documentation for API.
- API response code documentation.
- Some validation for requests.
- Various HTTP Status codes.
- And more.
- Resharper ran.

## Assumptions

The following assumptions were made:
- Single tax can have only a single municipality.
- Tax rate is a number that fits into a double.
- "User can ask for a specific municipality tax by entering municipality name and date" - this will return all taxes for the given municipality, if e.g one is a yearly tax(2021-01-01 to 2021-12-31) and one is a daily tax, the program will return both, since they satisfy the date.
- Dates are given in a YYYY.MM.DD format - we are not handling hours, minutes and so on.
- Municipalities are unique, two "Copenhagen" municipalities can't exist.

## Notes

Some notes:
- Even though the task mentioned a producer service, I chose an API path, because: a) were there bonus points for exposing API functionality b) for me to test the code c) for reviewers to easily test the code. The app is split into services, so it's not really that hard to take the controller logic and apply as you wish :)
- No explicit error handling is being done in the app.
- No scheduling is being done (I don't really understood this requirement, why do we need to schedule at all, who is expecting this, if the user can grab taxes by the current date?).
- This app is a little bit larger than I have expected, so it can be simplified.
- I have made an initial drawing of services and entities in the draw.io diagram, check out ***tax-management.drawio***.

## Authors & contributors

The original setup of this repository is by [Gintautas Švedas](https://github.com/GintasS).

For a full list of all authors and contributors, check [the contributor's page](https://github.com/GintasS/tax-management-municipalities/contributors).

## Security

Tax Management Municipalities follows good practices of security, but 100% security can't be granted in software.
Tax Management Municipalities is provided **"as is"** without any **warranty**. Use at your own risk.

_For more info, please refer to the [security](docs/SECURITY.md)._

## License

This project is licensed under the **MIT license**.

See [LICENSE](LICENSE) for more information.

## Acknowledgements

> **[?]**
> If your work was funded by any organization or institution, acknowledge their support here.
> In addition, if your work relies on other software libraries, or was inspired by looking at other work, it is appropriate to acknowledge this intellectual debt too.
