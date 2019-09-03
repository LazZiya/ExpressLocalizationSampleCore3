# ExpressLocalization sample - Asp.Net Core 3.0
Fully localized Asp.Net Core 3.0 project, based on the basic template from Visual Studio.
Localized using [LazZiya.ExpressLocalization](1) and [LazZiya.TagHelpers.Localization](2).

## DotNetCore Version
This project uses **dotnetcore3.0-preview8**.
additionally you can find **dotnetcore2.2** compatible version here: [ExpressLocalization Sample for DotNetCore 2.2](https://github.com/LazZiya/ExpressLocalizationSample)

## Features :
 - Custom (route value) RequestCultureProvider
 - Custom IHtmlStringLocalizer
 - Custom [LocalizeTagHelper](2)
 - Validating localized input fields e.g. (12,34 and 12.34)
 - Localization of:
   - Razor Views (All views locailzed with [LocalizeTagHelper](2))
   - DataAnnotations
   - Model binding and model validation error messages
   - IdentityErrorDescriber messages
   - Client side validation error messages

 
## Available Cultures
_Resource texts may need fixing/adding translations_
 - Arabic
 - Chinese
 - Czech
 - Dutch
 - English
 - French
 - German
 - Hindi
 - Hungarian
 - Italian
 - Japanese
 - Korean
 - Persian
 - Polish
 - Portuguese
 - Portuguese Brazil
 - Russian
 - Spanish
 - Swedish
 - Turkish
 - Vietnamese

## Project site:
http://ziyad.info/en/articles/33-Express_Localization

## Step by step tutorial to build similar project
http://ziyad.info/en/articles/36-Develop_Multi_Cultural_Web_Application_Using_ExpressLocalization

## TagHelpers
Some parts of this project is using [LazZiya.TagHelpers](3) like:
 - LanguageNav dropdown
 - Client side validation scripts
 - AlertTagHelper for bootstrap 4 alerts
 - Localization of razor views done with [LocalizeTagHelper](2).

 
## License:
MIT

[1]: https://github.com/LazZiya/ExpressLocalization/tree/ExpressLocalizationCore3
[2]: https://github.com/LazZiya/TagHelpers.Localization/tree/TagHelpersLocalizationCore3
[3]: https://github.com/LazZiya/TagHelpers/tree/TagHelpersCore3
