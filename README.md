# ❓ What is it?
A simple and tiny package that allows you to forget about:
* Defining string constants for  Animator's parameters;
* Caching parameter's hash with `Animator.StringToHash("my_parameter_name")`;
* Remembering proper method to GET or SET parameter's value in the Animator;

Instead of all the pain above you just:
* Define a strong-typed parameter;
* Pass a name. Same as in the Animator;
* Done. You now may just use it's `.Value` to GET or SET value of Animator's parameter!

It effectively **remembers a parameter name** (and calling/caching that `Animator.StringToHash` for you) when you instantiating it and then **reuses its hash** automatically after. 

No need to define endless constants in your animation controller scripts anymore!

As simple as `_isMoving = new BooleanParameter("is_moving", _animator);` and `_isMoving.Value = true;`.

# 💾 How to install SettingsParameters to my Unity project?

Use the Unity Package Manager (in Unity’s top menu: Window > Package Manager), click "+" icon, select "Add package from git URL" and type URL of this repository.

# 🚀 Getting started

There are only 3 tiny steps left to start using it: define, instantiate & use them. Let's take a closer look at each step.

## Step 1. Define parameters.
Head to the script where you work with Unity's Animator component. Add using of library namespace: `using MadeYellow.AnimatorParameter;`

Now define all needed Animator parameters using one of the following types:
* **BooleanParameter** for **Bool** (true/false) parameter;
* **IntegerParameter** for **Int** (0,1,2, etc.) parameter;
* **FloatParameter** for **Float** parameter;
* **TriggerParameter** for trigger-parameter (best suited for events, like 'fall', etc.);

Kinda like that:

```
private BooleanParameter _isMoving;
private FloatParameter _velocity;
```

## Step 2. Instantiate parameters.
Right after you obtaining a reference of your Animator - create instances of all parameters you've defined above. There are just two arguments:
* **Codename**. It's just a string. It MUST be have same name that you've defined inside Animator controller in Unity Editor. *No need to define constant, just pass a string. Parameter will cache all the rest for you.*;
* **Animator**. Well, this is the Animator tht you want to pass values into;

Just like that:

```
private void Awake()
{
    _animator = GetComponent<Animator>();

    // Create instances of parameters (define names right in the constructor, no need to cache them) and pass that animator into them
    _isMoving = new BooleanParameter("is_moving", _animator);
    _velocity = new FloatParameter("velocity", _animator);
    _onLand = new TriggerParameter("on_land", _animator);
}
```

## Step 3. Use parameters.
And that's it! Now you might just call `.Value` of your parameter and assign a value into it. Parameter will automatically send that value to the Animator.

As simple as:

```
private void SomeSetMethod()
{
    // This is easily you may SET value in the Animator
    _isMoving.Value = true; // Pass your BOOL value here
    _velocity.Value = 10f; // Pass your FLOAT value here

    // When you need to activate trigger - you may easily access it
    _onLand.Trigger();
}

private void SomeGetMethod()
{
    // This is how easily you may GET value from the Animator
    var isCurrentlyMoving = _isMoving.Value;
}
```

Here is the full example code:

```
using MadeYellow.AnimatorParameter;
using UnityEngine;

public class AnimatorParameterExample : MonoBehaviour
{
    private Animator _animator;

    // STEP 1. Define all the parameters you need once
    private BooleanParameter _isMoving;
    private FloatParameter _velocity;
    private TriggerParameter _onLand;

    private void Awake()
    {
        // STEP 2. Cache Animator
        _animator = GetComponent<Animator>();

        // STEP 3. Create instances of parameters (define names right in the constructor, no need to cache them) and pass that animator into them
        _isMoving = new BooleanParameter("is_moving", _animator);
        _velocity = new FloatParameter("velocity", _animator);
        _onLand = new TriggerParameter("on_land", _animator);
    }

    private void SomeSetMethod()
    {
        // Now somewhere in your script you may use those parameters to update their values
        _isMoving.Value = true; // Pass your value
        _velocity.Value = 10f; // Pass your value

        // When you need to activate trigger - you may easily access it
        _onLand.Trigger();
    }
}
```

Also you may fetch current value of parameter FROM Animator by getting value of `.Value` property of your parameter:

```
private void SomeGetMethod()
{
    // That will fetch a value of "is_moving" parameter from the animator
    var isCurrentlyMoving = _isMoving.Value;
}
```

# Why it's usefull?

* No need to cache parameter name - just define it in the constructor and forget about it;
* It uses `Animator.StringToHash()` inside to ensuremaxmum performance;
* Super easy to GET or SET new value by just accessing `.Value` of parameter;
*  got plans to add a value caching into a base class, to animator will receive new value only if it's changed;

# Want me to add something OR found a bug?

Please add an issue and describe your feature request or bug. I will add a feature if consider it usefull, and for sure will fix bugs, 'cause I'm using that package myself in my games.
