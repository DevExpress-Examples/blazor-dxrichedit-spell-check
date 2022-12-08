<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1128858)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Blazor Rich Text Editor – How to Customize the Built-in Spell Check Service

This example customizes the built-in spell check service of our [Blazor Rich Text Editor](https://docs.devexpress.com/Blazor/401891/rich-text-editor) component. 

The code adds French and German dictionaries to the list that initially contains only the default American English dictionary. A [ComboBox](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxComboBox-2) above the Rich Text Editor allows you to switch between English, French, and German documents so you can try the spell checking functionality in all available languages.

The example also changes the maximum number of suggestions and allows users to add words to dictionaries.

![Blazor DxRichEdit Customize the Spell Check Service](/image.gif)

## Overview

Follow the steps below to configure the built-in service and enable the spell check feature.

### Register and Configure the Service

Call the [AddSpellCheck](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckExtensions.AddSpellCheck(IDevExpressBlazorBuilder--Action-SpellCheckOptions-)) extension method to register the built-in spell check service in your application. Within this method call, you can access and customize [spell check options](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckOptions) in the following ways:

#### Add a Dictionary

The built-in service includes the default American English dictionary. Follow the steps bellow to add another dictionary of the [simple](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.Dictionary), [ISpell](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.ISpellDictionary), or [Hunspell](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.HunspellDictionary) type:

* Assign a file provider to the [FileProvider](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckOptions.FileProvider) option so that the service can access dictionary files.
* Use the [Dictionaries](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckOptions.Dictionaries) spell check option to access the dictionary list.
* Pass a dictionary to the list's `Add` method.

Note that the service disables the default dictionary after you add another dictionary for the same culture.

#### Allow Users to Add Words to a Dictionary

In the default configuration, the built-in spell check service hides the context menu's **Add to dictionary** command that allows users to add words to a dictionary. To display this command, assign a delegate method to the [AddToDictionaryAction](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckOptions.AddToDictionaryAction) spell check option. This delegate method should meet the following requirements:

* Accept the current document culture and a word to be added.
* Write the word to a dictionary file depending on the document culture.

The Rich Text Editor executes the method assigned to the `AddToDictionaryAction` property once a user clicks the **Add to dictionary** command.

#### Change the Maximum Number of Suggestions

The [MaxSuggestionCount](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckOptions.MaxSuggestionCount) option specifies the maximum number of suggestions that the Rich Text Editor displays in its context menu. The component can display up to 15 suggestions.

### Configure the Rich Text Editor

Set the [CheckSpelling](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.DxRichEdit.CheckSpelling) property to `true` to enable the spell check feature. Use the [DocumentCulture](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.DxRichEdit.DocumentCulture) property to specify the [culture name](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.name?view=net-6.0) for an open document. An empty property value corresponds to an invariant culture.

The Rich Text Editor uses all dictionaries to check spelling when the `DocumentCulture` property corresponds to an invariant culture. Otherwise, the Rich Text Editor uses only the dictionaries whose [culture](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.DictionaryBase.Culture) is invariant or matches the document's culture. You need to update the document culture each time a new document is opened.

## Files to Review

- [Program.cs](./CS/SpellCheck/Program.cs)
- [Index.razor](./CS/SpellCheck/Pages/Index.razor)

## Documentation

- [Built-in Spell Check Service](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.SpellCheck.SpellCheckExtensions)
- [Custom Spell Check Service](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.ISpellCheckService)

## More Examples

- [Blazor Rich Text Editor - How to implement custom document save capabilities](https://github.com/DevExpress-Examples/blazor-dxrichedit-custom-saving)
- [Blazor Rich Text Editor - How to export a document to a file (HTML format)](https://github.com/DevExpress-Examples/blazor-dxrichedit-export-to-html)
