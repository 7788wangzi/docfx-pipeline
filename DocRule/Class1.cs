using Microsoft.DocAsCode.Plugins;
using System;
using System.Composition;

namespace DocRule
{
    [Export("should_not_contain_onclick", typeof(ICustomMarkdownTagValidator))]
    public class MyMarkdownTagValidator: ICustomMarkdownTagValidator
    {
       public bool Validate(string tag)
        {
            return tag.Contains("onclick");
        }
    }
}
