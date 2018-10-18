//#region 1. Type Inference

let add a b = // Standard function - types bound on first call
    a + b

let res1 = add 5 2 // First call - types of a and b now bound to int
let res2 = add 5.0 2.0 // Second call fails, since we're not providing ints


let inline add' a b = // Inline function - parametric polymorphism with type constraints
    a + b

let res3 = add' 5 2 // First call - no type binding occurs, since the function is inline
let res4 = add' "5" "2" // Second call succeeds, since inline add is generic (parametric polymorphism)


let print a b = // Standard function - types inferred based on usage
    printfn "A = %i, B = %s" a b

//#endregion


//#region 2. Algebraic Data Types

/// Product types
let tuple1 = (12, 16, "s") // Instantiate tuple
let (twelve, sixteen, s) = tuple1 // Decompose tuple

type MyRecordType = // Create record type
    {
        Property1 : string
        Property2 : string
    }
let myRecordInstance = { Property1 = "Blah"; Property2 = "Blah Blah" } // Instantiate record

/// Sum types
type Address = // Define discriminated union type
    | PostalAddress of string*string*string*string
    | HomeAddress of string*string*string*string
    | EmailAddress of string

let myHomeAddress = HomeAddress ("47 Some Street", "Some Suburb", "Some City", "0000") // Construct union type
let myEmail = EmailAddress "myaddress@email.com" // Construct union type

let printAddress addr =
    match addr with // Decompose union type into different cases
    | PostalAddress (line1, line2, line3, line4) -> printfn "Postal Address: %s, %s, %s, %s" line1 line2 line3 line4
    | HomeAddress  (line1, line2, line3, line4) -> printfn "Home Address: %s, %s, %s, %s" line1 line2 line3 line4
    | EmailAddress e -> printfn "Email Address: %s" e

printAddress myHomeAddress
printAddress myEmail

//#endregion