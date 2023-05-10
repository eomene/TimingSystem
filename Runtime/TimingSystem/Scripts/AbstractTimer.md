

```
# AbstractTimer class

`AbstractTimer.cs` is an abstract class that provides a base implementation for
other timer classes to inherit from. It contains the core logic for keeping
track of time and firing events when a certain amount of time has passed.

## Properties

- `CurrentTime`: Gets the current time of the timer, in seconds. It can be
  negative or positive depending on how it's being updated.
- `Duration`: Gets or sets the duration of the timer, in seconds.

## Events

- `OnFinished`: Fired when the timer finishes its countdown and reaches zero
  (only fired when the timer is counting down and not counting up).

## Methods

### `Update(float deltaTime)`

Updates the timer with the given delta time, in seconds.

- `deltaTime`: The time to update the timer by.

### `Reset()`

Resets the timer back to its original state.

### `Restart()`

Restarts the timer, resetting it back to its original state and resuming
updates.

### `StartTimer()`

Starts the timer, allowing it to update its `CurrentTime` property.

### `StopTimer()`

Stops the timer, preventing it from updating its `CurrentTime` property.

### `IsRunning()`

Returns a `bool` indicating whether the timer is currently running.

### `IsFinished()`

Returns a `bool` indicating whether the timer is finished. If the timer is
counting up instead of counting down, then this will always return `false`.

### `Protected abstract float UpdateTimer(float deltaTime)`

An abstract method to be overridden by derived classes. It should implement the
logic for updating the timer state based on the provided delta time.

- `deltaTime`: The time to update the timer by.

### `Protected abstract bool ShouldFinish()`

An abstract method to be overridden by derived classes. It should implement the
logic for determining whether the timer should finish.

```