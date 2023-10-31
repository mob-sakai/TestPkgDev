DocFxForUnity
===

[![](https://img.shields.io/github/v/release/mob-sakai/DocFxForUnity)](https://github.com/mob-sakai/DocFxForUnity/releases)
[![](https://img.shields.io/github/license/mob-sakai/DocFxForUnity.svg)](https://github.com/mob-sakai/DocFxForUnity/blob/main/LICENSE.txt)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-orange.svg)](http://makeapullrequest.com)
[![](https://img.shields.io/github/watchers/mob-sakai/DocFxForUnity.svg?style=social&label=Watch)](https://github.com/mob-sakai/DocFxForUnity/subscription)
[![](https://img.shields.io/twitter/follow/mob_sakai.svg?label=Follow&style=social)](https://twitter.com/intent/follow?screen_name=mob_sakai)

<< [Description](#Description) | [Usage](#usage) | [Contributing](#contributing) >>

<br><br>

## Description

This package is designed to facilitate the integration of DocFx into Unity projects.

It is inspired by https://github.com/NormandErwan/DocFxForUnity.

### Features

- Integration of DocFx into Unity projects.
- CI environment support, including GitHub Actions.
- Generation method can be invoked from the command line interface (CLI).
  - Generate sln/csproj files.
  - Copy referenced assemblies for documentation generation.
- Provides a custom DocFx template with the following features:
  - UPM-like CSS.
  - Collapsing and displaying inherited members at the bottom of the page.
  - Collapsing and displaying inherited classes.

<br><br>

## Usage

### Setup for your Unity project

1. [Install DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool).
2. Clone this repository and copy `Documentation/` folder to your Unity project.
    ```diff
        .
        ├── Assets
    +   ├── Documentation
        ├── Package
        ├── ProjectSettings
        └── README.md
    ```

3. Edit `Documentation/docfx.json` to config documentation.  
    See <https://dotnet.github.io/docfx/tutorial/docfx.exe_user_manual.html#3-docfxjson-format> for more details.
    ```javascript
    {
      "metadata": [
        {
          ...
          "src": [
            {
              "src": "..", // relative path from Documentation/docfx.json. This is the root of your Unity project.
              "files": [
                "Your.CsProject.One.csproj", // Add your csproj files.
                "Your.CsProject.Two.csproj",
                "Glob.Is.Supported.*.csproj"
              ]
            }
          ]
        }
      ],
      "build": {
        "globalMetadata": {
          "_appTitle": "Example documentation", // Change this to your document title.
          "_appFooter": "Example documentation", // Change this to your document footer.
          ...
        },
        "sitemap": {
          "baseUrl": "https://mob-sakai.github.io/DocFxForUnity" // Change this to your GitHub Pages URL.
        }
        ...
      }
      ...
    ```

4. Edit `Documentation/filterConfig.yml` to filter namespaces/types/members/etc. to generate documentation.  
   See <https://dotnet.github.io/docfx/docs/dotnet-api-docs.html#filter-by-uid> for more details.
    ```yaml
    apiRules:
    - exclude:
        uidRegex: ^YourNameSpace\.ToIgnore
        type: Namespace
    - exclude:
        uidRegex: ^YourNameSpace\.(TypeToIgnore_One|TypeToIgnore_One)
        type: Type
    - exclude:
        uidRegex: ^YourNameSpace\.YourType\.Member.*ToIgnore
        type: Member
    ```

5. Execute DocFx to generate documentation. The generated website will be visible at http://localhost:8080.
    ```bash
    $ docfx Documentation/docfx.json --seve
    ```

### Setup for GitHubActions

If you are using GitHub Actions, please refer to the [build_documentation.yml](https://github.com/mob-sakai/TestPkgDev/blob/main/.github/workflows/build_documentation.yml) workflow.

This workflow is responsible for generating and saving documentation that can be published as GitHub Pages.

To publish it as GitHub Pages, make sure to enable the "deploy" step.

<br><br>

## Contributing

### Issues

Issues are very valuable to this project.

- Ideas are a valuable source of contributions others can make
- Problems show where this project is lacking
- With a question you show where contributors can improve the user experience

### Pull Requests

Pull requests are, a great way to get your ideas into this repository.  
See [CONTRIBUTING.md](/../../blob/main/CONTRIBUTING.md).

### Support

This is an open source project that I am developing in my spare time.  
If you like it, please support me.  
With your support, I can spend more time on development. :)

[![](https://user-images.githubusercontent.com/12690315/50731629-3b18b480-11ad-11e9-8fad-4b13f27969c1.png)](https://www.patreon.com/join/2343451?)  
[![](https://user-images.githubusercontent.com/12690315/66942881-03686280-f085-11e9-9586-fc0b6011029f.png)](https://github.com/users/mob-sakai/sponsorship)

<br><br>

## License

* MIT
* © UTJ/UCL

## Author

* ![](https://user-images.githubusercontent.com/12690315/96986908-434a0b80-155d-11eb-8275-85138ab90afa.png) [mob-sakai](https://github.com/mob-sakai) [![](https://img.shields.io/twitter/follow/mob_sakai.svg?label=Follow&style=social)](https://twitter.com/intent/follow?screen_name=mob_sakai) ![GitHub followers](https://img.shields.io/github/followers/mob-sakai?style=social)

## See Also

* GitHub page : https://github.com/mob-sakai/DocFxForUnity
* Releases : https://github.com/mob-sakai/DocFxForUnity/releases
* Issue tracker : https://github.com/mob-sakai/DocFxForUnity/issues
* Change log : https://github.com/mob-sakai/DocFxForUnity/blob/main/CHANGELOG.md
