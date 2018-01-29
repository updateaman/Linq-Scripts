<Query Kind="Statements" />

/**
This is to test inhertience and selection of extension methods with same name
Answered for stackoverflow https://stackoverflow.com/questions/48476644/linqtosql-extension-method-resolution/48479006?noredirect=1#comment83987796_48479006
**/
var obj = new AB();

obj.SayHello(); //Hello AB
((IA)obj).SayHello(); //Hello A
((IB)obj).SayHello(); //Hello B

obj.SayBye(); //Bye AB
((IA)obj).SayBye(); //Bye A
((IB)obj).SayBye(); // Bye B

}

public interface IA
{
	void SayHello();
}
public interface IB
{
	void SayHello();
}

public class AB: IA,IB
{
	//If two interfaces have methods with same signature, 
	//They can both be implemented by prefixing interface name for one of them.
	void IA.SayHello()
	{
		Console.WriteLine("Hello A");
	}

	void IB.SayHello()
	{
		Console.WriteLine("Hello B");
	}

	public void SayHello()
	{
		Console.WriteLine("Hello AB");
	}
}

public static class MyClassExt
{
	public static void SayBye(this IA a)
	{
		Console.WriteLine("Bye from A");
	}

	public static void SayBye(this IB b)
	{
		Console.WriteLine("Bye from B");
	}

	public static void SayBye(this AB ab)
	{
		Console.WriteLine("Bye from AB");
	}
