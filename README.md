# UnityOption
## Description
UnityOption is a C# implementation of the 'Option' type which can be serialized in the Unity inspector. An Option is a simple yet powerful concept for denoting an optional value. It makes code less prone to bugs by having the user of the type acknowledge that the value it holds could be missing.  

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

To access the value you must check that it's valid first:
```cs
int x = optional.Match( 
            Some: v  => v * 2,
            None: () => 0 
            );
```
Yet another alternative ("fluent") matching method is this:
```cs
int x = optional
         .Some( v  => v * 2 )
         .None( () => 0 );
```

However, clearly there will be times when you don't need to do anything with the Some case. Also, sometimes you just want some code to execute in the Some case and not the None case:
```cs
   // Returns the Some case 'as is' and 10 in the None case
   int x = optional.IfNone(10);        

   // As above, but invokes a Func<T> to return a valid value for x
   int x = optional.IfNone(() => GetAlternative());        
   
   // Invokes an Action<T> if in the Some state.
   optional.IfSome(x => Console.WriteLine(x));
```

## Serialization Behaviour
UnityOptions look like normal fields in the Unity inspector except for their names which are encloded in brackets so it's easier to see which values are optional and which are not.

A UnityOption's behavior depends on the type it wraps:
- Value types: Eveluates to None if the value equals the default value of that type.
- String type: Evauates to None if the string is null or empty.
- Reference types: Eveluates to None if the value is null.

## Odin Validator
Where this library really shines is in combination with the [Odin Validator](https://odininspector.com/odin-validator). Odin Validator is a great tool for avoiding bugs in Unity projects. One of its features is requiring references in the inspector by default. Having every reference required is of course not very practical, sometimes you need optional values. For this Odin has an 'Optional' attribute. This attrivute works fine but doesn't explicitly convey to the user that the variable is opional when using it in code.

This library was tested using v3.1.0.19 of the Odin Validator.

## Supported Unity Versions
Unity versions **2021.2 and up** are supported. It's possible the library still works in older versions but this has not been verified.

## Contributing
I am currently not accepting pull requests but feel free to create an issue if you find any bugs.

## License
UnityOption is licenced under [MIT](https://choosealicense.com/licenses/mit/)