using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DelegateExamples : MonoBehaviour
{
    //The compiler converts this into a class...
    //class MeDelegate{}
    //AND since it's a class,we can create a NEW object from it...
    public delegate void MeDelegate();
    public delegate bool MeDelegateInt(int n);//take int and return bool
    public delegate int MeDelegateReturnInt();//needs nothing ,return a int
    public delegate T MeDelegateGeneric<T>();//A signature is take what and returns what
    //You almost never have to create them because we already have Actions and Funcs
    //the parameter and the return type have to match
    public void OnEnable()
    {//We're not invoking Foo,we're just passing it to a Delegate
        MeDelegate meDelegate = new MeDelegate(Foo); //Doesn't log Foo
        //This is a reference to a class,but it's also treated like a method.
        //The compiler is helping us here,we can/invoke it with...
        meDelegate.Invoke();
        //We can also invoke like this,just a shortcut.
        meDelegate();
        //meDelegate references Foo,so it's a reference to an object , and a method.

        MeDelegate meDelegate2 = Goo;//Another shortcut,but turns into the full bit in Line14
        meDelegate2();

        InvokeTheDelegate(new MeDelegate(Goo));//?
        InvokeTheDelegate(Goo);

        //Delegates are references to objects AND methods.
        Debug.Log($"Target:{meDelegate.Target}||Method:{meDelegate.Method}");
        Debug.Log($"Target:{meDelegate2.Target}||Method:{meDelegate2.Method}");

        Debug.Log(Square(22));
        //The same reason we parameterize this Square ,is why we want to parameterize our code,
        //or references to code

        //EXERCISE
        var result = GetNumbersLessThanFive(new List<int>() { 3, 4, 5, 6, 6 });
        foreach(var number in result)
        {
            Debug.Log(number);
        }
        var numbers = new List<int>() { 11, 2, 3, 4, 66 };
        var resultLessThanFive = RunThrough(numbers,LessThanFive);//can directly replace delegate with Method
        resultLessThanFive.ForEach(eachresult => Debug.Log($"LessThanFive:{eachresult}"));
        var resultLessThanTen = RunThrough(numbers, LessThanTen);
        resultLessThanTen.ForEach(eachresult => Debug.Log($"LessThanFive:{eachresult}"));
        var resultGreaterThanThirteen = RunThrough(numbers, GreaterThanThirteen);
        resultGreaterThanThirteen.ForEach(eachresult => Debug.Log($"LessThanFive:{eachresult}"));
        //Here we 'll just change the number ...
        //This is kinda neet ...but   ...We still have to make the methods
        //Let's go back to Lambdas...why can't just Paste the method itself?

        //Since all we need with the methods are the name of argument and evaluation...
        var resultLessThanFive2 = RunThrough(numbers,n=>n<5);//Why Lambda knows so much??

        MeDelegate meDelegateNew = Moo;
        //Delegate.Combine  ==  "+" Delegate.Combine returns type delegate ,so has to cast to type MeDelegate
        meDelegateNew = (MeDelegate)Delegate.Combine(meDelegateNew, (MeDelegate)Boo);        
        meDelegateNew = meDelegateNew + Sue;
        meDelegateNew += Moo;
        meDelegateNew -= Moo;
        meDelegateNew.Invoke();

        foreach(var d in meDelegateNew.GetInvocationList())
        {
            Debug.Log($"Target:{d.Target} || Method:{ meDelegateNew.Method}");
        }
        MeDelegateReturnInt meDelegateR = ReturnFive;
        meDelegateR += ReturnTen;//overwritten
        var value = meDelegateR();
        Debug.Log(value);
        foreach (var d in meDelegate.GetInvocationList())
        {
            Debug.Log(d);
        }

        MeDelegateGeneric<int> meDelgateGeneric = ReturnFive;
        meDelgateGeneric += ReturnTen;
        foreach (var a in GetAllReturnValue(meDelgateGeneric))
        {
            Debug.Log(a);
        }

        //Funcs and Actions
        //Funcs have a return!The last parameter of

        Func<int> meDelegateF = ReturnFive;//Funcs can take arguments
        meDelegateF += ReturnTen;//Chainning
        foreach (var v in GetAllReturnValueFunc(meDelegateF))
        {
            Debug.Log(v);
        }


        //Func<int, int, string> meDelegateS = Multiply;
        //Debug.Log(meDelegateS(5, 20));

        //Actions 
        //All actions return void  actions have 16
        Action<int> action = TakeAnIntAndReturnVoid;
        action(234);

        //Difference between Delegates and Events... 
        //An Event is a delegate with two restrictions :you can't assign to it directly,
        //and you can't invoke it directly
        //so heckers can't do this...
        Action myAction = ATrainsComin;
        myAction += ATrainsComin;
        //myAction = null;
        //myAction();
        //That's why we dont make straight delegate we make events.

        var trainsSignal = new TrainSignal1();
        trainsSignal.TrainsAComing += ATrainsComin;
      //can't do like trainsSignal.TrainsAComing=null; or trainsSignal.TrainsAComing.Invoke();
    }
    private void ATrainsComin()
    {
        Debug.Log("Here comes the train");
    }
    public void TakeAnIntAndReturnVoid(int obj)
    {
        Debug.Log($"Invoking our Action:{obj}");
    }
    private static IEnumerable<T1> GetAllReturnValueFunc<T1>(Func<T1> d)
    {
        foreach (Func<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }
    private static IEnumerable <T2> GetAllReturnValue<T2>(MeDelegateGeneric<T2>d)
    {
        foreach(MeDelegateGeneric<T2> del in d.GetInvocationList())
        {
            yield return del();
        }
    }
    private int ReturnFive() { return 5; }
    private int ReturnTen() { return 10; }
    static bool LessThanFive(int n){ return n < 5;}
    static bool LessThanTen(int n){ return n < 10;}
    static bool GreaterThanThirteen(int n){ return n > 13;}
    private static List<int> RunThrough(List<int> numbers, MeDelegateInt gauntlet)
    {
        return numbers.Where(number => gauntlet(number)).ToList();
    }
    private static List<int> GetNumbersLessThanTen(List<int> numbers)
    {
        return numbers.Where(number => number < 10).ToList();
    }
    private static List<int>GetNumbersLessThanFive(List <int > numbers)
    {
        return numbers.Where(number => number < 5).ToList();
    }
    private static List<int> GetNumbersMoreThanTen(List<int> numbers)
    {
        return numbers.Where(number => number >10).ToList();
    }
    public void InvokeTheDelegate(MeDelegate del)//Since MeDelegate is a Class
    {
        del();
    }

    //Parameterize out methods,pass methods around.
    public void Foo()
    {
        Debug.Log("Foo");
    }
    public static void Goo()//IF STATIC ,NO TARGET
    {
        Debug.Log("Goo");
    }
    public void Moo()
    {
        Debug.Log("Moo");
    }
    public void Boo()
    {
        Debug.Log("Boo");
    }
    public void Sue()
    {
        Debug.Log("Hi ,Sue:)");
    }
    public int Square(int x)
    {
        return x * x;
    }
}
public class TrainSignal1
{
    public event Action TrainsAComing;
    public void HereComesATrain()
    {
        TrainsAComing?.Invoke();
    }
}
public class DelegateTest { }
//Event System
//We wanna Decouple code
//If we remove ClassA,Class B and C will becom mess, this is Sphagetti code
//have to build Generic Event System to bind objects so the enemy doesn't 
//need to know anything  about one another

