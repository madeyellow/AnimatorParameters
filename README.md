# Are you tired of the way Unity forces you to pass parameters into your Animator?
At least I did! That endless `Animator.StringToHash("my_parameter_name")` code bothered me so much...

That's why I've came up with that little library that allows you to forget about hashing of parameter's name forever. It effectively remembers a parameter name when you instantiating it and then reuses it hash automatically after. No need to define endless constants in your animation controller scripts!

# Getting started

Just import that library into your project. Now head to the script where you work with Unity's Animator component. Add using of library namespace: `using MadeYellow.AnimatorParameter;`

Now define Animator parameters using one of the following types:
* **BooleanParameter** for **Bool** (true/false) parameter;
* **IntegerParameter** for **Int** (0,1,2, etc.) parameter;
* **FloatParameter** for **Float** parameter;
* **TriggerParameter** for trigger-parameter (best suited for events, like 'fall', etc.);

Then, right after you got a reference of your Animator create instances of all parameters you've defined above. There are two arguments:
* **Codename**. It's just a string. It MUST be have same name that you've defined inside Animator controller in Unity Editor. *No need to define constant, just pass a string. Parameter will cache all the rest for you.*;
* **Animator**. Well, this is the Animator tht you want to pass values into;

And that's it! Now you might just call `.Value` of your parameter and assign a value into it. Parameter will automatically send that value to the Animator.

Here is the full example code.

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

    private void SomeMethod()
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
private void SomeMethod()
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
