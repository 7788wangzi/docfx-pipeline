
## Use DocFx to validate markdown

Create a `md.style` file in same folder with docfx.json file, rules could be configured in md.style file to validate the markdown files under docfiles folder.

If we don't allow markdown content using html tags, we could add following rule to the md.style file:
```
    {
      "tagNames": [ "a", "img", "H2", "ol", "ul", "li", "table" ],
      "relation": "In",
      "behavior": "Warning",
      "messageFormatter": "Content: {1}. Please do not use {0} tag, use corresponding markdown instead.",
      "customValidatorContractName": null,
      "openingTagOnly": false
    }
```

If to use custom rules, reference [Validate markdown file](https://dotnet.github.io/docfx/tutorial/intro_markdown_lite.html)

## docfx.json file

Check the format of docfx.json file at [docfx user manual](https://dotnet.github.io/docfx/tutorial/docfx.exe_user_manual.html)

## To Continuous Integrate (CI) with Azure DevOps
```
trigger:
- master

pool:
  vmImage: 'windows-2019'

steps:
- powershell: |
    choco install docfx -y
    docfx docfx.json
    if ($lastexitcode -ne 0){
      throw ("Error generating document")
    }
  displayName: "Docfx build"

- task: PublishBuildArtifacts@1
  inputs:
    pathToPublish: _site
    artifactName: site
```