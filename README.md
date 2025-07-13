# ❓ What is it?
**Tired of animator parameter headaches?** This tiny Unity package eliminates you from:
* 🚫 Manually defining string constants for Animator parameters;
* 🚫 Manual caching hashes with `Animator.StringToHash()`;
* 🚫 Remembering names of Get/Set methods for Animator's parameters;

Instead, enjoy the 3-simple-steps:
* Define a strongly-typed parameter from the package;
* Pass its string name (must match Animator parameter name);
* Use `.Value` to get/set values instantly;

It effectively **hashes & caches parameter name** and **reuses it** automatically to get/set values with maximum performance possible. For you it will be as simple as the following:

```
_isMoving = new BooleanParameter("is_moving", _animator);  
_isMoving.Value = true; // Done! 🎉
```

# 💾 Installation
* Open **Unity Package Manager** (Window > Package Manager) OR (Window > Package Management > Package Manager) in **Unity 6**;
* Click "+" → "Add package from git URL";
* Paste this **repo's URL**;
* Hit **Install**;

# 🚀 Getting started
## Step 1: Define Parameters
Add the namespace and declare your parameters:

```
using MadeYellow.AnimatorParameter;

private BooleanParameter _isMoving;
private FloatParameter _velocity;
private TriggerParameter _onLand;
```

The package support those types of parameters:
* `BooleanParameter` for **Bool** parameters;
* `IntegerParameter` for **Int** parameters;
* `FloatParameter` for **Float** parameters;
* `TriggerParameter` for triggers (best suited for events, like 'fall', etc.);

*Basically, it's the same types that are supported by Unity's `Animator`.*

## Step 2: Instantiate Parameters
Initialize them in `Awake()` or `Start()` with **name** & **Animator** reference:

```
private void Awake()
{
    _animator = GetComponent<Animator>();

    // Create instances of parameters like this
    _isMoving = new BooleanParameter("is_moving", _animator);
    _velocity = new FloatParameter("velocity", _animator);
    _onLand = new TriggerParameter("on_land", _animator);
}
```

There are just two arguments among ANY of the AnimatorParameter:
* `codename` It's just a `string`. It MUST be have same name that you've defined inside Animator controller in Unity Editor. *No need to define constant, just pass a string right into the constructor. Parameter will do the rest for you.*;
* `animator` Well, this is the `Animator` that you want to pass values into;

## Step 3: Use Parameters Effortlessly
Now you might GET or SET values by just calling `.Value` property of your parameter!

```
private void HowToSetValues()
{
    // This is how you SET values in the Animator
    _isMoving.Value = true; // Pass your BOOL value here
    _velocity.Value = 10f; // Pass your FLOAT value here

    // When you need to activate trigger - you may easily access it
    _onLand.Trigger();
}

private void HowToGetValues()
{
    // This is how GET values from the Animator
    var isCurrentlyMoving = _isMoving.Value;
}
```

## 🎯 Full Usage Example

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

# ⚡ Why You’ll Love It
* 🧠 **Zero name caching** – Define names once in constructors;
* ⚡ **Auto-hashing** – Package uses `Animator.StringToHash()` under the hood;
* 💎 **Clean syntax** – `.Value` for get/set, `.Trigger()` for events;
* 🚀 **Performance optimized** – Future plans for value-diff checks;
* 📦 **Tiny & dependency-free** – Minimal footprint;


# Want me to add something OR found a bug?

Please add an issue and describe your feature request or bug. I will add a feature if consider it usefull, and for sure will fix bugs, 'cause I'm using that package myself in my games.
