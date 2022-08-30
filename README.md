# UnityOption
## Description
UnityOption is a C# implementation of the 'Option' type which can be serialized in the Unity inspector. An Option is a simple yet powerful concept for denoting an optional value. It makes code less prone to bugs by having the user acknowledge that the value it holds could be missing.  

To give the UnityOption type its functionality, this library uses the popular [language-ext library](https://github.com/louthy/language-ext), which implements many other functional programming concepts in C#. 

## Installation
Find the latest Unity package under the releases and import it into your project, or alternatively clone or download the repository.

## Contents
This repository contains the UnityOption script and its dependencies, together with a CustomPropertyDrawer for the type and a CustomPropertyDrawer for highlighting missing references in the inspector.

## Usage
and expose it to the editor by adding the 'SerializeField' tag or making it public.

https://github.com/louthy/language-ext#option

## Odin Validator
Where this library really shines is in combination with the Odin Validator. Odin Validator makes it possible to require references in the inspector

## Supported Unity Versions
Unity versions **2021.2 and up** are supported. It's possible the library still works in older versions but this has not been verified.

## Contributing
I am currently not accepting pull requests but feel free to create an issue if you find any bugs.

## License
UnityOption is licenced under [MIT](https://choosealicense.com/licenses/mit/)