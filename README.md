# ExpressLocalizationSample
Fully localized project, based on the basic Asp.Net Core 3 template from Visual Studio.
Localized using [LazZiya.ExpressLocalization](https://github.com/LazZiya/ExpressLocalization).


## Features :
 - Custom (route value) RequestCultureProvider
 - Custom IHtmlStringLocalizer
 - Custom [LocalizeTagHelper](https://github.com/lazziya/TagHelpers.Localization)
 - Validating localized input fields e.g. (12,34 and 12.34)
 - Localization of:
   - Razor Views (All views locailzed with [LocalizeTagHelper](https://github.com/lazziya/TagHelpers.Localization))
   - DataAnnotations
   - Model binding and model validation error messages
   - IdentityErrorDescriber messages
   - Client side validation error messages

 
## Available Cultures
_some cultures needs fixing/adding few translations_
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
Some parts of this project is using [LazZiya.TagHelpers](https://github.com/LazZiya/TagHelpers) like:
 - LanguageNav dropdown
 - Client side validation scripts
 - AlertTagHelper for bootstrap 4 alerts
 - Localization of razor views done with [LocalizeTagHelper](https://github.com/lazziya/TagHelpers.Localization).

 
## License:
MIT
