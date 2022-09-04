# UnityOption
## Description
UnityOption is a C# implementation of the 'Option' type that can be serialized in the Unity inspector. An Option is a simple yet powerful concept for denoting an optional value. It makes code less prone to bugs by having the user of the type acknowledge that the value it holds could be missing.  

To give the UnityOption type its functionality, this library uses the popular [language-ext library](https://github.com/louthy/language-ext), which implements many other functional programming concepts in C#. 

## Installation
Find the latest Unity package under the releases and import it into your project, or alternatively clone or download the repository.

## Contents
This repository contains the UnityOption script and its dependencies, together with a CustomPropertyDrawer for the type.

## Usage
To serialize an optional value in the inspector, create a UnityOption field for the type you want to expose. You can create a UnityOption of any type but it is most useful for reference types because these can be null, which can cause runtime errors by design.
```cs
public class Example : MonoBehaviour
{
   [SerializeField] private UnityOption<GameObject> _optionalGameObject;
   [SerializeField] private UnityOption<string> _optionalString;
   [SerializeField] private UnityOption<int> _optionalInt;
}
```
The UnityOption type has different functions for checking whether a value is present or not, and retreiving it. The following examples are copied from [language-ext's readme](https://github.com/louthy/language-ext#option) :  

- To access the value you must check that it's valid first:
```cs
int x = optional.Match( 
            Some: v  => v * 2,
            None: () => 0 
            );
```
* Yet another alternative ("fluent") matching method is this:
```cs
int x = optional
         .Some( v  => v * 2 )
         .None( () => 0 );
```

* However, clearly there will be times when you don't need to do anything with the Some case. Also, sometimes you just want some code to execute in the Some case and not the None case:
```cs
   // Returns the Some case 'as is' and 10 in the None case
   int x = optional.IfNone(10);        

   // As above, but invokes a Func<T> to return a valid value for x
   int x = optional.IfNone(() => GetAlternative());        
   
   // Invokes an Action<T> if in the Some state.
   optional.IfSome(x => Console.WriteLine(x));
```

## Serialization Behaviour
UnityOptions look like normal fields in the Unity inspector except for their names, which are enclosed in brackets so it's easier to distinguish them. A UnityOption's behavior depends on the type it wraps:
- Value types: Eveluates to None if the value equals the default value of that type.
- String type: Evauates to None if the string is null or empty.
- Reference types: Eveluates to None if the value is null.

## Unity version compatibility
* Unity 2022: Fully compatible.
* Unity 2021: Not compatible with IL2CPP when using .Net Framework. (default is .NET Standard)
* Unity 2020: Not compatible with IL2CPP.
* Older versions: Not compatible because generic serialized fields are not supported yet.

## Odin Validator
Where this library really shines is in combination with the [Odin Validator](https://odininspector.com/odin-validator). Odin Validator is a great tool for avoiding bugs in Unity projects. One of its features is requiring references in the inspector by default. Having every reference required is of course not very practical, sometimes you need optional values. For this, Odin has a field attribute called 'Optional'. This attribute works fine but doesn't explicitly convey to the user that the variable is opional when using it in code. It's still just a regular field.

Instead of using the 'Optional' attribute a UnityOption variable can be used. This conveys that the field is optional, and requires the user to take into account that the value could be missing. Significantly reducing potential runtime erros. 

### Configuring Odin for UnityOption 
1. Ensure Odin and UnityOption are installed in your project.
2. Enable the **'Reference Required by Default'** rule in the Odin Validator.
3. Open the settings for this rule and include the namespaces you want to validate.
4. Be sure to **exclude** the UnityEngine namespace since it contains UnityOption, which does not need validation.

(The same can also be done for the 'No empty strings' rule. A UnityOption will evaluate to None if the string is empty in the inspector.)

### Odin version compatibility
This library was tested using v3.1.1.0 of the Odin Validator.

## Contributing
### Bug reporting
Bugs can be reported by opening new issues on GitHub. Please ensure that an issue hasn't been created already for the bug you want to report. Please provide as much relevant information about the bug as possible, and preferably steps on how to reproduce it.

### Bug fixing
Bug fixes can be submitted by creating pull requests on GitHub. Be sure to clearly describe the problem and solution in the PR description, so it can be tested and verified if needed. Please link relevant issues if applicable.

### New features
If you would like to add a new feature to the project please create an issue first to suggest the change. Once discussed, the same steps can be followed as when fixing bugs.

## Questions & Discussions
If you have questions about the project or want to discuss certain features, feel free to create an issue for this on GitHub.

## License
UnityOption is licensed under [MIT](https://choosealicense.com/licenses/mit/)
