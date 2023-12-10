[<AbstractClass>]
type Vehicle(initialSpeed: float) =
    // Private field to store the current speed
    let mutable currentSpeed = initialSpeed

    // Abstract member to calculate fuel efficiency
    abstract member CalculateFuelEfficiency : unit -> float

    // Method to change the speed with a default implementation
    abstract member ChangeSpeed : float -> unit
    default this.ChangeSpeed(deltaSpeed) =
        currentSpeed <- currentSpeed + deltaSpeed
        if currentSpeed < 0.0 then currentSpeed <- 0.0 // Prevent negative speed

    // Method to get the current speed
    member this.CurrentSpeed = currentSpeed

type Car(initialSpeed: float, gallonsPerHundredMiles: float) =
    inherit Vehicle(initialSpeed)

    override this.CalculateFuelEfficiency() =
        100.0 / gallonsPerHundredMiles  // Example calculation for fuel efficiency

type Bicycle(initialSpeed: float) =
    inherit Vehicle(initialSpeed)

    override this.CalculateFuelEfficiency() =
        // Bicycles don't use fuel, so we return a high efficiency value
        1000.0

// Example usage
let car = Car(0.0, 5.0) // Initial speed 0, 5 gallons per 100 miles
let bicycle = Bicycle(0.0) // Initial speed 0

car.ChangeSpeed(20.0) // Increase car speed
bicycle.ChangeSpeed(10.0) // Increase bicycle speed

printfn "Car Speed: %f, Fuel Efficiency: %f" (car.CurrentSpeed) ((car :> Vehicle).CalculateFuelEfficiency())
printfn "Bicycle Speed: %f, Fuel Efficiency: %f" (bicycle.CurrentSpeed) (bicycle.CalculateFuelEfficiency())