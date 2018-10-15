## Homework3

[Repo](https://github.com/chunzel16/CS460HW)

For this homework we are tasked with learning C#. Using Microsoft Visual Studio.
I need to convert the supplied java code to C#.

## Step1: Install Visual Studio IDE

I already took this class last year, so the Visual Studio already installed

## Step2: Download java file

I download and run it in Eclipse
Next I need to change the code and follow [Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions)

## Coding

I create new branch called HW3 for this assignment, and add .gitignore file.

#### Conversion

First, for the Node.java

**java:**
```java
/** Singly linked node class. */

public class Node<T>
{
	public T data;
	public Node<T> next;
	
	public Node( T data, Node<T> next )
	{
		this.data = data;
		this.next = next;
	}
}

```

**C#**
```C#
/// <summary>
/// Singly linked node class. 
/// </summary>

public class Node<T>
{
	public T data;
	public Node<T> next;

	public Node(T data, Node<T> next)
	{
		this.data = data;
		this.next = next;
	}
}

```








